using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI_Part_Voronoi
{
    public partial class RobotView : Form
    {
        List<Point> finalPath;
        bool[] checkedItem;
        public RobotView(List<Point> _finalPath,Bitmap userImage)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            finalPath = _finalPath;
            checkedItem = new bool[finalPath.Count + 1];
            for (int i = 0; i < checkedItem.Length; ++i) checkedItem[i] = false;
            InitializeComponent();
            picBoxEneg.Image = new Bitmap(userImage);
            drawPath();
        }
        private void drawPath()
        {
            Graphics G = Graphics.FromImage(picBoxEneg.Image);
            G.DrawEllipse(new Pen(Color.Green,2), finalPath[0].X - 7, finalPath[0].Y - 7, 14, 14);
            G.DrawEllipse(new Pen(Color.Green,2), finalPath[finalPath.Count-1].X - 7, finalPath[finalPath.Count - 1].Y - 7, 14, 14);
            for (int i = 1; i < finalPath.Count; ++i)
                G.DrawLine(new Pen(Color.Green,2), finalPath[i - 1], finalPath[i]);
        }
        private void OnLoad(object sender, EventArgs e)
        {
            this.SuspendLayout();

            finalPath.Insert(0, new Point(finalPath[0].X - 1, finalPath[0].Y));
            for(int i=2; i<finalPath.Count;++i)
            {
                double dist = Utilities.distance(finalPath[i-2], finalPath[i-1]);
                double angle = Utilities.angleTwoLines(Utilities.toVector(finalPath[i - 2], finalPath[i-1]), Utilities.toVector(finalPath[i - 1],finalPath[i]));
                if (double.IsNaN(angle))
                    MessageBox.Show("Error");
                bool right = Utilities.isRight(finalPath[i - 2], finalPath[i - 1], finalPath[i]);
                
                string text = "";
                if(i!=2)
                    text = "Move forward "+Math.Round(dist,3).ToString()+" units, ";
                text += "Rotate " + Math.Round(angle, 3) + " degrees " + (!right ? "Left" : "Right");
                checkedListBox.Items.Add(text);
            }
            checkedListBox.Items.Add("Move forward " + Math.Round(Utilities.distance(finalPath[finalPath.Count - 2], finalPath[finalPath.Count - 1]), 3).ToString() +
                " units");
            this.ResumeLayout();
        }
        private void updateGUI(PictureBox picBox, Bitmap img)
        {
            picBox.Image = img;
            picBox.Invalidate();
            picBox.Update();
            picBox.Refresh();
            Application.DoEvents();
        }

        private void selectChanged(object sender, ItemCheckEventArgs e)
        {
            int selected = checkedListBox.SelectedIndex;
            Graphics G = Graphics.FromImage(picBoxEneg.Image);

            if (checkedItem[selected] == false)
            {
                checkedItem[selected] = true;
                if (selected == 0)
                    G.DrawEllipse(new Pen(Color.DarkBlue, 2), finalPath[0].X - 7, finalPath[0].Y - 7, 14, 14);
                else
                    G.DrawLine(new Pen(Color.DarkBlue, 2), finalPath[selected], finalPath[selected + 1]);
            }
            else
            {
                checkedItem[selected] = false;
                if (selected == 0)
                    G.DrawEllipse(new Pen(Color.Green, 2), finalPath[0].X - 7, finalPath[0].Y - 7, 14, 14);
                else
                    G.DrawLine(new Pen(Color.Green, 2), finalPath[selected], finalPath[selected + 1]);
            }
            updateGUI(picBoxEneg, (Bitmap)picBoxEneg.Image);
        }
    }
}
