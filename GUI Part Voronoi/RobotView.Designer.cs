namespace GUI_Part_Voronoi
{
    partial class RobotView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBoxEneg = new System.Windows.Forms.PictureBox();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEneg)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxEneg
            // 
            this.picBoxEneg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxEneg.Location = new System.Drawing.Point(448, 29);
            this.picBoxEneg.Name = "picBoxEneg";
            this.picBoxEneg.Size = new System.Drawing.Size(645, 535);
            this.picBoxEneg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxEneg.TabIndex = 3;
            this.picBoxEneg.TabStop = false;
            // 
            // checkedListBox
            // 
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(12, 62);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(390, 439);
            this.checkedListBox.TabIndex = 5;
            this.checkedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.selectChanged);
            // 
            // RobotView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 571);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.picBoxEneg);
            this.Name = "RobotView";
            this.Text = "RobotView";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEneg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxEneg;
        private System.Windows.Forms.CheckedListBox checkedListBox;
    }
}