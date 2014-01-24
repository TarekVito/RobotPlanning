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
    public partial class StepViewer : Form
    {
        public StepViewer(Bitmap screenS, String msg)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            updateGUI(picBoxVImg, screenS);
            labelMsg.Text = msg;
        }
        private void updateGUI(PictureBox picBox, Bitmap img)
        {
            picBox.Image = img;
            picBox.Invalidate();
            picBox.Update();
            picBox.Refresh();
            Application.DoEvents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
