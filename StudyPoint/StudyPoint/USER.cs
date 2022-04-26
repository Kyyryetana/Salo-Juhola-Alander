using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyPoint
{
    internal class USER
    {

        CONNECT connection = new CONNECT();

        public bool AddUser(String enimi, String snimi, String email, int userId)
        {
            
            String password = passwordGenerator();
            String encryptedPassword = Encrypt(password);
            MySqlCommand komento = new MySqlCommand();
            String lisayskysely = "INSERT INTO yhteystiedot " +
                "(etunimi, sukunimi, sahkoposti, userid, password) " +
                "VALUES (@enm, @snm, @eml, @uid, @pwd ); ";
            komento.CommandText = lisayskysely;
            komento.Connection = connection.Connection();
            //@enm, @snm, @eml, @uid, @pwd
            komento.Parameters.Add("@enm", MySqlDbType.VarChar).Value = enimi;
            komento.Parameters.Add("@snm", MySqlDbType.VarChar).Value = snimi;
            komento.Parameters.Add("@eml", MySqlDbType.VarChar).Value = email;
            komento.Parameters.Add("@uid", MySqlDbType.UInt32).Value = userId;
            komento.Parameters.Add("@pwd", MySqlDbType.VarChar).Value =  encryptedPassword;
            //komento.Parameters.Add("@ssa", MySqlDbType.VarChar).Value = salattu;
            MessageBox.Show("Käyttäjätunnuksesi on " + ktunnus + "\nSalasanasi on " + salis + /*"\nSalattuna se on" + salattu + */"\nkirjoita nämä visusti talteen");

            connection.openConnection();
            if (komento.ExecuteNonQuery() == 1)
            {
                connection.closeConnection();
                return true;
            }
            else
            {
                connection.closeConnection();
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
            





            connection.openConnection();
            if (komento.ExecuteNonQuery() == 1)
            {
                connection.closeConnection();
                return true;
            }
            else
            {
                connection.closeConnection();
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
            
            connection.openConnection();
            if (komento.ExecuteNonQuery() == 1)
            {
                connection.closeConnection();
                return true;
            }
            else
            {
                connection.closeConnection();
                return false;
            }
        }
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



            connection.openConnection();
            if (komento.ExecuteNonQuery() == 1)
            {
                connection.closeConnection();
                return true;
            }
            else
            {
                connection.closeConnection();
                return false;
            }
        }


    }
}
