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
    class DOWNLOADS
    {
        CONNECT myConnection = new CONNECT();

        // LÄHETÄ KUVA TIETOKANTAAN
        /*public bool SendImgToSql(string imgLocation, string kuvannimi)
        {
            byte[] img = null;
            FileStream fs = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);

            MySqlCommand myCommand = new MySqlCommand();

            String newPicture = "INSERT INTO lataukset(kuvan_nimi,kuvan_osoite)VALUES ("+kuvannimi+",@img);";

            myCommand.CommandText = newPicture;
            myCommand.Connection = myConnection.Connection();
            myCommand.Parameters.Add("kuvan_nimi", MySqlDbType.VarChar).Value = kuvannimi;
            myCommand.Parameters.Add("@img", MySqlDbType.VarChar).Value = imgLocation;

            MessageBox.Show("New picture added successfully");

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
        }*/

        // NOUDA KUVAT TIETOKANNASTA TAULUKKOON

        public DataTable FetchImagesFromSql()
        {
            MySqlCommand MyCommand = new MySqlCommand("SELECT lID, kuvan_nimi FROM lataukset", myConnection.Connection());

            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();

            DataTable Table = new DataTable();

            MyAdapter.SelectCommand = MyCommand;

            MyAdapter.Fill(Table);

            return Table;
        }

        // POISTA KUVA TIETOKANNASTA

        public bool deleteImgFromSql(string kuva)
        {
            MySqlCommand MyCommand = new MySqlCommand();

            String Delete = "DELETE FROM lataukset WHERE kuvan_nimi = @kuvan_nimi";

            MyCommand.CommandText = Delete;

            MyCommand.Connection = myConnection.Connection();

            MyCommand.Parameters.Add("@kuvan_nimi", MySqlDbType.VarChar).Value = kuva;

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
