using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace StudyPoint
{
    public static class Registration
    {
        
        public static bool tarkistaReg(string nimi, string sukunimi, string email, string regPass1, string regPass2)
        {
            string enimi = nimi;
            string snimi = sukunimi;
            string mail = email;
            string password = regPass1;
            string password2 = regPass2;
            
            USERS users = new USERS();
            if (enimi.Trim().Equals("") || snimi.Trim().Equals("") || mail.Trim().Equals("") || password.Trim().Equals("") || password2.Trim().Equals(""))
            {
                MessageBox.Show("Kaikki vaaditut kentät tulee olla täytettyinä.");
                return false;
            }
            else if (RegCheck(enimi,snimi,mail) == false)
            {
                return false;
            }
            
            else if (password != password2)
            {
                MessageBox.Show("Salasanat eivät täsmää.");
                return false;
            }
            else if (password.Length < 5)
            {
                MessageBox.Show("salasana on liian lyhyt.");
                return false;
            }
            else if (users.CheckUser(email))
            {

                MessageBox.Show("Käyttäjätunnus on jo olemassa.");
                return false;
            }
            else
            {
                USERS user = new USERS();
                return user.AddUser(enimi, snimi, mail, password);

            }



        }


        //regex tarkistaa tiedot
        public static bool  RegCheck(string name, string lastname, string email)
        {
            //string emailPattern = "^[a-zA-Z0-9\._-]{5,25}.@.[a-z]{2,12}.(com|org|co\.in|net|fi)";
            string emailPattern2 = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                + "@"
                + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
            Regex emailReg = new Regex(emailPattern2);
            string namePattern = @"^[a-zA-Z]+[-|\s]?[a-zA-Z]+[\s|-]?[a-zA-Z]+$";
            Regex nameReg = new Regex(namePattern);
            
            if (emailReg.IsMatch(email) == false)
            {
                MessageBox.Show("sähköposti osoite ei ole sallittua muotoa");
                return false;
            }
            else if (nameReg.IsMatch(name) == false)
            {
                MessageBox.Show("nimi ei ole halutussa muodossa");
                return false;
            }
            else if (nameReg.IsMatch(lastname) == false)
            {
                MessageBox.Show("sukunimi ei ole halutussa muodossa");
                return false;
            }
            else
            {
                return true;
            }
        }


        public static bool checkPass(string email)
        {
            string emailPattern2 = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
               + "@"
               + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
            Regex emailReg = new Regex(emailPattern2);
            if (emailReg.IsMatch(email) == false)
            {
                MessageBox.Show("sähköposti osoite ei ole sallittua muotoa");
                return false;
            }
            return true;
        }
    }
}
