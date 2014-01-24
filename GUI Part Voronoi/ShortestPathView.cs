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
    public partial class ShortestPathView : Form
    {
        Bitmap energyImage,resetImage;
        List<Point> srcDest;
        Point start, end;
        public ShortestPathView(Bitmap enImage, List<Point> _srcDest)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            srcDest = _srcDest;
            initStartEnd();
            energyImage = new Bitmap(enImage);
            resetImage = new Bitmap(enImage);
            InitializeComponent();
            picBoxVImg.Image = energyImage;
        }
        private void initStartEnd()
        {
            start = new Point(-1, -1);
            end = new Point(-1, -1);
        }
        private void updateGUI(PictureBox picBox, Bitmap img)
        {
            picBox.Image = img;
            picBox.Invalidate();
            picBox.Update();
            picBox.Refresh();
            Application.DoEvents();
        }

        private void doubleClick(object sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;
            Color cirColor;
            if (start == new Point(-1,-1))
            { start = new Point(mouse.X, mouse.Y); cirColor = Color.Red; }
            else if (end == new Point(-1, -1) && new Point(mouse.X, mouse.Y) != start)
            { end = new Point(mouse.X, mouse.Y); cirColor = Color.Green; }
            else
                return;
            Graphics G = Graphics.FromImage(energyImage);
            G.DrawEllipse(new Pen(cirColor), mouse.X - 7, mouse.Y - 7, 14 , 14);
            updateGUI(picBoxVImg, energyImage);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (start == new Point(-1, -1) || end == new Point(-1, -1))
            {MessageBox.Show("You must select start and end nodes"); return;}
            srcDest.Add(new Point(start.X, start.Y));
            srcDest.Add(new Point(end.X, end.Y));
                    
            this.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            initStartEnd();
            energyImage = new Bitmap(resetImage);
            updateGUI(picBoxVImg, energyImage);
        }
    }
}
