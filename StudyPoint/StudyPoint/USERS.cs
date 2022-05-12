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

        //lisää uuden käyttäjän
        public bool AddUser(String enimi, String snimi, String email, string password)
        {

            
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
        public string CheckPassword(string email, string password)
        {
            password = password.Trim();
            password = crypting.Encrypt(password);
            connection.OpenConnection();
            MySqlCommand komento = new MySqlCommand("SELECT salasana FROM kayttajat WHERE sahkoposti = '" + email + "'"   , connection.Connection());
            
            var sana = (string) komento.ExecuteScalar();
            connection.CloseConnection();
            
            if (sana == password)
            {
                return email;
            }
            else
            {
                MessageBox.Show("User name and password not match");
                return "";
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

        //tarkistaa onko käyttäjä admin
        public bool checkAdmin(string email)
        {

            connection.OpenConnection();
            MySqlCommand komento = new MySqlCommand("SELECT admin FROM kayttajat WHERE sahkoposti = '" + email + "'", connection.Connection());

            var status = (int)komento.ExecuteScalar();
            connection.CloseConnection();

            if (status == 1 )
            {
                return true;
            }
            else
            {
                return false;
            }


        }



        /* Tätä pitää muokata sen mukaan mihin laitetaan ja miten laitetaan tietojen muokkaus*/
        // Luodaan funktio käyttäjän tietojen muokkaamiseksi
        public bool EditUser(String enimi, String snimi, String email, int UserId)
        {
            MySqlCommand komento = new MySqlCommand();
            String paivityskysely = "UPDATE `kayttajat` SET `etunimi`= @enm," +
                "`sukunimi`= @snm,`sahkoposti`= @eml" +
                " WHERE kID = @uid"; // päivitetty userid = kID
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
            String poistokysely = "DELETE FROM kayttajat WHERE kID = @uid"; // päivitetty: yhteystiedot = kayttajat, userid = kID
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

        // LISÄTTY
        // HAKEE KÄYTTÄJIEN TIEDOT TIETOKANNASTA
        public DataTable GetUsers()
        {
            MySqlCommand MyCommand = new MySqlCommand("SELECT sahkoposti, etunimi, sukunimi, kID, admin FROM kayttajat", connection.Connection());
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            DataTable MyTable = new DataTable();

            MyAdapter.SelectCommand = MyCommand;
            MyAdapter.Fill(MyTable);

            return MyTable;
        }


       
        /*
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
