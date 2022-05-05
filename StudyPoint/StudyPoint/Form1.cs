using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace StudyPoint
{
    public partial class StudyPointForm : Form
    {
        DISCUSSION discussion = new DISCUSSION();
        USERS users = new USERS();
        FEEDBACK feedback = new FEEDBACK();
        string loggedUser = "";
        bool admin = false;
        public StudyPointForm()
        {
            InitializeComponent();
            HomePL.Visible = true; // ohjelman latautuessa home-sivu näkyy ensimmäisenä
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

        //kirjautuminen ja uusi käyttäjä
        //begin

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

        //sisään kirjautuminen end

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

        //kirjautuminen ja uusi käyttäjä
        //end



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

        // PROFIILI
        private void ProfileBT_Click(object sender, EventArgs e)
        {
            ProfilePL.Visible = true;
           
        }
        private void ProfileUpdateBT_Click(object sender, EventArgs e)
        {
            ProfileUpdatePL.Visible = true;
        }
        private void UpdateUpdateBT_Click(object sender, EventArgs e)
        {

        }
        private void UpdateCloseBT_Click(object sender, EventArgs e)
        {
            ProfileUpdatePL.Visible=false;
        }





        //discussion board
        //begin
        //
        int discTopicNmbr = 0, discCommentnbr = 0 ;
        //discussion main topic start
        private void discGroupGB_Enter(object sender, EventArgs e)
        {

        }

        private void discnextBT_Click(object sender, EventArgs e)
        {

        }

        private void discNewBT_Click(object sender, EventArgs e)
        {
            discussionWriteTopicPL.Visible = true;
        }

        private void discPrevBT_Click(object sender, EventArgs e)
        {

        }

        private void discTopicLB1_Click(object sender, EventArgs e)
        {
            DiscussionPL.Visible = true;
            topicLB.Text = discTopicLB1.Text;
            DiscRegex(discTopicLB1.Text);
            
        }

        private void discTopicLB2_Click(object sender, EventArgs e)
        {
            DiscussionPL.Visible = true;
        }

        private void discTopicLB3_Click(object sender, EventArgs e)
        {
            DiscussionPL.Visible = true;
        }

        private void discTopicLB4_Click(object sender, EventArgs e)
        {
            DiscussionPL.Visible = true;
        }

        private void discTopicLB5_Click(object sender, EventArgs e)
        {
            DiscussionPL.Visible = true;
        }

        private void discTopicLB6_Click(object sender, EventArgs e)
        {
            DiscussionPL.Visible = true;
        }

        private void discTopicLB7_Click(object sender, EventArgs e)
        {
            DiscussionPL.Visible = true;
        }


        //discussion main topic end

        //discussion read topic
        //begin

        private void discussionTopicPrevBT_Click(object sender, EventArgs e)
        {
            //edelliset kommentit tästä
        }

        private void discussionBackMainBT_Click(object sender, EventArgs e)
        {
            DiscussionPL.Visible = false;

        }

        private void discussionAnswerBT_Click(object sender, EventArgs e)
        {
            discussionAswerPL.Visible = true;
        }

        private void discussionTopicNextBT_Click(object sender, EventArgs e)
        {
            //seuraavat kommentit tästä
        }



        //discussion read topic end

        //discussion write answer begin
       

        private void discAnswerBackBT_Click(object sender, EventArgs e)
        {
            discussionAswerPL.Visible = false;
        }

        private void discAnswerSendBT_Click(object sender, EventArgs e)
        {
            
        }

        //discussion write answer end

        //discussion write new topic begin

        private void discNewTopicBackBT_Click(object sender, EventArgs e)
        {
            discussionWriteTopicPL.Visible = false;
        }

        private void discNewTopicSendBT_Click(object sender, EventArgs e)
        {
                   
            
            string topic = discNewTopicNameTB.Text;
            string text = discNewTopicWriteTB.Text;
            if (discussion.AddTopic(topic))
            {
                if (discussion.AddTopicText(loggedUser, topic, text))
                {
                    discNewTopicNameTB.Text = "";
                    discNewTopicWriteTB.Text = "";
                }
            }
            
            
        }



        //discussion write new topic end

        //menu discussion boad
        private void DiscussionBT_Click(object sender, EventArgs e)
        {

            Label[] labels = { discTopicLB1, discTopicLB2, discTopicLB3, discTopicLB4, discTopicLB5, discTopicLB6, discTopicLB7 };
            HideAllPanels();
            DiscussionBoardPL.Visible = true;
            List<string> diskList = new List<string>();
            diskList = discussion.MainTopic(discTopicNmbr);
            for (int i = 0; i < 7; i++)
            {
                labels[i].Text = diskList[i];
                if (diskList[i] == "")
                {
                    labels[i].Visible = false;
                }
                else
                {
                    labels[i].Visible = true;
                }
            }


            
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
            DiscussionPL.Visible = false;
            discussionAswerPL.Visible = false;
            discussionWriteTopicPL.Visible = false;

            DownloadPL.Visible = false;
            ContactUsPL.Visible = false;

            FeedbackPL.Visible = false;
            FeedBackManPL.Visible = false;
            DownloadManPL.Visible = false;
            UserManPL.Visible = false;
            WhatsNewManPL.Visible = false;

            loginPL.Visible = false;

            ProfilePL.Visible = false;
            ProfileUpdatePL.Visible = false;
        }

        private string DiscRegex(string topicName)
        {
            topicName = Regex.Replace(topicName, "\\s+", "_");
            try
            {
                topicName = topicName.Substring(0, 10);
            }
            catch (Exception ex){}

            return topicName;
        }






        //menu discussion board



        //discussion board
        //end


    }
}
    

