using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;

namespace StudyPoint
{
    class WHATSNEW
    {
        CONNECT myConnection = new CONNECT();

        // LISÄÄ UUSI ASIA TIETOKANTAAN
        public bool AddNewThing(String asia)
        {
            if (asia == "")
            {
                MessageBox.Show("Text field is empty!");
                return true;
            }

            else
            {
                MySqlCommand myCommand = new MySqlCommand();

                String newAdd = "INSERT INTO uudetasiat " + "(asia) " + "VALUES (@asia);";

                myCommand.CommandText = newAdd;
                myCommand.Connection = myConnection.Connection();
                myCommand.Parameters.Add("@asia", MySqlDbType.VarChar).Value = asia;

                MessageBox.Show(asia + " added successfully!");

                myConnection.OpenConnection();
                if (myCommand.ExecuteNonQuery() == 1)
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

        // NOUDA ASIAT TIETOKANNASTA
        public DataTable GetNewThings()
        {
            MySqlCommand MyCommand = new MySqlCommand("SELECT asia FROM uudetasiat", myConnection.Connection());

            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();

            DataTable Table = new DataTable();

            MyAdapter.SelectCommand = MyCommand;
            MyAdapter.Fill(Table);

            return Table;

        }

        // POISTA TIETO TIETOKANNASTA
        public bool DeleteNewThing(String newThing)
        {
            MySqlCommand MyCommand = new MySqlCommand();

            String Delete = "DELETE FROM uudetasiat WHERE asia = @asia";

            MyCommand.CommandText = Delete;

            MyCommand.Connection = myConnection.Connection();

            MyCommand.Parameters.Add("@asia", MySqlDbType.VarChar).Value = newThing;

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
