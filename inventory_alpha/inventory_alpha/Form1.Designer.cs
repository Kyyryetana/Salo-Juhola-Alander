namespace inventory_alpha
{
    partial class Form1
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
            this.invetory = new System.Windows.Forms.PictureBox();
            this.tavara1 = new System.Windows.Forms.PictureBox();
            this.tavara2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.invetory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tavara1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tavara2)).BeginInit();
            this.SuspendLayout();
            // 
            // invetory
            // 
            this.invetory.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.invetory.Location = new System.Drawing.Point(-1, 396);
            this.invetory.Name = "invetory";
            this.invetory.Size = new System.Drawing.Size(802, 60);
            this.invetory.TabIndex = 0;
            this.invetory.TabStop = false;
            // 
            // tavara1
            // 
            this.tavara1.Image = global::inventory_alpha.Properties.Resources.tool1;
            this.tavara1.Location = new System.Drawing.Point(119, 124);
            this.tavara1.Name = "tavara1";
            this.tavara1.Size = new System.Drawing.Size(39, 40);
            this.tavara1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tavara1.TabIndex = 1;
            this.tavara1.TabStop = false;
            this.tavara1.Click += new System.EventHandler(this.tavarat_Click);
            // 
            // tavara2
            // 
            this.tavara2.Image = global::inventory_alpha.Properties.Resources.tool2;
            this.tavara2.Location = new System.Drawing.Point(348, 116);
            this.tavara2.Name = "tavara2";
            this.tavara2.Size = new System.Drawing.Size(124, 97);
            this.tavara2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tavara2.TabIndex = 2;
            this.tavara2.TabStop = false;
            this.tavara2.Click += new System.EventHandler(this.tavarat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tavara2);
            this.Controls.Add(this.tavara1);
            this.Controls.Add(this.invetory);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.invetory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tavara1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tavara2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox invetory;
        private System.Windows.Forms.PictureBox tavara1;
        private System.Windows.Forms.PictureBox tavara2;
    }
}

