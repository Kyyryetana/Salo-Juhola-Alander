using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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

            if (enimi.Trim().Equals("") || snimi.Trim().Equals("") || mail.Trim().Equals("") || password.Trim().Equals("") || password2.Trim().Equals(""))
            {
                MessageBox.Show("Kaikki vaaditut kentät tulee olla täytettyinä");
                return false;
            }
            else if (password != password2)
            {
                MessageBox.Show("Salasanat eivät täsmää");
                return false;
            }
            else
            {
                USERS user = new USERS();
                return user.AddUser(enimi, snimi, mail, password);

            }



        }

    }
}
