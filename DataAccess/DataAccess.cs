using CommonTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace DataAccess
{
    public class DataAccess
    {
        public MySqlConnection myConnection;
        public void AccessDB()
        {
            myConnection = new MySqlConnection("SERVER=localhost;DATABASE=kfzapp;UID=root;PASSWORD=;");
            myConnection.Open();
        }
        public void CloseDB()
        {
            myConnection.Close();
        }

        public void SaveKFZ(KFZ kfz)
        {
            //Verbindung zur DB aufbauen.
            this.AccessDB();

            //Einfüge SQL-Befehl zusammenbauen.
            string myInsertQuery = $"INSERT INTO `kfz`( `FahrgestellNr`, `Kennzeichen`, `Leistung`, `Typ`) VALUES('{kfz.FahrgestellNr}', '{kfz.Kennzeichen}', {kfz.Leistung}, '{kfz.Typ}')";
            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

            //Dem SQL-Befehl noch sagen, welche Verbindung zum Server verwendet werden soll.
            myCommand.Connection = myConnection;

            //Befehl ausführen.
            myCommand.ExecuteNonQuery();

            //Verbindung zur Datenbank wieder abbauen.
            this.CloseDB();
        }
        public List<KFZ> GetALLKFZ()
        {
            List<KFZ> KFZListe = new List<KFZ>();

            //Verbindung zur DB aufbauen.
            this.AccessDB();

            //Einfüge SQL-Befehl zusammenbauen.
            string sqlSelect = "SELECT * FROM `kfz`";

            //Befehl ausführen
            MySqlCommand myCommand = new MySqlCommand(sqlSelect);
            myCommand.Connection = myConnection;
            MySqlDataReader reader = myCommand.ExecuteReader();
          
            while (reader.Read())
            {
                KFZ newKFZ = new KFZ();

                newKFZ.KFZid = Convert.ToInt32(reader["idkfz"]);
                newKFZ.FahrgestellNr = Convert.ToString(reader["FahrgestellNr"]);
                newKFZ.Kennzeichen = Convert.ToString(reader["Kennzeichen"]);
                newKFZ.Leistung = Convert.ToInt32(reader["Leistung"]);
                newKFZ.Typ = Convert.ToString(reader["Typ"]);
                KFZListe.Add(newKFZ);
            }


            //Verbindung zur Datenbank wieder abbauen.
            this.CloseDB();
            return KFZListe;
        }
        public void SaveCurrenKFZ(KFZ k)
        {
            //Verbindung zur DB aufbauen.
            this.AccessDB();

            //Befehl Setzen 
            string sqlUpdate = $"UPDATE `kfz` SET `FahrgestellNr`='{k.FahrgestellNr}',`Kennzeichen`='{k.Kennzeichen}',`Leistung`='{k.Leistung}',`Typ`='{k.Typ}' WHERE idkfz = {k.KFZid}";
            MySqlCommand myCommand = new MySqlCommand(sqlUpdate);

            //Dem SQL-Befehl noch sagen, welche Verbindung zum Server verwendet werden soll.
            myCommand.Connection = myConnection;

            //Befehl ausführen.
            myCommand.ExecuteNonQuery();

            //Verbindung zur Datenbank wieder abbauen.
            this.CloseDB();
        }
        public void DeleteKFZ(int kfzid)
        {
            //Verbindung zur DB aufbauen.
            this.AccessDB();

            //Befehl Setzen 
            string sqlDelete = $"DELETE FROM `kfz` WHERE idkfz = {kfzid}";
            MySqlCommand myCommand = new MySqlCommand(sqlDelete);

            //Dem SQL-Befehl noch sagen, welche Verbindung zum Server verwendet werden soll.
            myCommand.Connection = myConnection;

            //Befehl ausführen.
            myCommand.ExecuteNonQuery();

            //Verbindung zur Datenbank wieder abbauen.
            this.CloseDB();
        }
        public void NewKFZ(KFZ k)
        {
            //Verbindung zur DB aufbauen.
            this.AccessDB();

            //Befehl Setzen 
            string sqlDelete = $"INSERT INTO `kfz`( `FahrgestellNr`, `Kennzeichen`, `Leistung`, `Typ`) VALUES ('{k.FahrgestellNr}','{k.Kennzeichen}','{k.Leistung}','{k.Typ}')";
            MySqlCommand myCommand = new MySqlCommand(sqlDelete);

            //Dem SQL-Befehl noch sagen, welche Verbindung zum Server verwendet werden soll.
            myCommand.Connection = myConnection;

            //Befehl ausführen.
            myCommand.ExecuteNonQuery();

            //Verbindung zur Datenbank wieder abbauen.
            this.CloseDB();
        }
    }
}
