namespace GUI_Part_Voronoi
{
    partial class StepViewer
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
            this.picBoxVImg = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxVImg)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxVImg
            // 
            this.picBoxVImg.Location = new System.Drawing.Point(21, 20);
            this.picBoxVImg.Name = "picBoxVImg";
            this.picBoxVImg.Size = new System.Drawing.Size(645, 535);
            this.picBoxVImg.TabIndex = 1;
            this.picBoxVImg.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(698, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "Done";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelMsg
            // 
            this.labelMsg.AutoSize = true;
            this.labelMsg.Location = new System.Drawing.Point(683, 113);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(35, 13);
            this.labelMsg.TabIndex = 2;
            this.labelMsg.Text = "label1";
            // 
            // StepViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 562);
            this.Controls.Add(this.labelMsg);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picBoxVImg);
            this.Name = "StepViewer";
            this.Text = "StepViewer";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxVImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxVImg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelMsg;
    }
}