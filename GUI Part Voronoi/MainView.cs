using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using GUI_Part_Voronoi.Properties;

namespace GUI_Part_Voronoi
{
    public partial class MainView : Form
    {
        Bitmap userImage, energyImage;
        List<Line> VoronoiSegs;
        List<Line> availablePaths;
        List<Point> finalPath;
        List<Point> obstaclePoints;
        List<Point> srcDestPoints;
        int[,] energyImageMat;


        public MainView()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            btnStartEnd.Enabled = false;
            btnRun.Enabled = false;
        }
        private void computeEnergy()
        {
            LockBitmap lImg = new LockBitmap(userImage);
            lImg.LockImage();
            int w = userImage.Width;
            int h = userImage.Height;
            energyImageMat = new int[w, h];
            int[,] tmpMat = new int[w, h];
            for (int i = 0; i < w; ++i)                     //defining obstacles in the image (1 = obstacle || 0 = non-obstacle)
                for (int j = 0; j < h; ++j)
                    if (colorDist(lImg.GetPixel(i, j), Settings.targetedColor) <= Settings.colorDist)
                        tmpMat[i, j] = 1;
                    else
                        tmpMat[i, j] = 0;

            lImg.UnlockImage();
            for (int i = 0; i < w; ++i)                 //Computing gradient magnitude
                for (int j = 0; j < h; ++j)
                    if (tmpMat[i, j] == 1)
                    {
                        if (i == 0 || j == 0 || i == w - 1 || j == h - 1)
                            energyImageMat[i, j] = 1;
                        else
                        {
                            energyImageMat[i, j] |= (tmpMat[i, j - 1] == 0 || tmpMat[i, j + 1] == 0) ? 1 : 0;
                            energyImageMat[i, j] |= (tmpMat[i - 1, j] == 0 || tmpMat[i + 1, j] == 0) ? 1 : 0;
                        }
                    }
        }
        public void generateEnergyImage() // Converting Energy Image to Black & White Image
        {
            int w = energyImageMat.GetLength(0);
            int h = energyImageMat.GetLength(1);

            energyImage = new Bitmap(w, h);
            LockBitmap lockEnergy = new LockBitmap(energyImage);
            lockEnergy.LockImage();
            for (int i = 0; i < w; ++i)
                for (int j = 0; j < h; ++j)
                {
                    int map = 255 - (int)(energyImageMat[i, j] * 255.0);
                    lockEnergy.SetPixel(i, j, Color.FromArgb(map, map, map));
                }
            lockEnergy.UnlockImage();
        }
        private int colorDist(Color A, Color B)
        {
            int red = (A.R - B.R);
            int green = (A.G - B.G);
            int blue = (A.B - B.B);
            double sum = red * red + green * green + blue * blue;
            return (int)Math.Sqrt(sum);
        }
        private Color getCopy(Color A)
        {
            int r = A.R, g = A.G, b = A.B;
            return Color.FromArgb(r, g, b);
        }
        private List<Point> convertToPoints(int minDist)        //discretizing all edges (minimum distance between every pair of points =~ minDist)
        {
            List<Point> result = new List<Point>();
            int w = energyImageMat.GetLength(0);
            int h = energyImageMat.GetLength(1);

            for (int i = 0; i < w; ++i)
                for (int j = 0; j < h; ++j)
                {
                    if (energyImageMat[i, j] == 1)
                    {
                        int startI = i - minDist + 1, endI = i + minDist;
                        int startJ = j - minDist + 1, endJ = j + minDist;
                        startI = startI < 0 ? 0 : startI; endI = endI >= w ? w : endI;
                        startJ = startJ < 0 ? 0 : startJ; endJ = endJ >= h ? h : endJ;

                        for (int BoxI = startI; BoxI < endI; ++BoxI)
                            for (int BoxJ = startJ; BoxJ < endJ; ++BoxJ)
                                energyImageMat[BoxI, BoxJ] = 0;
                        energyImageMat[i, j] = 1;
                        result.Add(new Point(i, j));
                    }
                }
            return result;
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter =
   "Images (*.BMP;*.JPG;*.JPEG;*.TIF;*.TIFF;*.GIF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.TIF;*.TIFF;*.GIF;*.PNG|" +
   "All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                btnStartEnd.Enabled = true; btnAdvaned.Enabled = false; lblNotes.Visible = false;
                Bitmap tmp = new Bitmap(645, 535);
                Graphics G = Graphics.FromImage(tmp);
                G.FillRectangle(Brushes.White, 0, 0, tmp.Width, tmp.Height);
                userImage = new Bitmap(openFileDialog1.FileName);
                userImage = Utilities.ResizeBitmap(userImage, 0, 0, 640, 530);
                G.DrawImage((Bitmap)userImage, 2, 2, 642, 532);
                userImage = tmp;
                picBoxOrg.Image = userImage;
                computeEnergy();
                generateEnergyImage();
                updateGUI(picBoxEneg, energyImage);
            }
        }

        private void addBoundriesPoints()
        {

            for (int i = 0; i < energyImage.Width; i += Settings.boundriesDis)
            {
                    obstaclePoints.Add(new Point(i, 0));
                    obstaclePoints.Add(new Point(i, energyImage.Height - 1));
            }
            for (int j = 0; j < energyImage.Height; j += Settings.boundriesDis)
            {
                    obstaclePoints.Add(new Point(0, j));
                    obstaclePoints.Add(new Point(energyImage.Width - 1, j));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try { int.Parse(textBUpRate.Text); }
            catch (Exception) { MessageBox.Show("Invalid Update Rate"); return; }
            btnRun.Enabled = false; btnAdvaned.Enabled = true;
            startVoronoi();
        }
        private Bitmap getObstaclePointsImg()
        {
            Bitmap res = new Bitmap(energyImage.Width, energyImage.Height);
            Graphics G = Graphics.FromImage(res);
            G.FillRectangle(Brushes.White, 0, 0, res.Width, res.Height);
            foreach (Point point in obstaclePoints)
                G.DrawEllipse(new Pen(Color.Red), point.X - 2, point.Y - 2, 4, 4);
            return res;
        }
        private void startVoronoi()
        {
            if (checkBox1.Checked) new StepViewer(energyImage, "First, We compute the energy Image " + '\n' + "to detect the edges").ShowDialog();
            fillObstaclesPoints();
            if (checkBox1.Checked) new StepViewer(getObstaclePointsImg(), "Then, We descretize all edges into point" + '\n' +
                 "The minimum distance between every pair of " + '\n' + "points is the robot's size").ShowDialog();
           
            updateGUI(picBoxEneg, (Bitmap)picBoxEneg.Image);
            if (FileUtil.savePointsToFile(energyImage.Width, energyImage.Height, obstaclePoints) == -1)
            { MessageBox.Show("Error While Saving"); };
            File.WriteAllBytes("Voronoi.exe", Resources.Voronoi1);
            Process voronoiCPP = Process.Start("Voronoi.exe");
            voronoiCPP.WaitForExit();
            File.Delete("Voronoi.exe");
            File.Delete("c++In.txt");
            VoronoiSegs = FileUtil.readLinesFromFile(energyImage.Width, energyImage.Height);
            addEdges(FileUtil.readPoints("c++OutS.txt"), FileUtil.readPoints("c++OutF.txt"));
            File.Delete("c++Out.txt");
            File.Delete("c++OutS.txt");
            File.Delete("c++OutF.txt");
            Bitmap copyPic = new Bitmap(energyImage);
            Graphics G = Graphics.FromImage(energyImage);
            int co = 0;
            foreach (Line edge in VoronoiSegs)
            {
                G.DrawLine(new Pen(Color.DarkGray), edge.start, edge.end);
                co++;
            }
            if (checkBox1.Checked) new StepViewer(energyImage, "After that we run Voronoi based on these points, " + '\n' + "it returns all possible safest paths" + '\n' +
                 "But as it's shown some of those paths are not safe.").ShowDialog();
            deleteNonSafePaths();
            if (checkBox1.Checked) new StepViewer(energyImage, "Now we cleared all non-safe paths.").ShowDialog();

            energyImage = new Bitmap(copyPic);

            G = Graphics.FromImage(copyPic);
            foreach (Line edge in availablePaths)
                G.DrawLine(new Pen(Color.LawnGreen), edge.start, edge.end);
            picBoxEneg.Image = copyPic;
            updateGUI(picBoxEneg, copyPic);
           
            Dijkstra d = new Dijkstra(availablePaths, srcDestPoints[0], srcDestPoints[1]);
            finalPath = d.runDijstra();
            if (finalPath == null)
            {
                MessageBox.Show("No available path");
                return;
            }
            finalPath.Insert(0, srcDestPoints[0]);
            finalPath.Add(srcDestPoints[1]);
            drawFinalPath(copyPic);
            if (checkBox1.Checked) new StepViewer((Bitmap)picBoxEneg.Image, "Finally, we calculated the shortest (safest) path" + '\n' + "for the robot.").ShowDialog();
            lblNotes.Visible = true;
            lblNotes.Text = "Notes..\n"+"Before Interpolation : "+finalPath.Count.ToString() +" Lines";
            drawFinalPath(energyImage);
            if (checkBox1.Checked) new StepViewer((Bitmap)picBoxEneg.Image, "Before Interpolation...").ShowDialog();
            discretizeFinalPath();
            drawFinalPath(energyImage);
            if (checkBox1.Checked) new StepViewer((Bitmap)picBoxEneg.Image, "After Interpolation...").ShowDialog();
            lblNotes.Text += "\nAfter Interpolation : " + finalPath.Count.ToString() + " Lines";
            drawFinalPath(userImage);
        }
        private void discretizeFinalPath()
        {
            List<Point> res = new List<Point>();
            int last=0;
            res.Add(finalPath[0]);
            for (int i = 0; i < finalPath.Count; ++i)
            {
                if (Math.Abs(finalPath[i].X - finalPath[last].X) >= Settings.discretePathVal)
                { res.Add(finalPath[i]); last = i; }
            }
            if(res[res.Count-1] != finalPath[finalPath.Count-1])
                res.Add(finalPath[finalPath.Count-1]);  
            finalPath = res;
        }
        private void addEdges(List<Point> list1, List<Point> list2)
        {
            foreach (Point p in list1)
                VoronoiSegs.Add(new Line(p, srcDestPoints[0]));
            foreach (Point p in list2)
                VoronoiSegs.Add(new Line(p, srcDestPoints[1]));
        }

        private void drawFinalPath(Bitmap imgOrg)
        {
            Bitmap img = new Bitmap(imgOrg);
            Graphics G = Graphics.FromImage(img);
            G.DrawEllipse(new Pen(Color.Green), srcDestPoints[0].X - 7, srcDestPoints[0].Y - 7, 14, 14);
            G.DrawEllipse(new Pen(Color.Green), srcDestPoints[1].X - 7, srcDestPoints[1].Y - 7, 14, 14);
            for (int i = 1; i < finalPath.Count; ++i)
                G.DrawLine(new Pen(Color.Green), finalPath[i - 1], finalPath[i]);
            updateGUI(picBoxEneg, img);
        }
        private void deleteNonSafePaths()                   //Deleting all lines that have distance <= Robot Size
        {
            int[] visited = new int[VoronoiSegs.Count];
            Array.Clear(visited, 0, visited.Length);
            availablePaths = new List<Line>();
            obstaclePoints = convertToPoints(Settings.robotSize);
            Graphics G = Graphics.FromImage(energyImage);
            int linePerFrame = int.Parse(textBUpRate.Text), countLine = 0;
            foreach (Point point in obstaclePoints)
            {
                for (int i = 0; i < VoronoiSegs.Count; ++i)
                {
                    double nearestLineDist = Utilities.linePointDist(VoronoiSegs[i], point);
                    if (nearestLineDist <= Settings.robotSize)
                    {
                        G.DrawLine(new Pen(Color.Red), VoronoiSegs[i].start, VoronoiSegs[i].end);
                        if ((countLine++ % linePerFrame) == 0)
                            updateGUI(picBoxEneg, energyImage);
                        visited[i] = 1;
                    }
                }
            }
            for (int i = 0; i < visited.Length; ++i)
                if (visited[i] == 0)
                    availablePaths.Add(VoronoiSegs[i]);
        }
        private void updateGUI(PictureBox picBox, Bitmap img)
        {
            picBox.Image = img;
            picBox.Invalidate();
            picBox.Update();
            picBox.Refresh();
            Application.DoEvents();
        }
        private void btnStartEnd_Click(object sender, EventArgs e)
        {
            srcDestPoints = new List<Point>();
            new ShortestPathView(energyImage, srcDestPoints).ShowDialog();
            if (srcDestPoints.Count == 0)
                return;
            Graphics G = Graphics.FromImage(energyImage);
            G.DrawEllipse(new Pen(Color.Red), srcDestPoints[0].X - 7, srcDestPoints[0].Y - 7, 14, 14);
            G.DrawEllipse(new Pen(Color.Green), srcDestPoints[1].X - 7, srcDestPoints[1].Y - 7, 14, 14);
            updateGUI(picBoxEneg, energyImage);
            btnRun.Enabled = true; btnStartEnd.Enabled = false;
        }
        private void fillObstaclesPoints()
        {
            obstaclePoints = convertToPoints(Settings.robotSize);
            addBoundriesPoints();
            obstaclePoints.Add(srcDestPoints[0]);
            obstaclePoints.Add(srcDestPoints[1]);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new Settings().ShowDialog();
        }

        private void btnRobot_Click(object sender, EventArgs e)
        {
            if (finalPath != null)
                new RobotView(finalPath, userImage).ShowDialog();
            else
                MessageBox.Show("No Path Found");
        }
    }
}
