using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StudyPoint
{
    public partial class StudyPointForm : Form
    {
        FEEDBACK feedback = new FEEDBACK();

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

        private void HomeBT_Click(object sender, EventArgs e)
        {
            HomePL.Visible = true;
            FeedBackManPL.Visible = false;
        }

        // FEEDBACK-SIVU
        private void FeedbackBT_Click(object sender, EventArgs e) // sivu tulee näkyviin
        {
            FeedbackPL.Visible = true;
        }

        private void EmptyFBBT_Click(object sender, EventArgs e) // tyhjennys-painike
        {
            FeedbackTB.Text = "";
        }

        private void SendFBBT_Click(object sender, EventArgs e) // lähetys-painike
        {
            
            String name = FBNameTB.Text;
            String email = FBEmailTB.Text;
            String message = FeedbackTB.Text;

            Boolean NewFeedback = feedback.AddFeedback(name, email, message);

            FeedbackTB.Text = "";
            FBNameTB.Text = "";
            FBEmailTB.Text = "";
        }

        // FEEDBACK MANAGEMENT -SIVU

        private void FeedbackManBT_Click(object sender, EventArgs e) // tuodaan sivu näkyviin nappia painamalla
        {
            FeedBackManPL.Visible = true;
            FeedbackPL.Visible = false;
        }

        private void StudyPointForm_Load(object sender, EventArgs e) // sivuston latautuessa tuodaan tiedot esiin tietokannasta
        {
            FBManDG.DataSource = feedback.GetFeedback();
            FBManDG.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            var datagridview = new DataGridView();
            datagridview.RowTemplate.MinimumHeight = 125;
            
        }

        private void FBManDG_CellContentClick(object sender, DataGridViewCellEventArgs e) // taulukkoa klikatessa tiedot tulevat textboxeihin
        {
            FBManNameTB.Text = FBManDG.CurrentRow.Cells[0].Value.ToString();
            FBManEmailTB.Text = FBManDG.CurrentRow.Cells[1].Value.ToString();
            FBManTB.Text = FBManDG.CurrentRow.Cells[2].Value.ToString();
        }

        private void FBDeleteBT_Click(object sender, EventArgs e) // poista palaute -painike
        {
            string Message = FBManTB.Text;
            if (feedback.DeleteFeedback(Message))
            {
                FBManDG.DataSource = feedback.GetFeedback();
                MessageBox.Show("Feedback deleted");
            }
            else
            {
                MessageBox.Show("Could not delete the feedback");
            }

            FBManTB.Text = "";
            FBManNameTB.Text = "";
            FBManEmailTB.Text = "";
        }

        
    }
}
