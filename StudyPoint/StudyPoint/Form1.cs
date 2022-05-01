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
        USERS users = new USERS();
        FEEDBACK feedback = new FEEDBACK();
        string loggedUser = "";
        bool admin = false;
        public StudyPointForm()
        {
            InitializeComponent();
            UserManPL.Visible = true; // ohjelman latautuessa home-sivu näkyy ensimmäisenä
            tarkistaNewThing(); // tarkistaa home sivulla olevan whats new tilanteen
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

        private void newUserLB_Click(object sender, EventArgs e)
        {
            registrationPL.Visible = true;
        }

        //Sisään kirjautuminen
        private void loginBT_Click(object sender, EventArgs e)
        {
            
            string email = loginMailTB.Text;
            string pass = loginPassTB.Text;
            
            
            if (loggedUser == "")
            {
                
                loggedUser = users.CheckPassword(email, pass);
                if (loggedUser != "")
                {
                    loginPL.Visible = false;
                    loginRegBT.Text=LOGIN.loggedInStatus;
                    admin = users.checkAdmin(email);
                }
                
            }
            else
            {
                loginRegBT.Text = LOGIN.loggedOutStatus;
                loggedUser = "";
            }
        }

        //Uuden käyttäjän rekisteröinnin nappi
        private void RegBT_Click(object sender, EventArgs e)
        {

            tarkistaReg();
            
        }

        //login / logout nappulan toiminta
        private void loginRegBT_Click(object sender, EventArgs e)
        {
            if (loggedUser == "")
            {
                loginPL.Visible=true;
            }
            else
            {
                loginRegBT.Text = LOGIN.loggedOutStatus;
                loggedUser = "";
            }
            
            
        }

        //Metodi Uuden käyttäjän rekisteröintiin
        public void tarkistaReg()
        {
            string enimi = regNimiTB.Text;
            string snimi = regSukunimiTB.Text;
            string mail = regMailTB.Text;
            string password = regpass1TB.Text;
            string password2 = regPass2TB.Text;
            bool status = Registration.tarkistaReg(enimi, snimi, mail, password, password2);
            if (status)
            {
                registrationPL.Visible = false;
            }
            else
            {
                registrationPL.Visible = true;
            }

        }

        //rekisteröinti lomakkeesta poistuminen
        private void regExitBT_Click(object sender, EventArgs e)
        {
            registrationPL.Visible=false;
            
        }
        private void DashboardBT_Click(object sender, EventArgs e) //dashboard esiin, home piiloon, dashboardille tiedot SQL:stä
        {
            // kesken
            // tänne sql tietojen noudot
            // rekisteröityneiden käyttäjien määrä
            // sen hetkisen käyttäjän / adminin tiedot
            DashboardPL.Visible = true;
            HomePL.Visible = false;
        }

        private void HomeBT_Click(object sender, EventArgs e) //home näkyviin, dashboard piiloon ja tarkistetaan whats new tilanne
        {
            HomePL.Visible = true;
            DashboardPL.Visible = false;
            tarkistaNewThing();
        }

        private void tarkistaNewThing() //funktio tarkistaa home sivulla olevan whats new tilanteen, ja kytkee new tekstin päälle tai pois
        {
            if (newThing1.Text == "") 
            {
                newLB1.Visible = false;
            }
            if (newThing2.Text == "")
            {
                newLB2.Visible = false;
            }
            if (newThing3.Text == "")
            {
                newLB3.Visible = false;
            }
            if (newThing4.Text == "")
            {
                newLB4.Visible = false;
            }
            if (newThing5.Text == "")
            {
                newLB5.Visible = false;
            }
        }
        // FEEDBACK-SIVU
       

        private void FeedbackBT_Click_1(object sender, EventArgs e)
        {
            HomePL.Visible = false;
            FeedbackPL.Visible = true;

        }

        private void EmptyFBBT_Click_1(object sender, EventArgs e) // tyhjennys-painike
        {
            FeedbackTB.Text = "";
        }

        private void SendFBBT_Click_1(object sender, EventArgs e) // lähetys-painike
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

        private void FeedbackManBT_Click_1(object sender, EventArgs e) // tuodaan sivu näkyviin nappia painamalla
        {
            FeedBackManPL.Visible = true;
            FeedbackPL.Visible = false;
            HomePL.Visible=false;

            FBManDG.DataSource = feedback.GetFeedback();
            FBManDG.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            var datagridview = new DataGridView();
            datagridview.RowTemplate.MinimumHeight = 125;
        }

        

        private void FBManDG_CellContentClick_1(object sender, DataGridViewCellEventArgs e) // taulukkoa klikatessa tiedot tulevat textboxeihin
        {
            FBManNameTB.Text = FBManDG.CurrentRow.Cells[0].Value.ToString();
            FBManEmailTB.Text = FBManDG.CurrentRow.Cells[1].Value.ToString();
            FBManTB.Text = FBManDG.CurrentRow.Cells[2].Value.ToString();
        }

        private void FBDeleteBT_Click_1(object sender, EventArgs e) // poista palaute -painike
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

        // USER MANAGEMENT -SIVU
        private void UserManBT_Click_1(object sender, EventArgs e)
        {
            HomePL.Visible = false;
            UserManPL.Visible = true;


            UserDTG.DataSource = users.GetUsers();
            UserDTG.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            var datagridview = new DataGridView();
            datagridview.RowTemplate.MinimumHeight = 125;
        }
        private void UserManEmptyBT_Click(object sender, EventArgs e)
        {
            UIDTB.Text = "";
            UserManFirstnameTB.Text = "";
            UserManLastnameTB.Text = "";
            UserManEmailTB.Text = "";
            UserManAdminTB.Text = "";
        }

        private void UserManUpdateBT_Click(object sender, EventArgs e)
        {
            int UserId = Int32.Parse(UIDTB.Text);
            String enimi = UserManFirstnameTB.Text;
            String snimi = UserManLastnameTB.Text;
            String email = UserManEmailTB.Text;

            Boolean EditUser = users.EditUser(enimi, snimi, email, UserId);
            if (EditUser)
            {
                MessageBox.Show("Updated succesfully!");
            }
            else
            {
                MessageBox.Show("Error!");
            }

            UserDTG.DataSource = users.GetUsers();
        }

        private void UserDTG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UserManEmailTB.Text = UserDTG.CurrentRow.Cells[0].Value.ToString();
            UserManFirstnameTB.Text = UserDTG.CurrentRow.Cells[1].Value.ToString();
            UserManLastnameTB.Text = UserDTG.CurrentRow.Cells[2].Value.ToString();
            UIDTB.Text = UserDTG.CurrentRow.Cells[3].Value.ToString();
            UserManAdminTB.Text = UserDTG.CurrentRow.Cells[4].Value.ToString();

        }

        private void UserManDeleteBT_Click(object sender, EventArgs e)
        {
            int userID = Int32.Parse(UIDTB.Text);

            if (users.DeleteUser(userID))
            {
                UserDTG.DataSource = users.GetUsers();
                MessageBox.Show("User deleted succesfully");
            }
            else
            {
                MessageBox.Show("ERROR! Couldn't delete the user");
            }
            UserManEmptyBT.PerformClick();

        }
    }
}
    

