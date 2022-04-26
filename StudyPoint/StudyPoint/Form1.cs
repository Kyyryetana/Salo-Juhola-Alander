﻿using System;
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

        private void newUserLB_Click(object sender, EventArgs e)
        {
            registrationPL.Visible = true;
        }

        private void loginBT_Click(object sender, EventArgs e)
        {
            
            string email = loginMailTB.Text;
            string pass = loginPassTB.Text;
            bool status = users.CheckPassword(email, pass);
            if (status)
            {
                MessageBox.Show("onnistui");
                loginPL.Visible = false;
                
            }
            else 
            {
                MessageBox.Show("käyttäjätunnus ja salasana eivät täsmää");
            }
        }

        private void RegBT_Click(object sender, EventArgs e)
        {

            tarkistaReg();
            
        }

        private void loginRegBT_Click(object sender, EventArgs e)
        {
            
            loginPL.Visible=true;
        }


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

        private void regExitBT_Click(object sender, EventArgs e)
        {
            registrationPL.Visible=false;
            
        }
    }
}
