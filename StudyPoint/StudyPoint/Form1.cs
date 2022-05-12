using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eramake;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.IO;

namespace StudyPoint
{
    public partial class StudyPointForm : Form
    {
        DISCUSSION discussion = new DISCUSSION();
        USERS users = new USERS();
        FEEDBACK feedback = new FEEDBACK();
        WHATSNEW whatsnew = new WHATSNEW();
        PROFILE profile = new PROFILE();
        DOWNLOADS downloads = new DOWNLOADS();
        Crypting crypting = new Crypting();
        string loggedUser = "";
        bool admin = false;
        string imgLocation = "";
        public StudyPointForm()
        {
            InitializeComponent();
            HideAllPanels();
            //HomePL.Visible = true; // ohjelman latautuessa home-sivu näkyy ensimmäisenä
            WhatsNewManPL.Visible = true;
            if (loggedUser == "")
            {   newThing1.Visible = true;
                newThing1.Text = "Register or login to see new things";
            }
        }

  
        private void AboutBT_MouseHover(object sender, EventArgs e) // kun hiiri menee about-painikkeen päälle, alisivut näkyvät
        {
            AboutPL.Visible = true;
            UsBT.Visible = true;
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
                    ProfileBT.Visible = true;
                    loginPL.Visible = false;
                    loginRegBT.Text=LOGIN.loggedInStatus;
                    admin = users.checkAdmin(email);
                    loginMailTB.Text = "";
                    loginPassTB.Text = "";

                    if (admin)
                    {
                        ManagementBT.Visible = true;
                    }
                    
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
                ProfileBT.Visible = false;
                ManagementBT.Visible = false;
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

        // DASHBOARD

        private void DashboardBT_Click(object sender, EventArgs e) // panelit piiloon, dashboard esiin, tarkistaa käyttäjän, tarkistaa onko admin
        {
            HideAllPanels();
            DashboardPL.Visible = true;
            
            if (loggedUser == "")
            {
                adminOrNormalLB.Text = "Register or login";
                thisUserLB.Text = "Visitor";
            }
            else
            {
                thisUserLB.Text = loggedUser;

                if (admin == true)
                {
                    adminOrNormalLB.Text = "ADMIN";
                }
                else
                {
                    adminOrNormalLB.Text = "NORMAL USER";
                }
            }    
            dashboardRefreshDataBT.PerformClick();
        }

        private void dashboardRefreshDataBT_Click(object sender, EventArgs e)
        {
            string str = @"datasource=localhost; port=3306;username=root;password=;database=" + "studypoint" + ";SSL Mode = None";
            MySqlConnection con = new MySqlConnection(str);
            MySqlCommand cmd;

            string query = "SELECT COUNT(kID) FROM kayttajat";

            try
            {
                con.Open();

                cmd = new MySqlCommand(query, con);

                Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();

                regUserNumberLB.Text = rows_count.ToString();
                regUserNumberLB.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // DASHBOARD LOPPU
        // HOME SIVU

        private void HomeBT_Click(object sender, EventArgs e) // Panelit piiloon, home näkyviin, tarkista uudet tiedot
        {
            HideAllPanels();
            HomePL.Visible = true;
            if(loggedUser != "")
            {
                if (whatsNewManageDG.Rows.Count >= 6)
                {
                    newThing1.Text = whatsNewManageDG.Rows[0].Cells[0].Value as string;
                    newThing2.Text = whatsNewManageDG.Rows[1].Cells[0].Value as string;
                    newThing3.Text = whatsNewManageDG.Rows[2].Cells[0].Value as string;
                    newThing4.Text = whatsNewManageDG.Rows[3].Cells[0].Value as string;
                    newThing5.Text = whatsNewManageDG.Rows[4].Cells[0].Value as string;
                    newLB1.Visible = true;
                    newLB2.Visible = true;
                    newLB3.Visible = true;
                    newLB4.Visible = true;
                    newLB5.Visible = true;

                }
                if (whatsNewManageDG.Rows.Count == 5)
                {
                    newThing1.Text = whatsNewManageDG.Rows[0].Cells[0].Value as string;
                    newThing2.Text = whatsNewManageDG.Rows[1].Cells[0].Value as string;
                    newThing3.Text = whatsNewManageDG.Rows[2].Cells[0].Value as string;
                    newThing4.Text = whatsNewManageDG.Rows[3].Cells[0].Value as string;
                    newLB1.Visible = true;
                    newLB2.Visible = true;
                    newLB3.Visible = true;
                    newLB4.Visible = true;

                }
                if (whatsNewManageDG.Rows.Count == 4)
                {
                    newThing1.Text = whatsNewManageDG.Rows[0].Cells[0].Value as string;
                    newThing2.Text = whatsNewManageDG.Rows[1].Cells[0].Value as string;
                    newThing3.Text = whatsNewManageDG.Rows[2].Cells[0].Value as string;
                    newLB1.Visible = true;
                    newLB2.Visible = true;
                    newLB3.Visible = true;
                }
                if (whatsNewManageDG.Rows.Count == 3)
                {
                    newThing1.Text = whatsNewManageDG.Rows[0].Cells[0].Value as string;
                    newThing2.Text = whatsNewManageDG.Rows[1].Cells[0].Value as string;
                    newLB1.Visible = true;
                    newLB2.Visible = true;
                }
                if (whatsNewManageDG.Rows.Count == 2)
                {
                    newThing1.Text = whatsNewManageDG.Rows[0].Cells[0].Value as string;
                    newLB1.Visible = true;
                }
                if (whatsNewManageDG.Rows.Count == 1)
                {
                    newThing1.Text = "We dont have any new things to share \n right now";
                }
            }
            
            
        }

        // HOME SIVU LOPPU

        // FEEDBACK START
        private void FeedbackBT_Click_1(object sender, EventArgs e)
        {
            HideAllPanels();
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
        // FEEDBACK END

      

        // FEEDBACK MANAGEMENT START

        private void FeedbackManBT_Click_1(object sender, EventArgs e) // tuodaan sivu näkyviin nappia painamalla
        {
            HideAllPanels();
            FeedBackManPL.Visible = true;
            FeedbackPL.Visible = false;

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
            HideAllPanels();
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
            try
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
            catch
            {
                MessageBox.Show("Select the user first!");
            }
        }

      

        private void UserManUpdateBT_Click_1(object sender, EventArgs e)
        {
            try
            {
            int UserId = Int32.Parse(UIDTB.Text);
            String enimi = UserManFirstnameTB.Text;
            String snimi = UserManLastnameTB.Text;
            String email = UserManEmailTB.Text;
            int admin = Int32.Parse(UserManAdminTB.Text);

            
            if (enimi.Trim().Equals("") || snimi.Trim().Equals("") || email.Trim().Equals(""))
            {
                MessageBox.Show("ERROR! Fill firstname, lastname and email to proceed");
            }
            else
            {
                Boolean SaveUser = users.EditUser(enimi, snimi, email, UserId);

                if (SaveUser)
                {
                    MessageBox.Show("User information saved succesfully!");
                }
                else
                {
                    MessageBox.Show("Error. Couldn't update the user information");
                }
                UserDTG.DataSource = users.GetUsers();

            }
            }
            catch
            {
                MessageBox.Show("Select the user first!");
            }
        }

      

        // FEEDBACK MANAGEMENT END
        

        // PROFIILI START
        private void ProfileBT_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ProfilePL.Visible = true;
            string email = loggedUser;

            ProfilePL.Visible = true;
            ProfileFirstname.Visible = true;
            ProfileLastname.Visible = true;
            ProfileEmail.Visible = true;

            ProfileDTG.DataSource = profile.GetProfile(email);
            var datagridview = new DataGridView();

            ProfileFirstname.Text = ProfileDTG.CurrentRow.Cells[1].Value.ToString();
            ProfileLastname.Text = ProfileDTG.CurrentRow.Cells[2].Value.ToString();
            ProfileEmail.Text = ProfileDTG.CurrentRow.Cells[0].Value.ToString();

            ProfileDTG.Visible = false;
            ChangePWPanel.Visible = false;
            ProfileUpdatePL.Visible = false;    

        }
        private void ProfileUpdateBT_Click(object sender, EventArgs e)
        {
            ProfileUpdatePL.Visible = true;
           
            UpdateFNameTB.Text = ProfileDTG.CurrentRow.Cells[1].Value.ToString();
            UpdateLNameTB.Text = ProfileDTG.CurrentRow.Cells[2].Value.ToString();
            UpdateEmailTB.Text = ProfileDTG.CurrentRow.Cells[0].Value.ToString();
        }
        private void UpdateUpdateBT_Click(object sender, EventArgs e)
        {
            String Fname = UpdateFNameTB.Text;
            String Lname = UpdateLNameTB.Text;
            String Email = UpdateEmailTB.Text;

            Boolean UpdateProfile = profile.UpdateProfile(Email,Fname,Lname);

        }
        private void UpdateCloseBT_Click(object sender, EventArgs e)
        {
            ProfileUpdatePL.Visible=false;

            string email = loggedUser;


            ProfileDTG.DataSource = profile.GetProfile(email);
            var datagridview = new DataGridView();

            ProfileFirstname.Text = ProfileDTG.CurrentRow.Cells[1].Value.ToString();
            ProfileLastname.Text = ProfileDTG.CurrentRow.Cells[2].Value.ToString();
            ProfileEmail.Text = ProfileDTG.CurrentRow.Cells[0].Value.ToString();

            ProfileDTG.Visible = false;
        }

        // SALASANAN VAIHTO 
        private void ProfilePasswordBT_Click(object sender, EventArgs e) // avaa salasanan vaihto ikkunan
        {
            ChangePWPanel.Visible = true;
            ChangePWDTG.Visible = false;

            string email = loggedUser; // sisäänkirjautuneen henkilön sähköposti

            String CurrentPW = CurrentPWTB.Text; // nykyinen salasana
            ChangePWDTG.DataSource = profile.OldPassword(email, CurrentPW); // datagrid näyttää sähköpostin ja nykyisen salasanan
            var datagridview = new DataGridView(); // tuodaan tiedot datagridiin
        }

        private void ChangePWBT_Click(object sender, EventArgs e) // vaihtaa salasanan
        {
            string email = loggedUser; // sisäänkirjautuneen henkilön sähköposti

            String CurrentPW = CurrentPWTB.Text; // nykyinen salasana
            String Pword = NewPWTB.Text; // uusi salasana
            String PwordAgain = NewPWAgainTB.Text; // uusi salasana uudelleen

            ChangePWDTG.DataSource = profile.OldPassword(email, CurrentPW); // datagrid näyttää sähköpostin ja nykyisen salasanan
            string CheckPw = ChangePWDTG.CurrentRow.Cells[1].Value.ToString(); // tallennetaan muuttujaan nykyinen salasana tietokannasta
            CheckPw = crypting.Decrypt(CheckPw);
            if (CurrentPW == "" || Pword == "" || PwordAgain == "")
            {
                MessageBox.Show("Give your old and new password!");
            }
            else
            {
                if (CurrentPW == CheckPw && Pword == PwordAgain) // tarkistetaan, onko nykyinen syötetty salasana sama kuin tietokannasta saatu salasana
                {
                    Pword = crypting.Encrypt(NewPWTB.Text); // cryptataan uusi salasana
                    Boolean UpdatePassword = profile.UpdatePassword(email, Pword); // päivitetään salasana sähköpostin perusteella
                    ChangePWDTG.Visible = false;
                }
                else
                {
                    MessageBox.Show("Check your password!");
                    ChangePWDTG.Visible = false;
                }
            }

            CurrentPWTB.Text = "";
            NewPWTB.Text = "";
            NewPWAgainTB.Text = "";

           
        }
        private void ChangePWCloseBT_Click(object sender, EventArgs e) // sulkee salasanan vaihto ikkunan
        {
            ChangePWPanel.Visible = false;
            
        }

        // PROFIILI END






        //discussion board
        //begin
        //
        int discTopicNmbr = 0, discCommentnbr = 1 ;
        //discussion main topic start
        private void discGroupGB_Enter(object sender, EventArgs e)
        {

        }

        private void discnextBT_Click(object sender, EventArgs e)
        {
            discTopicNmbr += 7;
            DiscussionCall();
            if(discTopicLB7.Text == "")
            {
                discnextBT.Enabled = false;
            }
        }

        private void discNewBT_Click(object sender, EventArgs e)
        {
            if (loggedUser == "")
            {
                MessageBox.Show("You have to logged in before posting comment");
            }
            else
            {
                discussionWriteTopicPL.Visible = true;
            }
                
        }

        private void discPrevBT_Click(object sender, EventArgs e)
        {
            if (discTopicNmbr >0)
            {
                discTopicNmbr -= 7;
                DiscussionCall();
                discnextBT.Enabled=true;
            }
                
        }

        private void discTopicLB1_Click(object sender, EventArgs e)
        {
            DiscussionPL.Visible = true;
            discCommentnbr = 1;
            topicLB.Text = discTopicLB1.Text;
            ReadTopic();
            
            
            
        }

        private void discTopicLB2_Click(object sender, EventArgs e)
        {
            DiscussionPL.Visible = true;
            discCommentnbr = 1;
            topicLB.Text = discTopicLB2.Text;
            ReadTopic();
        }

        private void discTopicLB3_Click(object sender, EventArgs e)
        {
            DiscussionPL.Visible = true;
            discCommentnbr = 1;
            topicLB.Text = discTopicLB3.Text;
            ReadTopic();
        }

        private void discTopicLB4_Click(object sender, EventArgs e)
        {
            DiscussionPL.Visible = true;
            discCommentnbr = 1;
            topicLB.Text = discTopicLB4.Text;
            ReadTopic();
        }

        private void discTopicLB5_Click(object sender, EventArgs e)
        {
            DiscussionPL.Visible = true;
            discCommentnbr = 1;
            topicLB.Text = discTopicLB5.Text;
            ReadTopic();
        }

        private void discTopicLB6_Click(object sender, EventArgs e)
        {
            DiscussionPL.Visible = true;
            discCommentnbr = 1;
            topicLB.Text = discTopicLB6.Text;
            ReadTopic();
        }

        private void discTopicLB7_Click(object sender, EventArgs e)
        {
            DiscussionPL.Visible = true;
            discCommentnbr = 1;
            topicLB.Text = discTopicLB7.Text;
            ReadTopic();
        }

        private void ReadTopic()
        {
            if (discCommentnbr == 1)
            {
                discussionTopicPrevBT.Enabled = false;
            }
            GroupBox[] groupBoxes = { discussionUserGB1, discussionUserGB2, discussionUserGB3 };
            //Label[] labelsComments = { discussionTextLB1, discussionTextLB2, discussionTextLB3 };
            RichTextBox[] textBoxComments = {commentBetaTB1, commentBetaTB2, commentBetaTB3 };
            List<string> list = new List<string>();
            list = discussion.GiveDiscussion(discussion.DiscRegex(topicLB.Text), discCommentnbr);
            int place = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if ( i % 2 == 0)
                {
                    groupBoxes[place].Text = list[i];
                    
                }
                else
                {
                    textBoxComments[place].Text = list[i];
                    place++;
                }
                
                //MessageBox.Show(list[i]);
            }
             

        }
        //discussion main topic end

        //discussion read topic
        //begin

        private void discussionTopicPrevBT_Click(object sender, EventArgs e)
        {
            //edelliset kommentit tästä
            discCommentnbr -= 3;
            ReadTopic();
            discussionTopicNextBT.Enabled = true;
            
        }

        private void discussionBackMainBT_Click(object sender, EventArgs e)
        {
            DiscussionPL.Visible = false;

        }

        private void discussionAnswerBT_Click(object sender, EventArgs e)
        {
            if(loggedUser == "")
            {
                MessageBox.Show("You have to logged in before posting comment");
            }
            else
            {
                discussionAswerPL.Visible = true;
                discAnswertopicLB.Text = topicLB.Text;
            }
            
            
        }

        private void discussionTopicNextBT_Click(object sender, EventArgs e)
        {
            //seuraavat kommentit tästä
            discCommentnbr += 3;
            ReadTopic();
            discussionTopicPrevBT.Enabled = true;
            if (discussionUserGB3.Text == "")
            {
                discussionTopicNextBT.Enabled = false;
            }
        }



        //discussion read topic end

        //discussion write answer begin
       

        private void discAnswerBackBT_Click(object sender, EventArgs e)
        {
            discussionAswerPL.Visible = false;
        }

        private void discAnswerSendBT_Click(object sender, EventArgs e)
        {
            if (discAnswerTB.Text.Trim().Equals("")) 
            {
                MessageBox.Show("All fields must be filled");
            }
            else
            {
                if (discussion.AddTopicText(loggedUser, discussion.DiscRegex(discAnswertopicLB.Text), discAnswerTB.Text) == true)
                {
                    ReadTopic();
                    discussionAswerPL.Visible = true;
                    discAnswerTB.Text = "";

                }
            }
            
            
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
            if (topic.Trim().Equals("") || text.Trim().Equals(""))
            {
                MessageBox.Show("All fields must be filled");
            }
            else
            {
                discussion.AddTopic(topic);
                discussion.AddTopicText(loggedUser, topic, text);
                DiscussionCall();
                discussionWriteTopicPL.Visible = false;
                discNewTopicNameTB.Text = "";
                discNewTopicWriteTB.Text = "";
            }
            
             
            
            
            
        }



        //discussion write new topic end

        //menu discussion boad
        private void DiscussionBT_Click(object sender, EventArgs e)
        {
            discTopicNmbr =0;
            discnextBT.Enabled = true;
            DiscussionCall();

            
        }

        private void DiscussionCall()
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

        //menu discussion board


        private void HideAllPanels()
        {
            HomePL.Visible = false;
            DashboardPL.Visible = false;

            AboutPL.Visible = false;
            AboutUsPL.Visible = false;
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


        //discussion board
        //end


        // WHATS NEW MANAGEMENT SIVU

        private void addNewThingBT_Click(object sender, EventArgs e)
        {
            String asia = addNewThingTB.Text;

            Boolean AddNewThing = whatsnew.AddNewThing(asia);

            addNewThingTB.Text = "";

            refreshNewThingBT.PerformClick();
        }

        private void emptyNewThingBT_Click(object sender, EventArgs e)
        {
            addNewThingTB.Text = "";
        }

        private void refreshNewThingBT_Click(object sender, EventArgs e)
        {
            whatsNewManageDG.DataSource = whatsnew.GetNewThings();
            whatsNewManageDG.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            var datagridview = new DataGridView();
            datagridview.RowTemplate.MinimumHeight = 125;
        }

        private void removeNewThingBT_Click(object sender, EventArgs e)
        {
            string newThings = addNewThingTB.Text;
            if (whatsnew.DeleteNewThing(newThings))
            {
                whatsNewManageDG.DataSource = whatsnew.GetNewThings();
                MessageBox.Show(newThings + " deleted successfully");
            }
            else
            {
                MessageBox.Show("Could not delete the " + newThings);
            }
            addNewThingTB.Text = "";
        }

        private void whatsNewManageDG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            addNewThingTB.Text = whatsNewManageDG.CurrentRow.Cells[0].Value.ToString();
        }

        // WHATS NEW MANAGEMENT SIVU LOPPU
        //DOWNLOAD MANAGEMENT SIVU

        private void downloadMGbrowseBT_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog avaa = new OpenFileDialog();
                avaa.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
                avaa.Title = "Select picture";
                if (avaa.ShowDialog() == DialogResult.OK)
                {
                    imgLocation = avaa.FileName.ToString();
                    downloadMGPB.ImageLocation = imgLocation;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void downloadMGclearBT_Click(object sender, EventArgs e)
        {
            downloadMGPB.Image = null;
        }

        private void downloadMGsendSqlBT_Click(object sender, EventArgs e)
        {
            downloads.SendImgToSql(imgLocation);
            downloadMGPB.Image = null;
            downloadMGrefreshBT.PerformClick();
        }

        private void downloadMGrefreshBT_Click(object sender, EventArgs e)
        {
            downloadMGDGW.DataSource = downloads.FetchImagesFromSql();
            downloadMGDGW.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            var datagridview = new DataGridView();
            datagridview.RowTemplate.MinimumHeight = 125;
            downloadMGTB.Text = "";
        }

        private void downloadMGdeleteBT_Click(object sender, EventArgs e)
        {
            string picture = downloadMGTB.Text;
            if (downloads.deleteImgFromSql(picture))
            {
                downloadMGDGW.DataSource = downloads.FetchImagesFromSql();
                MessageBox.Show("Picture deleted successfully");
            }
            else
            {
                MessageBox.Show("Could not delete the picture");
            }
            downloadMGTB.Text = "";
        }

        private void downloadMGDGW_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            downloadMGTB.Text = downloadMGDGW.CurrentRow.Cells[1].Value.ToString();
        }

        private void downloadMGviewBT_Click(object sender, EventArgs e)
        {
            // TÄMÄ ON TEKEMÄTTÄ
        }

        private void NewManBT_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            WhatsNewManPL.Visible = true;
            refreshNewThingBT.PerformClick();
        }

        private void DownloadManBT_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            DownloadManPL.Visible = true;
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

       

        private void ContactBT_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ContactUsPL.Visible = true;
        }

        private void DownloadBT_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            DownloadPL.Visible = true;
        }

        private void OurGalleryPL_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void UsBT_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            AboutUsPL.Visible=true;
        }

        private void ContactLinkLB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HideAllPanels();
            FeedbackPL.Visible = true;
        }

        // DOWNLOAD MANAGEMENT SIVU LOPPU

        //gallery start here
        private void galleryPB1_Click(object sender, EventArgs e)
        {
            CallingBigPic(0);


        }
        private void galleryPB2_Click(object sender, EventArgs e)
        {
            CallingBigPic(1);
        }
        
        private void galleryPB3_Click(object sender, EventArgs e)
        {
            CallingBigPic(2);
        }
        private void galleryPB4_Click(object sender, EventArgs e)
        {
            CallingBigPic(3);
        }

        private void galleryPB5_Click(object sender, EventArgs e)
        {
            CallingBigPic(4);
        }

        private void galleryPB6_Click(object sender, EventArgs e)
        {
            CallingBigPic(5);
        }

        private void galleryPB7_Click(object sender, EventArgs e)
        {
            CallingBigPic(6);
        }

        private void galleryPB8_Click(object sender, EventArgs e)
        {
            CallingBigPic(7);
        }

        private void galleryPB9_Click(object sender, EventArgs e)
        {
            CallingBigPic(8);
        }

        private void galleryPB10_Click(object sender, EventArgs e)
        {
            CallingBigPic(9);
        }

        private void galleryPB11_Click(object sender, EventArgs e)
        {
            CallingBigPic(10);
        }

     

        private void galleryPB12_Click(object sender, EventArgs e)
        {
            CallingBigPic(11);
        }

        

        //calling second form
        private void CallingBigPic(int number)
        {
            var bigGallery = new gallery_big();
            gallery_big.Number = number;
            bigGallery.Show();
            bigGallery.ShowBigPic(number);


        }
        //calling second form end

        //gallery end here
        //







    }
}
    

