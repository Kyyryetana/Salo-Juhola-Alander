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
            tarkistaNewThing();

            HomePL.Visible = true;
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

        private void DashboardBT_Click(object sender, EventArgs e) //dashboard esiin, home piiloon, dashboardille tiedot SQL:stä
        {
            // kesken
            // tänne sql tietojen noudot
            // rekisteröityneiden käyttäjien määrä
            // sen hetkisen käyttäjän / adminin tiedot
            HomePL.Visible = false;
            DashboardPL.Visible = true;

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

        private void AboutBT_Click(object sender, EventArgs e)
        {
            HomePL.Visible = false;
            DashboardPL.Visible = false;

            AboutPL.Visible = true;
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

        private void ServicesBT_Click(object sender, EventArgs e)
        {
            HomePL.Visible = false;
            DashboardPL.Visible = false;

            AboutPL.Visible = false;
            OurServicesPL.Visible = true;
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

        private void GalleryBT_Click(object sender, EventArgs e)
        {
            HomePL.Visible = false;
            DashboardPL.Visible = false;

            AboutPL.Visible = false;
            OurServicesPL.Visible = false;
            OurGalleryPL.Visible = true;
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

        private void DepartmentBT_Click(object sender, EventArgs e)
        {
            HomePL.Visible = false;
            DashboardPL.Visible = false;

            AboutPL.Visible = false;
            OurServicesPL.Visible = false;
            OurGalleryPL.Visible = false;
            OurDepartmentPL.Visible = true;

            DiscussionBoardPL.Visible = false;
            DownloadPL.Visible = false;
            ContactUsPL.Visible = false;

            FeedbackPL.Visible = false;
            FeedBackManPL.Visible = false;
            DownloadManPL.Visible = false;
            UserManPL.Visible = false;
            WhatsNewManPL.Visible = false;
        }
        private void DiscussionBT_Click(object sender, EventArgs e)
        {
            HomePL.Visible = false;
            DashboardPL.Visible = false;

            AboutPL.Visible = false;
            OurServicesPL.Visible = false;
            OurGalleryPL.Visible = false;
            OurDepartmentPL.Visible = false;

            DiscussionBoardPL.Visible = true;
            DownloadPL.Visible = false;
            ContactUsPL.Visible = false;

            FeedbackPL.Visible = false;
            FeedBackManPL.Visible = false;
            DownloadManPL.Visible = false;
            UserManPL.Visible = false;
            WhatsNewManPL.Visible = false;

        }

        private void DownloadBT_Click(object sender, EventArgs e)
        {
            HomePL.Visible = false;
            DashboardPL.Visible = false;

            AboutPL.Visible = false;
            OurServicesPL.Visible = false;
            OurGalleryPL.Visible = false;
            OurDepartmentPL.Visible = false;

            DiscussionBoardPL.Visible = false;
            DownloadPL.Visible = true;
            ContactUsPL.Visible = false;

            FeedbackPL.Visible = false;
            FeedBackManPL.Visible = false;
            DownloadManPL.Visible = false;
            UserManPL.Visible = false;
            WhatsNewManPL.Visible = false;
        }

        private void ContactBT_Click(object sender, EventArgs e)
        {
            HomePL.Visible = false;
            DashboardPL.Visible = false;

            AboutPL.Visible = false;
            OurServicesPL.Visible = false;
            OurGalleryPL.Visible = false;
            OurDepartmentPL.Visible = false;

            DiscussionBoardPL.Visible = false;
            DownloadPL.Visible = false;
            ContactUsPL.Visible = true;

            FeedbackPL.Visible = false;
            FeedBackManPL.Visible = false;
            DownloadManPL.Visible = false;
            UserManPL.Visible = false;
            WhatsNewManPL.Visible = false;
        }

        private void FeedbackBT_Click(object sender, EventArgs e)
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

            FeedbackPL.Visible = true;
            FeedBackManPL.Visible = false;
            DownloadManPL.Visible = false;
            UserManPL.Visible = false;
            WhatsNewManPL.Visible = false;
        }

        private void FeedbackManBT_Click(object sender, EventArgs e)
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
            FeedBackManPL.Visible = true;
            DownloadManPL.Visible = false;
            UserManPL.Visible = false;
            WhatsNewManPL.Visible = false;
        }

        private void DownloadManBT_Click(object sender, EventArgs e)
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
            DownloadManPL.Visible = true;
            UserManPL.Visible = false;
            WhatsNewManPL.Visible = false;
        }

        private void UserManBT_Click(object sender, EventArgs e)
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
            UserManPL.Visible = true;
            WhatsNewManPL.Visible = false;
        }

        private void NewManBT_Click(object sender, EventArgs e)
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
            WhatsNewManPL.Visible = true;
        }
    }

}