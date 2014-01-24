namespace GUI_Part_Voronoi
{
    partial class Settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxColorDis = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.textBoxBoundries = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRobotSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.textBoxFinalPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Max color distance \r\n(to consider an obstacle)";
            // 
            // textBoxColorDis
            // 
            this.textBoxColorDis.Location = new System.Drawing.Point(192, 77);
            this.textBoxColorDis.Name = "textBoxColorDis";
            this.textBoxColorDis.Size = new System.Drawing.Size(100, 20);
            this.textBoxColorDis.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Target Color";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(192, 32);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Select Color";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // textBoxBoundries
            // 
            this.textBoxBoundries.Location = new System.Drawing.Point(192, 127);
            this.textBoxBoundries.Name = "textBoxBoundries";
            this.textBoxBoundries.Size = new System.Drawing.Size(100, 20);
            this.textBoxBoundries.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Distance between boundries\'\r\npoints";
            // 
            // textBoxRobotSize
            // 
            this.textBoxRobotSize.Location = new System.Drawing.Point(192, 183);
            this.textBoxRobotSize.Name = "textBoxRobotSize";
            this.textBoxRobotSize.Size = new System.Drawing.Size(100, 20);
            this.textBoxRobotSize.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Robot size";
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(111, 285);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(100, 23);
            this.btnDone.TabIndex = 5;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // textBoxFinalPath
            // 
            this.textBoxFinalPath.Location = new System.Drawing.Point(192, 239);
            this.textBoxFinalPath.Name = "textBoxFinalPath";
            this.textBoxFinalPath.Size = new System.Drawing.Size(100, 20);
            this.textBoxFinalPath.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Final Path (x-axis Interpolation)";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 342);
            this.Controls.Add(this.textBoxFinalPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.textBoxRobotSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxBoundries);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxColorDis);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxColorDis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox textBoxBoundries;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRobotSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.TextBox textBoxFinalPath;
        private System.Windows.Forms.Label label5;
    }
}