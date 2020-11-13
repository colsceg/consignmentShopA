using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SQLite;
using System.Windows.Forms;
using System.ComponentModel;
using System;
using System.Data;


namespace ConsignmentShopLibrary
{
    public class DataAccessVendors
    {
        public List<Vendor> GetAllVendors_A()
        {
            string myConStr = "Data Source=C:\\Users\\NBC\\Documents\\PINK2ndHand\\SecondHandCollection.sqlite; version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(myConStr))
                try
                {
                    {
                        var output = connection.Query<Vendor>($"SELECT * FROM customers ORDER BY Lastname ASC ").ToList();
                        return output;
                    }
                }
                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 1)
                    {
                        string connectionString = $"CREATE TABLE customers (AccountID TEXT PRIMARY KEY  NOT NULL  UNIQUE , LastName TEXT, " +
                            $"FirstName TEXT, Annex1 TEXT, Annex2 TEXT, Street TEXT, Plz TEXT, town TEXT, PhoneNumber1 TEXT, PhoneNumber2 TEXT, " +
                            $"EmailAccount TEXT, Margin INTEGER, Period INTEGER)";
                        connection.Execute(connectionString);
                    }
                    List<Vendor> test = new List<Vendor>();
                    return test;
                }

        }

        public DataTable GetAllVendors()
        {
            string test = Helper.ConnectionString;

            using (SQLiteConnection connection = new SQLiteConnection(test))
            {
                VendorDataTable table = new VendorDataTable();
                DataRow row;
                DataTable myTable = table.DataTable;
                try
                {
                    {
                        var output = connection.Query<Vendor>($"SELECT * FROM customers ORDER BY accountID DESC ").ToList();
                        foreach (var item in output)
                        {
                            row = myTable.NewRow();

                            row["AccountID"] = item.AccountID;
                            row["LastName"] = item.LastName;
                            row["FirstName"] = item.FirstName;
                            row["Street"] = item.Street;
                            row["Plz"] = item.Plz;
                            row["Town"] = item.Town;
                            row["Phonenumber1"] = item.PhoneNumber1;
                            row["Phonenumber2"] = item.PhoneNumber2;
                            row["EmailAccount"] = item.EmailAccount;
                            row["Margin"] = item.Margin;
                            row["Period"] = item.Period;
                            row["Annex1"] = item.Annex1;
                            row["Annex2"] = item.Annex2;

                            myTable.Rows.Add(row);
                        }
                        connection.Close();
                        return myTable;
                    }
                }
                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 1)
                    {
                        string connectionString = $"CREATE TABLE customers (AccountID TEXT PRIMARY KEY  NOT NULL  UNIQUE , LastName TEXT, " +
                            $"FirstName TEXT, Annex1 TEXT, Annex2 TEXT, Street TEXT, Plz TEXT, town TEXT, PhoneNumber1 TEXT, PhoneNumber2 TEXT, " +
                            $"EmailAccount TEXT, Margin INTEGER, Period INTEGER)";
                        connection.Execute(connectionString);
                    }
                    connection.Close();
                    return myTable;
                }
            }
        }

        public List<Vendor> GetAllVendorsName()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                var output = connection.Query<Vendor>($"SELECT * FROM customers ORDER BY LastName ASC ").ToList();
                return output;
            }
        }

        public List<string> GetAllVendorsFullInfo()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                var output = connection.Query<string>($"SELECT * FROM customers ORDER BY LastName ASC ").ToList();
                return output;
            }
        }

        public BindingList<string> GetAllAccountID()
        {
            BindingList<string> accountIDList = new BindingList<string>();

            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                var output = connection.Query<string>($"SELECT AccountID FROM customers ORDER BY AccountID ASC ").ToList();

                foreach (var item in output)
                {
                    accountIDList.Add(item);
                }
                return  accountIDList;
            }
        }

        public List<Vendor> GetAllVendorsSorted( string aColumnName, string aSortDirection)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                var output = connection.Query<Vendor>($"SELECT * FROM customers ORDER BY {aColumnName} {aSortDirection} ").ToList();
                return output;
            }
        }

        public List<Vendor> GetAllVendorsSorted(string aColumnName, string aSortDirection, string aCondition)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                var output = connection.Query<Vendor>($"SELECT * FROM customers " +
                    $"WHERE Lastname = {aCondition} " +
                    $"ORDER BY {aColumnName} {aSortDirection} ").ToList();
                return output;
            }
        }

        public List<Vendor> GetAllVendorsSorted(string aColumnName, string aSortDirection, string aLastname, string aPlz)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                var output = connection.Query<Vendor>($"SELECT * FROM customers " +
                    $"WHERE Lastname = {aLastname} AND plz = {aPlz} " +
                    $"ORDER BY {aColumnName} {aSortDirection} ").ToList();
                return output;
            }
        }

        public List<Vendor> GetAllVendorsSorted(string aColumnName, string aSortDirection, string aLastname, string aPlz, string aTown)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                var output = connection.Query<Vendor>($"SELECT * FROM customers " +
                    $"WHERE Lastname = {aLastname} AND plz = {aPlz} AND town = {aTown} " +
                    $"ORDER BY {aColumnName} {aSortDirection} ").ToList();
                return output;
            }
        }

        public List<Vendor> GetVendors(string aField, string aFieldContent)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                var output = connection.Query<Vendor>($"SELECT * FROM customers  WHERE {aField} LIKE '{ aFieldContent }%'  ORDER BY {aField} ASC ").ToList();
                return output;
            }
        }

        public List<Vendor> GetVendorWithAccountID(string anAccountID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = $"SELECT * FROM customers  WHERE AccountID = '{ anAccountID }' ";
                var output = connection.Query<Vendor>(connectionString).ToList();
                return output;
            }
        }

        public List<Vendor> GetVendorsDouble(Vendor aVendor)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
                {
                    string connectionString = $"SELECT * FROM customers " +
                        $"WHERE UPPER(Lastname) = UPPER('{Store.DataViewEscape(aVendor.LastName)}') AND UPPER(Firstname) = UPPER('{Store.DataViewEscape(aVendor.FirstName)}') " +
                        $"ORDER BY AccountID ASC ";
                    var output = connection.Query<Vendor>(connectionString).ToList();
                    return output;
                }

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Fehler bei der Datenbank Abfrage (" + ex + ")");
                List<Vendor> test = new List<Vendor>();
                return test;
            }

        }

        public List<Vendor> GetOwner()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                var output = connection.Query<Vendor>($"SELECT * FROM customers  WHERE AccountID = '1000' ").ToList();
                return output;
            }
        }

        public List<Vendor> FindVendor(string aVendor)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                var output = connection.Query<Vendor>($"SELECT * FROM customers  WHERE Lastname Like '{aVendor}' ").ToList();
                return output;
            }
        }

        public void InsertPerson(Vendor aVendor)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                connectionString = $"INSERT INTO customers ([AccountID], [LastName], [FirstName], [Street], [Plz], [Town], [PhoneNumber1], [PhoneNumber2], " + 
                    $" [EmailAccount], [Margin], [Period], [Annex1], [Annex2]  )" +
                    $"  VALUES( '{Store.SQLEscape(aVendor.AccountID)}', '{Store.SQLEscape(aVendor.LastName)}', '{Store.SQLEscape(aVendor.FirstName)}', '{Store.SQLEscape(aVendor.Street)}', '{aVendor.Plz}', '{Store.SQLEscape(aVendor.Town)}', " +
                    $" '{Store.SQLEscape(aVendor.PhoneNumber1)}', '{Store.SQLEscape(aVendor.PhoneNumber2)}', '{Store.SQLEscape(aVendor.EmailAccount)}', {aVendor.Margin}, {aVendor.Period}, '{Store.SQLEscape(aVendor.Annex1)}', '{Store.SQLEscape(aVendor.Annex2)}' )";
                connection.Execute(connectionString);
            }
        }

        public bool InsertPersons(List<Vendor> aVendorList)
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
                            foreach (var aVendor in aVendorList)
                            {
                                cmd.CommandText =
                                     $"INSERT OR IGNORE INTO customers ([AccountID], [LastName], [FirstName], [Street], [Plz], [Town], [PhoneNumber1], [PhoneNumber2], " +
                                     $" [EmailAccount], [Margin], [Period], [Annex1], [Annex2]  )" +
                                     $"  VALUES( '{Store.SQLEscape(aVendor.AccountID)}', '{Store.SQLEscape(aVendor.LastName)}', '{Store.SQLEscape(aVendor.FirstName)}', '{Store.SQLEscape(aVendor.Street)}', '{aVendor.Plz}', '{Store.SQLEscape(aVendor.Town)}', " +
                                     $" '{Store.SQLEscape(aVendor.PhoneNumber1)}', '{Store.SQLEscape(aVendor.PhoneNumber2)}', '{Store.SQLEscape(aVendor.EmailAccount)}', {aVendor.Margin}, {aVendor.Period}, '{Store.SQLEscape(aVendor.Annex1)}', '{Store.SQLEscape(aVendor.Annex2)}' )";
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                    }
                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Speichern der Kunden: " + ex.Message);
                return false;
            }
        }

        public void UpdatePerson(Vendor aVendor)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                connectionString = $"UPDATE customers SET LastName = '{Store.SQLEscape(aVendor.LastName)}',  FirstName = '{ Store.SQLEscape(aVendor.FirstName) }', " +
                    $"Street =  '{ Store.SQLEscape(aVendor.Street) }', Plz = '{aVendor.Plz}', Town = '{Store.SQLEscape(aVendor.Town)}', PhoneNumber1 = '{Store.SQLEscape(aVendor.PhoneNumber1)}', " +
                    $"PhoneNumber2 = '{Store.SQLEscape(aVendor.PhoneNumber2)}', EmailAccount = '{Store.SQLEscape(aVendor.EmailAccount)}', Margin = {aVendor.Margin}, " +
                    $"Period = {aVendor.Period}, Annex1 = '{Store.SQLEscape(aVendor.Annex1)}', Annex2 ='{Store.SQLEscape(aVendor.Annex2)}' " + 
                    $"WHERE (AccountID='{aVendor.AccountID}')";
                connection.Execute(connectionString);
            }
        }

        public void UpdateMargin(int aMargin)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                connectionString = $"UPDATE customers SET  Margin = {aMargin} ";
                connection.Execute(connectionString);
            }
        }

        public void UpdatePeriod(int aPeriod)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                connectionString = $"UPDATE customers SET  Period = { aPeriod } ";
                connection.Execute(connectionString);
            }
        }

        public void DeletePerson(string aVendorAccountID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";

                connectionString = $"DELETE FROM customers WHERE AccountID = '{aVendorAccountID}' ";

                connection.Execute(connectionString);
            }
        }

        public string GetLastAccountID()
        {
            Vendor myPerson = new Vendor();
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<Vendor>($"SELECT AccountID FROM customers ORDER BY customers.AccountID ASC ").ToList();
                if (output.Count > 0)
                {
                    myPerson = output.Last();
                    
                }
            }
            return myPerson.AccountID;
        }
    }
}

