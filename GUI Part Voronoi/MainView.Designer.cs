namespace GUI_Part_Voronoi
{
    partial class MainView
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.picBoxOrg = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.picBoxEneg = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnRun = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnStartEnd = new System.Windows.Forms.Button();
            this.textBUpRate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnAdvaned = new System.Windows.Forms.Button();
            this.btnRobot = new System.Windows.Forms.Button();
            this.lblNotes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEneg)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(39, 121);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(90, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open File";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // picBoxOrg
            // 
            this.picBoxOrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxOrg.Location = new System.Drawing.Point(191, 41);
            this.picBoxOrg.Name = "picBoxOrg";
            this.picBoxOrg.Size = new System.Drawing.Size(290, 270);
            this.picBoxOrg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxOrg.TabIndex = 1;
            this.picBoxOrg.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // picBoxEneg
            // 
            this.picBoxEneg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxEneg.Location = new System.Drawing.Point(534, 41);
            this.picBoxEneg.Name = "picBoxEneg";
            this.picBoxEneg.Size = new System.Drawing.Size(640, 530);
            this.picBoxEneg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxEneg.TabIndex = 2;
            this.picBoxEneg.TabStop = false;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(39, 310);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(90, 49);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Run Voronoi";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStartEnd
            // 
            this.btnStartEnd.Location = new System.Drawing.Point(39, 150);
            this.btnStartEnd.Name = "btnStartEnd";
            this.btnStartEnd.Size = new System.Drawing.Size(90, 49);
            this.btnStartEnd.TabIndex = 3;
            this.btnStartEnd.Text = "Add Start, End";
            this.btnStartEnd.UseVisualStyleBackColor = true;
            this.btnStartEnd.Click += new System.EventHandler(this.btnStartEnd_Click);
            // 
            // textBUpRate
            // 
            this.textBUpRate.Location = new System.Drawing.Point(42, 265);
            this.textBUpRate.Name = "textBUpRate";
            this.textBUpRate.Size = new System.Drawing.Size(87, 20);
            this.textBUpRate.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Update Rate (Line per frame)";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(29, 215);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(115, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Show step by step";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnAdvaned
            // 
            this.btnAdvaned.Location = new System.Drawing.Point(29, 92);
            this.btnAdvaned.Name = "btnAdvaned";
            this.btnAdvaned.Size = new System.Drawing.Size(115, 23);
            this.btnAdvaned.TabIndex = 1;
            this.btnAdvaned.Text = "Advanced Options";
            this.btnAdvaned.UseVisualStyleBackColor = true;
            this.btnAdvaned.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnRobot
            // 
            this.btnRobot.Location = new System.Drawing.Point(39, 385);
            this.btnRobot.Name = "btnRobot";
            this.btnRobot.Size = new System.Drawing.Size(90, 42);
            this.btnRobot.TabIndex = 7;
            this.btnRobot.Text = "Robot Commands";
            this.btnRobot.UseVisualStyleBackColor = true;
            this.btnRobot.Click += new System.EventHandler(this.btnRobot_Click);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(191, 333);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 10;
            this.lblNotes.Text = "Notes";
            this.lblNotes.Visible = false;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 600);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.btnRobot);
            this.Controls.Add(this.btnAdvaned);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBUpRate);
            this.Controls.Add(this.btnStartEnd);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.picBoxEneg);
            this.Controls.Add(this.picBoxOrg);
            this.Controls.Add(this.btnOpen);
            this.Name = "MainView";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEneg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.PictureBox picBoxOrg;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox picBoxEneg;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnStartEnd;
        private System.Windows.Forms.TextBox textBUpRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnAdvaned;
        private System.Windows.Forms.Button btnRobot;
        private System.Windows.Forms.Label lblNotes;
    }
}

