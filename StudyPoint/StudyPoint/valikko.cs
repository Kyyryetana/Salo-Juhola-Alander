using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudyPoint
{
    public partial class StudyPointForm : Form
    {
        private void HomeBT_Click(object sender, EventArgs e) //home näkyviin, dashboard piiloon ja tarkistetaan whats new tilanne
        {
            HideAllPanels();
            tarkistaNewThing();

            HomePL.Visible = true;
            

        }

        private void DashboardBT_Click(object sender, EventArgs e) //dashboard esiin, home piiloon, dashboardille tiedot SQL:stä
        {
            // kesken
            // tänne sql tietojen noudot
            // rekisteröityneiden käyttäjien määrä
            // sen hetkisen käyttäjän / adminin tiedot
            HideAllPanels();
            DashboardPL.Visible = true;

        }

        private void AboutBT_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            AboutPL.Visible = true;
            
        }

        private void ServicesBT_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            OurServicesPL.Visible = true;
            
        }

        private void GalleryBT_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            OurGalleryPL.Visible = true;
            
        }

        private void DepartmentBT_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            OurDepartmentPL.Visible = true;

        }
        private void DiscussionBT_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            DiscussionBoardPL.Visible = true;
            

        }

        private void DownloadBT_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            DownloadPL.Visible = true;
            
        }

        private void ContactBT_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ContactUsPL.Visible = true;

        }

        private void FeedbackBT_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            FeedbackPL.Visible = true;
        }

        private void FeedbackManBT_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            FeedBackManPL.Visible = true;
            
        }

        private void DownloadManBT_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            DownloadManPL.Visible = true;            
        }

        private void UserManBT_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            UserManPL.Visible = true;
            
        }

        private void NewManBT_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            WhatsNewManPL.Visible = true;
        }

        private void HideAllPanels()
        {
            HomePL.Visible = false;
            DashboardPL.Visible = false;

            AboutPL.Visible = false;
            OurServicesPL.Visible = false;
            OurGalleryPL.Visible = false;
            OurDepartmentPL.Visible = false;

            DiscussionBoardPL.Visible = false;
            DownloadPL.Visible = false;
            ContactUsPL.Visible = false;

            FeedbackPL.Visible = false;
            FeedBackManPL.Visible = false;
            DownloadManPL.Visible = false;
            UserManPL.Visible = false;
            WhatsNewManPL.Visible = false;
        }

    }

}