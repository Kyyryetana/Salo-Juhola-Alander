using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudyPoint
{
    class FEEDBACK
    {
        CONNECT myConnection = new CONNECT();

        // TIETOKANTAAN LÄHETTÄMINEN
        public bool AddFeedback(String name, String email, String message)
        {
            MySqlCommand myCommand = new MySqlCommand(); // luodaan uusi komento

            String myAdd = "INSERT INTO palaute " + // myAdd lisää tiedot tietokantaan
                "(etunimi,sahkoposti,palaute) " +
                "VALUES(@enm, @spst, @plt);";

            myCommand.CommandText = myAdd; // annetaan käsky käyttää myAdd-komentoa
            myCommand.Connection = myConnection.Connection(); // yhdistetään tietokantaan

            myCommand.Parameters.Add("@enm", MySqlDbType.VarChar).Value = name; 
            myCommand.Parameters.Add("@spst", MySqlDbType.VarChar).Value = email;
            myCommand.Parameters.Add("@plt", MySqlDbType.Text).Value = message;
         

            MessageBox.Show("Thank you for your feedback!");

            myConnection.OpenConnection();
            if(myCommand.ExecuteNonQuery() == 1)
            {
                myConnection.CloseConnection();
                return true;
            }
            else
            {
                myConnection.CloseConnection();
                return false;
            }
        }

        // TIETOKANNASTA HAKEMINEN

        public DataTable GetFeedback()
        {
            MySqlCommand MyCommand = new MySqlCommand("SELECT etunimi,sahkoposti,palaute FROM palaute", myConnection.Connection());

            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();

            DataTable MyTable = new DataTable();

            MyAdapter.SelectCommand = MyCommand;
            MyAdapter.Fill(MyTable);

            return MyTable;

        }

        // TIETOKANNASTA POISTAMINEN
        public bool DeleteFeedback(String message)
        {
            MySqlCommand MyCommand = new MySqlCommand();

            String Delete = "DELETE FROM palaute WHERE palaute = @plt";

            MyCommand.CommandText = Delete;

            MyCommand.Connection = myConnection.Connection();

            MyCommand.Parameters.Add("@plt",MySqlDbType.VarChar).Value = message;

            myConnection.OpenConnection();
            if (MyCommand.ExecuteNonQuery() == 1)
            {
                myConnection.CloseConnection();
                return true;
            }
            else
            {
                myConnection.CloseConnection();
                return false;
            }
        }
    }
}
