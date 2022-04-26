using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyPoint
{
    internal class USERS
    {
        
        CONNECT connection = new CONNECT();
        Crypting crypting = new Crypting();

        public bool AddUser(String enimi, String snimi, String email, string password)
        {

            //String password = passwordGenerator();
            String encryptedPassword = crypting.Encrypt(password);
            MySqlCommand komento = new MySqlCommand();
            String lisayskysely = "INSERT INTO kayttajat " +
                "(etunimi, sukunimi, sahkoposti, salasana) " +
                "VALUES (@enm, @snm, @eml, @pwd ); ";
            komento.CommandText = lisayskysely;
            komento.Connection = connection.Connection();
            //@enm, @snm, @eml, @uid, @pwd
            komento.Parameters.Add("@enm", MySqlDbType.VarChar).Value = enimi;
            komento.Parameters.Add("@snm", MySqlDbType.VarChar).Value = snimi;
            komento.Parameters.Add("@eml", MySqlDbType.VarChar).Value = email;
            //komento.Parameters.Add("@kid", MySqlDbType.UInt32).Value = userId;
            komento.Parameters.Add("@pwd", MySqlDbType.VarChar).Value =  encryptedPassword;
            MessageBox.Show("Käyttäjätunnuksesi on " + email );

            connection.OpenConnection();
            if (komento.ExecuteNonQuery() == 1)
            {
                connection.CloseConnection();
                return true;
            }
            else
            {
                connection.CloseConnection();
                return false;
            }
        }


        //tarkistetaan käyttäjä ja salasana
        public bool CheckPassword(string email, string password)
        {
            password = password.Trim();
            password = crypting.Encrypt(password);
            connection.OpenConnection();
            MySqlCommand komento = new MySqlCommand("SELECT salasana FROM kayttajat WHERE sahkoposti = '" + email + "'"   , connection.Connection());
            
            var sana = (string) komento.ExecuteScalar();
            connection.CloseConnection();
            
            if (sana == password)
            {
                return true;
            }
            else
            {
                return false;
            }
            
            
        }

        //tarkistaa onko jo käyttäjä olemassa
        public bool CheckUser(string email)
        {
            
            connection.OpenConnection();
            MySqlCommand komento = new MySqlCommand("SELECT sahkoposti FROM kayttajat WHERE sahkoposti = '" + email + "'", connection.Connection());

            var sana = (string)komento.ExecuteScalar();
            connection.CloseConnection();

            if (sana == email)
            {
                return true;
            }
            else
            {
                return false;
            }


        }




        // Luodaan funktio käyttäjän tietojen muokkaamiseksi
        public bool EditUser(String enimi, String snimi, String email, int UserId)
        {
            MySqlCommand komento = new MySqlCommand();
            String paivityskysely = "UPDATE `yhteystiedot` SET `etunimi`= @enm," +
                "`sukunimi`= @snm,`sahkoposti`= @eml,`userid`= @" +
                " WHERE userid = @uid";
            komento.CommandText = paivityskysely;
            komento.Connection = connection.Connection();
            //@enm, @snm, @eml, @uid
            komento.Parameters.Add("@enm", MySqlDbType.VarChar).Value = enimi;
            komento.Parameters.Add("@snm", MySqlDbType.VarChar).Value = snimi;
            komento.Parameters.Add("@eml", MySqlDbType.VarChar).Value = email;
            komento.Parameters.Add("@uid", MySqlDbType.UInt32).Value = UserId;






            connection.OpenConnection();
            if (komento.ExecuteNonQuery() == 1)
            {
                connection.CloseConnection();
                return true;
            }
            else
            {
                connection.CloseConnection();
                return false;
            }
        }

        // Luodaan funktio käyttäjän tietojen poistamiseen
        // tähän tarvitaan vain käyttäjätunnus
        public bool DeleteUser(int userId)
        {
            MySqlCommand komento = new MySqlCommand();
            String poistokysely = "DELETE FROM yhteystiedot WHERE userid = @uid";
            komento.CommandText = poistokysely;
            komento.Connection = connection.Connection();
            //@oid
            komento.Parameters.Add("@uid", MySqlDbType.UInt32).Value = userId;

            connection.OpenConnection();
            if (komento.ExecuteNonQuery() == 1)
            {
                connection.CloseConnection();
                return true;
            }
            else
            {
                connection.CloseConnection();
                return false;
            }
        }
        /*
        public String salasana()
        {
            char[] jono = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            String ssana = "";
            Random rnd = new Random();
            for (int i = 0; i < 15; i++)
            {
                ssana += jono[rnd.Next(0, 61)];
            }
            return ssana;
        }
        

        public bool ChangePassword(String password, int UserId)
        {
            MySqlCommand komento = new MySqlCommand();
            String paivityskysely = "UPDATE `yhteystiedot` SET `password`= @pwd," +
                " WHERE userid = @uid";
            komento.CommandText = paivityskysely;
            komento.Connection = connection.Connection();
            //@pwd
            komento.Parameters.Add("@pwd", MySqlDbType.UInt32).Value = password;



            connection.OpenConnection();
            if (komento.ExecuteNonQuery() == 1)
            {
                connection.CloseConnection();
                return true;
            }
            else
            {
                connection.CloseConnection();
                return false;
            }
        }
        */
    
    }
}
