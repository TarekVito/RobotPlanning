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
    public partial class Settings : Form
    {
        public static Color targetedColor = Color.Black;
        public static int colorDist = 200;
        public static int discretePathVal = 5;
        public static int boundriesDis = 5, robotSize = 5;
        public Settings()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            textBoxFinalPath.Text = discretePathVal.ToString();
            textBoxColorDis.Text = colorDist.ToString();
            textBoxBoundries.Text = boundriesDis.ToString();
            textBoxRobotSize.Text = robotSize.ToString();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            try {
                colorDist = int.Parse(textBoxColorDis.Text);
                boundriesDis = int.Parse(textBoxBoundries.Text);
                discretePathVal = int.Parse(textBoxFinalPath.Text);
                robotSize = int.Parse(textBoxRobotSize.Text); 
            }
            catch (Exception) { MessageBox.Show("Invalid Input"); return; }
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            d.AllowFullOpen = true;
            d.Color = targetedColor;
            if (d.ShowDialog() == DialogResult.OK)
                targetedColor = d.Color;
        }
        
    }
}
