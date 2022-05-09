﻿using System;
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
    class PROFILE
    {
        CONNECT myConnection = new CONNECT();

        public bool IsLogged(string email)
        {

            myConnection.OpenConnection();
            MySqlCommand komento = new MySqlCommand("SELECT sahkoposti FROM kayttajat WHERE sahkoposti = '" + email + "'", myConnection.Connection());

            var sana = (string)komento.ExecuteScalar();
            myConnection.CloseConnection();

            if (sana == email)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public DataTable GetProfile(string email)
        {
            MySqlCommand MyCommand = new MySqlCommand("SELECT sahkoposti,etunimi,sukunimi,kID FROM studypoint.kayttajat WHERE sahkoposti = '" + email + "'", myConnection.Connection());
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();

            DataTable MyTable = new DataTable();

            MyAdapter.SelectCommand = MyCommand;
            MyAdapter.Fill(MyTable);

            return MyTable;
        }


        public bool UpdateProfile(String Email, String Fname, String Lname)
        {
            MySqlCommand myCommand = new MySqlCommand(); // luodaan uusi komento

            String myAdd = "UPDATE kayttajat SET sahkoposti = @email, etunimi = @enm, sukunimi = @snm WHERE CONCAT(kayttajat.sahkoposti) = '" + Email + "'";
            

            myCommand.CommandText = myAdd; // annetaan käsky käyttää myAdd-komentoa
            myCommand.Connection = myConnection.Connection(); // yhdistetään tietokantaan

            myCommand.Parameters.Add("@email", MySqlDbType.VarChar).Value = Email;
            myCommand.Parameters.Add("@enm", MySqlDbType.VarChar).Value = Fname;
            myCommand.Parameters.Add("@snm", MySqlDbType.Text).Value = Lname;


            MessageBox.Show("Profile updated!");

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
}
