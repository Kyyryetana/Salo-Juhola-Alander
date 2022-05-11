namespace StudyPoint
{
    partial class gallery_big
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bigImageNextBT = new System.Windows.Forms.Button();
            this.bigImageBackBT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(850, 625);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bigImageNextBT
            // 
            this.bigImageNextBT.Location = new System.Drawing.Point(775, 602);
            this.bigImageNextBT.Name = "bigImageNextBT";
            this.bigImageNextBT.Size = new System.Drawing.Size(75, 23);
            this.bigImageNextBT.TabIndex = 1;
            this.bigImageNextBT.Text = "Next";
            this.bigImageNextBT.UseVisualStyleBackColor = true;
            this.bigImageNextBT.Click += new System.EventHandler(this.bigImageNextBT_Click);
            // 
            // bigImageBackBT
            // 
            this.bigImageBackBT.Location = new System.Drawing.Point(0, 602);
            this.bigImageBackBT.Name = "bigImageBackBT";
            this.bigImageBackBT.Size = new System.Drawing.Size(75, 23);
            this.bigImageBackBT.TabIndex = 1;
            this.bigImageBackBT.Text = "back";
            this.bigImageBackBT.UseVisualStyleBackColor = true;
            this.bigImageBackBT.Click += new System.EventHandler(this.bigImageBackBT_Click);
            // 
            // gallery_big
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 625);
            this.Controls.Add(this.bigImageBackBT);
            this.Controls.Add(this.bigImageNextBT);
            this.Controls.Add(this.pictureBox1);
            this.Name = "gallery_big";
            this.Text = "gallery_big";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bigImageNextBT;
        private System.Windows.Forms.Button bigImageBackBT;
    }
}