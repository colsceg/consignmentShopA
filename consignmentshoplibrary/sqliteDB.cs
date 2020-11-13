using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace ConsignmentShopLibrary
{
    public class sqliteDB
    {
        private SQLiteConnection con;

        private string fields = "vendorID, lastname, firstname, amendment1, amendment2," +
           "street, plz, town, telefon, mobilTel, email, commission, expireTime, payOut, payedOut";

        private string values = "'1001', 'Braun', 'Barbara', '', '', 'Hangweg 6', '42899', 'Remscheid'," +
             "'021915915684', '', 'info@chairfit.de', '50', '90', 'false', 'false'";

        public void createDB(string filename)
        {
            SQLiteConnection.CreateFile(filename);
        }


        //erwartet einen String mit dem Pfad der Datenbank und einen String mit den Feldern
        public void createTable(string tablename, string fields)
        {   
            string sql = string.Format("CREATE TABLE {0} ({1})", tablename, fields);
            SQLiteCommand command = new SQLiteCommand(sql, con);
            command.ExecuteNonQuery();
           
        }

        //erwartet einen String mit dem Pfad der Datenbank
        public void connectDB(string filename)
        {
                con = new SQLiteConnection(string.Format("Data Source = {0}; Version=3;", filename));
                con.Open();
        }

        public void writeRecord(string table, string fields, string values)
        {   try
            {
                string sql = string.Format("insert into {0} ({1}) values ({2})", table, fields, values);
                SQLiteCommand command = new SQLiteCommand(sql, con);
                command.ExecuteNonQuery();
            }
            catch
            {
                createTable(table, fields);
                string sql = string.Format("insert into {0} ({1}) values ({2})", table, fields, values);
                SQLiteCommand command = new SQLiteCommand(sql, con);
                command.ExecuteNonQuery();
            }
        }

        public List<string> readRecord(string table)
        {
            List<string> dataList = new List<string>();
//            writeRecord(table, fields, values);
            string sql = string.Format("SELECT * FROM {0}", table);
            SQLiteCommand command = new SQLiteCommand(sql, con);
            try
            {
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string temp="";
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        temp += reader.GetValue(i);
                        temp += ",";
                    }
                    dataList.Add(temp);
                    temp = "";                
                }
            }
            catch
            {
                createTable(table, fields);
            }
            return dataList;       
        }

        public void closeDB()
        {
            con.Close();
            con.Dispose();
        }
    }
}
