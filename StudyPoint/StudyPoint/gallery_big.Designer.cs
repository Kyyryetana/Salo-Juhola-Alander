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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gallery_big));
            this.BigGalPicPB = new System.Windows.Forms.PictureBox();
            this.bigImageNextBT = new System.Windows.Forms.Button();
            this.bigImageBackBT = new System.Windows.Forms.Button();
            this.BigPicList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BigGalPicPB)).BeginInit();
            this.SuspendLayout();
            // 
            // BigGalPicPB
            // 
            this.BigGalPicPB.Location = new System.Drawing.Point(0, 0);
            this.BigGalPicPB.Name = "BigGalPicPB";
            this.BigGalPicPB.Size = new System.Drawing.Size(665, 516);
            this.BigGalPicPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BigGalPicPB.TabIndex = 0;
            this.BigGalPicPB.TabStop = false;
            // 
            // bigImageNextBT
            // 
            this.bigImageNextBT.Location = new System.Drawing.Point(527, 522);
            this.bigImageNextBT.Name = "bigImageNextBT";
            this.bigImageNextBT.Size = new System.Drawing.Size(75, 23);
            this.bigImageNextBT.TabIndex = 1;
            this.bigImageNextBT.Text = "Next";
            this.bigImageNextBT.UseVisualStyleBackColor = true;
            this.bigImageNextBT.Click += new System.EventHandler(this.bigImageNextBT_Click);
            // 
            // bigImageBackBT
            // 
            this.bigImageBackBT.Location = new System.Drawing.Point(0, 522);
            this.bigImageBackBT.Name = "bigImageBackBT";
            this.bigImageBackBT.Size = new System.Drawing.Size(75, 23);
            this.bigImageBackBT.TabIndex = 1;
            this.bigImageBackBT.Text = "back";
            this.bigImageBackBT.UseVisualStyleBackColor = true;
            this.bigImageBackBT.Click += new System.EventHandler(this.bigImageBackBT_Click);
            // 
            // BigPicList
            // 
            this.BigPicList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("BigPicList.ImageStream")));
            this.BigPicList.TransparentColor = System.Drawing.Color.Transparent;
            this.BigPicList.Images.SetKeyName(0, "pic1.jpg");
            this.BigPicList.Images.SetKeyName(1, "pic2.jpg");
            this.BigPicList.Images.SetKeyName(2, "pic3.jpg");
            this.BigPicList.Images.SetKeyName(3, "pic4.jpg");
            this.BigPicList.Images.SetKeyName(4, "pic5.jpg");
            this.BigPicList.Images.SetKeyName(5, "pic6.jpg");
            this.BigPicList.Images.SetKeyName(6, "pic7.jpg");
            this.BigPicList.Images.SetKeyName(7, "pic8.jpg");
            this.BigPicList.Images.SetKeyName(8, "pic9.jpg");
            this.BigPicList.Images.SetKeyName(9, "pic10.JPG");
            this.BigPicList.Images.SetKeyName(10, "pic11.JPG");
            this.BigPicList.Images.SetKeyName(11, "pic12.jpg");
            this.BigPicList.Images.SetKeyName(12, "pic13.jpg");
            // 
            // gallery_big
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 547);
            this.Controls.Add(this.bigImageBackBT);
            this.Controls.Add(this.bigImageNextBT);
            this.Controls.Add(this.BigGalPicPB);
            this.Name = "gallery_big";
            this.Text = "gallery_big";
            ((System.ComponentModel.ISupportInitialize)(this.BigGalPicPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BigGalPicPB;
        private System.Windows.Forms.Button bigImageNextBT;
        private System.Windows.Forms.Button bigImageBackBT;
        private System.Windows.Forms.ImageList BigPicList;
    }
}