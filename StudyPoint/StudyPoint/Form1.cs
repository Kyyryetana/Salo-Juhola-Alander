using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyPoint
{
    public partial class StudyPointForm : Form
    {
        public StudyPointForm()
        {
            InitializeComponent();
            HomePL.Visible = true; // ohjelman latautuessa home-sivu näkyy ensimmäisenä
        }

  
        private void AboutBT_MouseHover(object sender, EventArgs e) // kun hiiri menee about-painikkeen päälle, alisivut näkyvät
        {
            AboutPL.Visible = true;
            ServicesBT.Visible = true;
            GalleryBT.Visible = true;
            DepartmentBT.Visible = true;
        }

        private void ManagementBT_MouseHover(object sender, EventArgs e) // kun hiiri menee management-painikkeen päälle, alisivut näkyvät
        {   
            ManagementPL.Visible = true;
            FeedbackManBT.Visible = true;
            DownloadManBT.Visible = true;
            UserManBT.Visible = true;
            NewManBT.Visible = true;
        }

        private void AboutPL_MouseLeave(object sender, EventArgs e) // hiiren poistuessa aboutPL:n päältä, paneeli poistuu näkyvistä
        {
            AboutPL.Visible = false;
        }

        private void ManagementPL_MouseLeave(object sender, EventArgs e) // hiiren poistuessa ManagementPL:n päältä, paneeli poistuu näkyvistä
        {
            ManagementPL.Visible = false;
        }

        private void VasenPL_MouseHover(object sender, EventArgs e) // hiiren mennessä päävalikon paneelin kohdalle, sivuvalikot poistuvat näkyvistä
        {
            AboutPL.Visible = false;
            ManagementPL.Visible = false;
        }

        private void loginBT_Click(object sender, EventArgs e)
        {

        }
    }
}
