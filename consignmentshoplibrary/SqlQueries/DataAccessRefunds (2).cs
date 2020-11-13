using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SQLite;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ConsignmentShopLibrary.SqlQueries
{
    public class DataAccessRefunds
    {

        public Store Store { get; } = new Store();

        public void CreateDataBase(string DatabaseName)
        {
            SQLiteConnection.CreateFile(DatabaseName);
        }


        public DataTable GetRefund(string anAccountID)
        {
            RefundDataTable table = new RefundDataTable();
            DataRow row;
            DataTable myTable = table.DataTable;

            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    string connectionString = $"SELECT * FROM Rueckgaben  WHERE Rueckgaben.AccountID = '{anAccountID}' AND Rueckgaben.output= '' ";
                    var output = connection.Query<Refund>(connectionString).ToList();
                    row = myTable.NewRow();

                    foreach (var item in output)
                    {
                        row = myTable.NewRow();

                        row["AccountID"] = item.AccountID;
                        row["LastName"] = item.LastName;
                        row["Place"] = item.Place;

                        if (!String.IsNullOrEmpty(item.Input))
                            row["Input"] = Item.ConvertSQLiteTimeStringToDateString( item.Input);
                        else
                            row["Input"] = DBNull.Value;
                        if (!String.IsNullOrEmpty(item.Output))
                            row["Output"] = item.Output;
                        else
                            row["Output"] = DBNull.Value;
                        myTable.Rows.Add(row);
                    }

                }
                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 1)
                    {
                        //MessageBox.Show($"Fehlercode: {ex.ErrorCode} ");
                        string connectionString = "";
                        connectionString = $"CREATE TABLE Rueckgaben ( AccountID INTEGER NOT NULL, LastName  TEXT NOT NULL, Place TEXT NOT NULL, Input TEXT NOT NULL, OutPut TEXT)";
                        connection.Execute(connectionString);
                        connectionString = $"SELECT * FROM Rueckgaben  WHERE Rueckgaben.AccountID = '{anAccountID}'";
                        var output = connection.Query<Refund>(connectionString).ToList();
                    }
                }
                return myTable;

            }
        }



        public void InsertRefund(Refund refund)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string inputDate = refund.Input;
                inputDate = Item.ConvertDateStringToSQLiteTimeString(refund.Input);

                try
                {
                    string connectionString = "";
                    connectionString = $"INSERT INTO Rueckgaben ([AccountID], [LastName], [Place], [Input], [Output]  )" +
                        $"  VALUES( '{Store.SQLEscape(refund.AccountID)}', '{Store.SQLEscape(refund.LastName)}', '{Store.SQLEscape(refund.Place)}', " +
                        $"'{inputDate}', '')";
                    connection.Execute(connectionString);
                }
                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 1)
                    {
                        string connectionString = "";
                        connectionString = $"CREATE TABLE Rueckgaben ( AccountID INTEGER NOT NULL, LastName  TEXT NOT NULL, Place TEXT NOT NULL, Input TEXT NOT NULL, OutPut TEXT)";
                        connection.Execute(connectionString);
                        connectionString = $"INSERT INTO Rueckgaben ([AccountID], [LastName], [Place], [Input], [Output]  )" +
                            $"  VALUES( '{Store.SQLEscape(refund.AccountID)}', '{Store.SQLEscape(refund.LastName)}', '{Store.SQLEscape(refund.Input)}', " +
                            $" '{inputDate}',  '')";
                        connection.Execute(connectionString);
                    }
                }
            }
        }

        public void UpdateRefund(Refund refund)
        {
            {
                using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
                {
                    string connectionString = "";
                    string outputDate = refund.Output;
                    outputDate = Item.ConvertDateStringToSQLiteTimeString(refund.Output);

                    connectionString = $"UPDATE Rueckgaben SET " +
                                        $"[OutPut] = '{outputDate}' WHERE  Rueckgaben.AccountID = '{refund.AccountID}' AND Rueckgaben.OutPut = '' ";
                    connection.Execute(connectionString);
                }
            }
        }
     }
}
