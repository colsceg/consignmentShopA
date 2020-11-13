using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConsignmentShopLibrary
{
    public class DataAccessZipCode
    {
        public List<ZIPCode> GetAllZIPCodes()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    string connectionString;
                    connectionString = $"SELECT * FROM ZIPCode ORDER BY plz ASC ";
                    var output = connection.Query<ZIPCode>(connectionString).ToList();

                    return output;
                }

                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 14 || ex.ErrorCode == 1)
                    {
                        //Wenn contracts Tabelle nicht vorhanden                
                        string connectionString = "";
                        connectionString = $" CREATE TABLE IF NOT EXISTS ZIPCode ( " +
                            $"osm_id TEXT NOT NULL," +
                            $" ort TEXT NOT NULL,	" +
                            $"plz TEXT NOT NULL,	" +
                            $"bundesland TEXT NOT NULL)";

                        connection.Execute(connectionString);
                        connectionString = $"SELECT * FROM ZIPCode ORDER BY plz ASC ";
                        var output = connection.Query<ZIPCode>(connectionString).ToList();
                        return output;
                    }
                    throw;
                }
            }
        }

        public List<ZIPCode> GetAllZIPCodesByPlz(string aPlz)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    string connectionString;
                    connectionString = $"SELECT * FROM ZIPCode WHERE plz = '{aPlz}' ORDER BY plz ASC ";
                    var output = connection.Query<ZIPCode>(connectionString).ToList();

                    return output;
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Fehelercode: {ex.ErrorCode}");
                    throw;
                }
            }
        }

        public bool InsertZipCodes(List<ZIPCode> aZipCodeList)
        {
            try
            {
                using (var connection = new SQLiteConnection(Helper.ConnectionString))
                {
                    connection.Open();

                    using (var cmd = new SQLiteCommand(connection))
                    {
                        using (var transaction = connection.BeginTransaction())
                        {
                            // inserts
                            foreach (var anItem in aZipCodeList)
                            {
                                cmd.CommandText =
                                     $"INSERT INTO ZIPCode ( [osm_id], [plz], [ort], [bundesland]) VALUES( '{anItem.osm_id}', '{anItem.PLZ}', '{anItem.Ort}', '{anItem.Bundesland}')";
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                    }
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Einlesen der ZIPCodes: " + ex.Message);
                return false;
            }
        }
    }
}
