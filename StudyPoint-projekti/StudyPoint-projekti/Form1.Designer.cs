namespace StudyPoint_projekti
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
            this.ValikkoCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AboutPL = new System.Windows.Forms.Panel();
            this.ServicesPL = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ValikkoCB
            // 
            this.ValikkoCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValikkoCB.FormattingEnabled = true;
            this.ValikkoCB.Location = new System.Drawing.Point(12, 12);
            this.ValikkoCB.Name = "ValikkoCB";
            this.ValikkoCB.Size = new System.Drawing.Size(223, 32);
            this.ValikkoCB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "ETUSIVU";
            // 
            // AboutPL
            // 
            this.AboutPL.Location = new System.Drawing.Point(356, 211);
            this.AboutPL.Name = "AboutPL";
            this.AboutPL.Size = new System.Drawing.Size(200, 100);
            this.AboutPL.TabIndex = 2;
            this.AboutPL.Visible = false;

            // 
            // ServicesPL
            // 
            this.ServicesPL.Location = new System.Drawing.Point(579, 211);
            this.ServicesPL.Name = "ServicesPL";
            this.ServicesPL.Size = new System.Drawing.Size(200, 100);
            this.ServicesPL.TabIndex = 0;
            this.ServicesPL.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 504);
            this.Controls.Add(this.ServicesPL);
            this.Controls.Add(this.AboutPL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ValikkoCB);
            this.Name = "Form1";
            this.Text = "StudyPoint - Etusivu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ValikkoCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel AboutPL;
        private System.Windows.Forms.Panel ServicesPL;
    }
}

