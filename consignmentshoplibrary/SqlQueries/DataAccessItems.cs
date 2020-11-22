using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SQLite;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ConsignmentShopLibrary
{
    public class DataAccessItems
    {
        public int MyCounter { get; set; }

        public void CreateDataBase(string DatabaseName)
        {
            SQLiteConnection.CreateFile(DatabaseName);
        }

        public List<Contract> GetAllContracts()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<Contract>($"SELECT contracts.ContractID, contracts.AccountID, BeginDate, " +
                        $"CloseDate, EndDate, NumberOfItems, ProvisionSum, SoldNumbers, SoldSum, PayedSum, ContractInfo, contracts.Margin," +
                        $"  customers.LastName, customers.FirstName FROM contracts LEFT JOIN customers ON contracts.accountID = customers.accountID " +
                        $"WHERE Archived = 'False' ORDER BY contractID ASC ").ToList();
                    foreach (var item in output)
                    {
                        item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                        item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                        item.CloseDate = Item.ConvertSQLiteTimeStringToDateString(item.CloseDate);
                    }
                    return output;
                }

                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 14 || ex.ErrorCode == 1)
                    {
                        //Wenn contracts Tabelle nicht vorhanden                
                        string connectionString = "";
                        connectionString = $"CREATE TABLE IF NOT EXISTS contracts (ContractID TEXT PRIMARY KEY  NOT NULL, AccountID TEXT NOT NULL, BeginDate TEXT, " +
                            $" CloseDate TEXT, EndDate TEXT, NumberOfitems INTEGER, ProvisionSum REAL, SoldNumbers INTEGER, SoldSum REAL, PayedSum REAL, " +
                            $" ContractInfo TEXT, Margin INTEGER, Archived TEXT NOT NULL  DEFAULT False)";

                        connection.Execute(connectionString);
                        var output = connection.Query<Contract>($"SELECT ContractID, AccountID, NumberOfItems, BeginDate, EndDate, CloseDate, ContractInfo, " +
                            $" SoldNumbers, SoldSum, Margin, PayedSum, ProvisionSum Archived FROM contracts ORDER BY ContractID ASC ").ToList();
                        foreach (var item in output)
                        {
                            item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                            item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                            item.CloseDate = Item.ConvertSQLiteTimeStringToDateString(item.CloseDate);
                        }
                        return output;
                    }
                    throw;
                }
            }
        }

        public void InsertTransaction(TransactionItem anItem)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string timestamp, accountID, customerFullInfo;
                timestamp = anItem.Timestamp;
                accountID = anItem.AccountID;
                customerFullInfo = anItem.CustomerFullInfo;

                try
                {
                    string connectionString = $"INSERT INTO transactionProtocoll ( [timestamp], [accountID], [customerFullInfo] )  " +
                                              $" VALUES( '{timestamp}', '{accountID}', '{customerFullInfo}')";
                    connection.Execute(connectionString);
                }
                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 1)
                    {
                        string connectionString = "";
                        connectionString = $"CREATE TABLE IF NOT EXISTS transactionProtocoll (timestamp TEXT PRIMARY KEY  NOT NULL, accountID TEXT NOT NULL, customerFullInfo TEXT )";
                        connection.Execute(connectionString);

                        connectionString = $"INSERT INTO transactionProtocoll ( [timestamp], [accountID], [customerFullInfo] )  " +
                                              $" VALUES( '{timestamp}', '{accountID}', '{customerFullInfo}')";
                        connection.Execute(connectionString);
                    }
                }
            }
        }

        public List<Contract> GetAllArchivedContracts()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<Contract>($"SELECT contracts.ContractID, contracts.AccountID, BeginDate, CloseDate, " +
                        $" EndDate, NumberOfItems, ProvisionSum, SoldNumbers, SoldSum, PayedSum, ContractInfo, Margin," +
                        $" customers.LastName, customers.FirstName FROM contracts LEFT JOIN customers ON contracts.accountID = customers.accountID " +
                        $" WHERE Archived = 'true' ORDER BY contracts.contractID ASC ").ToList();
                    foreach (var item in output)
                    {
                        item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                        item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                        item.CloseDate = Item.ConvertSQLiteTimeStringToDateString(item.CloseDate);
                    }
                    return output;
                }

                catch (SQLiteException)
                {
                    throw;
                }
            }
        }

        public List<Contract> GetAllTotalNumberOfContracts()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<Contract>($"SELECT * FROM contracts ORDER BY contractID ASC ").ToList();
                    foreach (var item in output)
                    {
                        item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                        item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                        item.CloseDate = Item.ConvertSQLiteTimeStringToDateString(item.CloseDate);
                    }
                    return output;
                }

                catch (SQLiteException)
                {
                    //Wenn contracts Tabelle nicht vorhanden                
                    string connectionString = "";
                    connectionString = $"CREATE TABLE IF NOT EXISTS contracts (ContractID TEXT PRIMARY KEY  NOT NULL, AccountID TEXT NOT NULL, BeginDate TEXT, " +
                        $" CloseDate TEXT, EndDate TEXT, NumberOfitems INTEGER, ProvisionSum REAL, SoldNumbers INTEGER, SoldSum REAL, PayedSum REAL, " +
                        $" ContractInfo TEXT, Margin INTEGER, Archived TEXT NOT NULL  DEFAULT False)";
                    connection.Execute(connectionString);
                    var output = connection.Query<Contract>($"SELECT ContractID, AccountID, NumberOfItems, BeginDate, EndDate, CloseDate, ContractInfo, " +
                        $" SoldNumbers, SoldSum, Margin, PayedSum, ProvisionSum Archived FROM contracts ORDER BY ContractID ASC ").ToList();
                    foreach (var item in output)
                    {
                        item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                        item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                        item.CloseDate = Item.ConvertSQLiteTimeStringToDateString(item.CloseDate);
                    }
                    return output;
                }
            }
        }

        public List<Contract> GetAllContractsSorted(string aColumnName, string aSortDirection)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {//return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                    var output = connection.Query<Contract>($"SELECT contracts.ContractID, contracts.AccountID, BeginDate, " +
                        $"CloseDate, EndDate, NumberOfItems, ProvisionSum, SoldNumbers, SoldSum, PayedSum, ContractInfo, contracts.Margin," +
                        $"  customers.LastName, customers.FirstName FROM contracts LEFT JOIN customers ON contracts.accountID = customers.accountID " +
                        $"WHERE Archived = 'False' ORDER BY contracts.{aColumnName} {aSortDirection} ").ToList();
                    foreach (var item in output)
                    {
                        item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                        item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                        item.CloseDate = Item.ConvertSQLiteTimeStringToDateString(item.CloseDate);
                    }
                    return output;
                }
                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 14 || ex.ErrorCode == 1)
                    {
                        //Wenn contracts Tabelle nicht vorhanden                
                        string connectionString = "";
                        connectionString = $"CREATE TABLE IF NOT EXISTS contracts (ContractID TEXT PRIMARY KEY  NOT NULL, AccountID TEXT NOT NULL, BeginDate TEXT, " +
                            $" CloseDate TEXT, EndDate TEXT, NumberOfitems INTEGER, ProvisionSum REAL, SoldNumbers INTEGER, SoldSum REAL, PayedSum REAL, " +
                            $" ContractInfo TEXT, Margin INTEGER, Archived TEXT NOT NULL  DEFAULT False)";
                        connection.Execute(connectionString);
                        var output = connection.Query<Contract>($"SELECT ContractID, AccountID, NumberOfItems, BeginDate, EndDate, CloseDate, ContractInfo, " +
                            $" SoldNumbers, SoldSum, Margin, PayedSum, ProvisionSum Archived FROM contracts ORDER BY ContractID ASC ").ToList();
                        foreach (var item in output)
                        {
                            item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                            item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                            item.CloseDate = Item.ConvertSQLiteTimeStringToDateString(item.CloseDate);
                        }
                        return output;
                    }
                    throw;
                }
            }
        }

        public List<Contract> GetAllArchivedContractsSorted(string aColumnName, string aSortDirection)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {//return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                    var output = connection.Query<Contract>($"SELECT contracts.ContractID, contracts.AccountID, BeginDate, " +
                        $"CloseDate, EndDate, NumberOfItems, ProvisionSum, SoldNumbers, SoldSum, PayedSum, ContractInfo, contracts.Margin," +
                        $"  customers.LastName, customers.FirstName FROM contracts LEFT JOIN customers ON contracts.accountID = customers.accountID " +
                        $"WHERE Archived = 'True' ORDER BY {aColumnName} {aSortDirection} ").ToList();
                    foreach (var item in output)
                    {
                        item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                        item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                        item.CloseDate = Item.ConvertSQLiteTimeStringToDateString(item.CloseDate);
                    }
                    return output;
                }
                catch (SQLiteException)
                {
                    throw;
                }
            }
        }

        public List<Contract> GetContractWithContractID(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<Contract>($"SELECT contracts.ContractID, contracts.AccountID, BeginDate, " +
                        $"CloseDate, EndDate, NumberOfItems, ProvisionSum, SoldNumbers, SoldSum, PayedSum, ContractInfo, contracts.Margin," +
                        $"customers.LastName, customers.FirstName FROM contracts LEFT JOIN customers ON contracts.accountID = customers.accountID " +
                        $"WHERE ContractID = '{ aContractID }' ").ToList();
                foreach (var item in output)
                {
                    item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                    item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                    item.CloseDate = Item.ConvertSQLiteTimeStringToDateString(item.CloseDate);
                }
                return output;
            }
        }

        public List<Contract> GetContractWithAccountID(string anAccountID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<Contract>($"SELECT * FROM contracts WHERE AccountID = '{ anAccountID }' ").ToList();
                return output;
            }
        }

        public List<Contract> GetAllContractsClosed()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                var output = connection.Query<Contract>($"SELECT * FROM contracts WHERE CloseDate <> '' ").ToList();
                foreach (var item in output)
                {
                    item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                    item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                    item.CloseDate = Item.ConvertSQLiteTimeStringToDateString(item.CloseDate);
                }
                return output;
            }
        }

        public void InsertContract(Contract aContract)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                string beginDate, closeDate, endDate;
                beginDate = Item.ConvertDateStringToSQLiteTimeString(aContract.BeginDate);
                endDate = Item.ConvertDateStringToSQLiteTimeString(aContract.EndDate);
                closeDate = Item.ConvertDateStringToSQLiteTimeString(aContract.CloseDate);

                connectionString = $"INSERT INTO contracts ( [ContractID], [AccountID], [NumberOfItems], [BeginDate], " +
                $" [EndDate], [CloseDate], [ContractInfo], [SoldNumbers], [SoldSum], " +
                $" [Margin], [PayedSum], [ProvisionSum], [Archived] )" +
                $"  VALUES( '{aContract.ContractID}', '{aContract.AccountID}', '{ aContract.NumberOfItems }', '{beginDate}'," +
                $" '{endDate}', '{closeDate}', '{aContract.ContractInfo}', '{aContract.SoldNumbers}', '{aContract.SoldSum}', " +
                $" '{aContract.Margin}', '{aContract.PayedSum}', '{aContract.ProvisionSum}', 'False' )";
                try
                {
                    connection.Execute(connectionString);
                    //Update configData
                    connectionString = $"UPDATE configData SET LastContractID =  '{aContract.ContractID}' ";
                    connection.Execute(connectionString);
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        public void InsertArchivedContract(Contract aContract)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string beginDate, closeDate, endDate;
                beginDate = Item.ConvertDateStringToSQLiteTimeString(aContract.BeginDate);
                endDate = Item.ConvertDateStringToSQLiteTimeString(aContract.EndDate);
                closeDate = Item.ConvertDateStringToSQLiteTimeString(aContract.CloseDate);
                string connectionString = "";
                connectionString = $"INSERT INTO archivedContracts ( [ContractID], [AccountID], [NumberOfItems], [BeginDate], [EndDate], [CloseDate], [ContractInfo], " +
                    $" [SoldNumbers], [SoldSum], [Margin], [PayedSum], [ProvisionSum] )" +
                    $"  VALUES( '{aContract.ContractID}', '{aContract.AccountID}', '{ aContract.NumberOfItems }', '{beginDate}'," +
                    $" '{endDate}', '{closeDate}', '{aContract.ContractInfo}', '{aContract.SoldNumbers}', '{aContract.SoldSum}', " +
                    $" '{aContract.Margin}', '{aContract.PayedSum}', '{aContract.ProvisionSum}' )";
                SQLiteCommand command = new SQLiteCommand(connectionString, connection);

                connection.Execute(connectionString);
            }
        }

        public void UpdateContract(Contract aContract)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                string beginDate, closeDate, endDate;
                beginDate = Item.ConvertDateStringToSQLiteTimeString(aContract.BeginDate);
                endDate = Item.ConvertDateStringToSQLiteTimeString(aContract.EndDate);
                closeDate = Item.ConvertDateStringToSQLiteTimeString(aContract.CloseDate);

                connectionString = $"UPDATE contracts SET ContractID = '{aContract.ContractID}', AccountID = '{aContract.AccountID}', " +
                    $" BeginDate = '{ beginDate }', CloseDate = '{ closeDate }', EndDate = '{ endDate }', NumberOfItems = {aContract.NumberOfItems}, " +
                    $" ProvisionSum = '{aContract.ProvisionSum}', SoldNumbers = {aContract.SoldNumbers}, SoldSum = {aContract.SoldSum}, " +
                    $" PayedSum = {aContract.PayedSum},  ContractInfo = '{aContract.ContractInfo}', Margin = {aContract.Margin}, Archived = '{aContract.Archived}' " +
                    $" WHERE (ContractID='{aContract.ContractID}')";
                connection.Execute(connectionString);
            }
        }

        public void UpdateContractCloseDate(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string myPayoutDate = DateTime.Today.ToShortDateString();
                myPayoutDate = Item.ConvertDateStringToSQLiteTimeString(myPayoutDate);
                string connectionString = "";
                connectionString = $"UPDATE contracts SET CloseDate = '{myPayoutDate}'  WHERE (ContractID='{aContractID}')";
                connection.Execute(connectionString);
            }
        }

        public void UpdateContractPayedSum(string aContractID, string aPayedSum, string aProvisionSum)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                connectionString = $"UPDATE contracts SET PayedSum = '{aPayedSum}', ProvisionSum = '{aProvisionSum}' WHERE (ContractID='{aContractID}')";
                connection.Execute(connectionString);
            }
        }

        public void DeleteContract(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                connectionString = $"DELETE FROM contracts WHERE ContractID = '{aContractID}' ";
                connection.Execute(connectionString);
            }
        }

        //Items
        public List<Item> GetAllItems()
        {
            string test = Helper.ConnectionString;

            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<Item>($"SELECT * FROM items ORDER BY itemNumber ASC ").ToList();
                    foreach (var item in output)
                    {
                        item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                        item.PayoutDate = Item.ConvertSQLiteTimeStringToDateString(item.PayoutDate);
                        item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                        item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                        item.DeleteDate = Item.ConvertSQLiteTimeStringToDateString(item.DeleteDate);
                    }
                    return output;
                }
                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 14 || ex.ErrorCode == 1)  //ErrorCodes abfragen
                    {
                        string connectionString = "";
                        connectionString = $"CREATE TABLE IF NOT EXISTS items (AccountID TEXT NOT NULL, ContractID TEXT NOT NULL, itemNumber TEXT NOT NULL UNIQUE, ItemDescription TEXT, " +
                            $" SalesPrice REAL, CostPrice REAL, payoutDate TEXT, soldDate TEXT, beginDate TEXT, endDate TEXT, " +
                            $" color TEXT, brand TEXT, prop TEXT, size TEXT, deleteDate TEXT NOT NULL DEFAULT '' )";
                        connection.Execute(connectionString);

                        var output = connection.Query<Item>($"SELECT * FROM items ORDER BY itemNumber ASC ").ToList();
                        foreach (var item in output)
                        {
                            item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                            item.PayoutDate = Item.ConvertSQLiteTimeStringToDateString(item.PayoutDate);
                            item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                            item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                            item.DeleteDate = Item.ConvertSQLiteTimeStringToDateString(item.DeleteDate);
                        }
                        return output;
                    }
                    throw;
                }
            }
        }

        public DataTable GetAllItemsReport()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                ReportDataTable table = new ReportDataTable();
                DataRow row;
                DataTable myTable = table.DataTable;

                try
                {
                    var output = connection.Query<Item>($"SELECT AccountID, itemNumber, itemDescription, brand, color, size, prop, salesPrice, costPrice, beginDate, " +
                               "endDate, soldDate, payoutDate  FROM items WHERE DeleteDate = '' ORDER BY beginDate DESC ").ToList();
                    foreach (var item in output)
                    {
                        row = myTable.NewRow();

                        row["AccountID"] = item.AccountID;
                        try
                        {
                            row["ItemNumber"] = item.ItemNumber;
                        }
                        catch (Exception)
                        {

                            row["ItemNumber"] = item.ItemNumber.Substring(0, 4);
                        }

                        row["ItemDescription"] = item.ItemDescription;
                        row["Brand"] = item.Brand;
                        row["Color"] = item.Color;
                        row["Size"] = item.Size;
                        row["Prop"] = item.Prop;
                        row["SalesPrice"] = item.SalesPrice;
                        row["CostPrice"] = item.CostPrice;
                        if (!String.IsNullOrEmpty(item.BeginDate))
                            row["BeginDate"] = item.BeginDate;
                        else
                            row["BeginDate"] = DBNull.Value;
                        if (!String.IsNullOrEmpty(item.EndDate))
                            row["EndDate"] = item.EndDate;
                        else
                            row["EndDate"] = DBNull.Value;
                        if (!String.IsNullOrEmpty(item.SoldDate))
                            row["SoldDate"] = item.SoldDate;
                        else
                            row["SoldDate"] = DBNull.Value;
                        if (!String.IsNullOrEmpty(item.PayoutDate))
                            row["PayoutDate"] = item.PayoutDate;
                        else
                            row["PayoutDate"] = DBNull.Value;

                        //if (!String.IsNullOrEmpty(item.DeleteDate))
                        //    row["DeleteDate"] = item.DeleteDate;
                        //else
                        //    row["DeleteDate"] = DBNull.Value;

                        myTable.Rows.Add(row);
                    }
                    return myTable;
                }
                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 1 || ex.ErrorCode == 14)  //ErrorCodes abfragen
                    {
                        //string connectionString = "";
                        //connectionString = $"CREATE TABLE items (ContractID TEXT NOT NULL, itemNumber TEXT, ItemDescription TEXT, " +
                        //    $" SalesPrice REAL, CostPrice REAL, payoutDate TEXT, soldDate TEXT, " +
                        //    $" withLabel BOOL, posNumber TEXT)";
                        //connection.Execute(connectionString);

                        //var output = connection.Query<Item>($"SELECT * FROM items ORDER BY ContractID, PosNumber ASC ").ToList();
                        //return output;
                    }

                    throw;
                }

            }
        }

        /// <summary>
        /// Einlesen der Artikel nach ContractDaten sortiert
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllItemsContract()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                ReportDataTable table = new ReportDataTable();
                DataRow row;
                DataTable myTable = table.DataTable;

                try
                {
                    var output = connection.Query<Item>($"SELECT ContractID, AccountID, itemNumber, itemDescription, brand, color, size, prop, salesPrice, costPrice, beginDate, " +
                               "endDate, soldDate, payoutDate  FROM items WHERE DeleteDate = '' ORDER BY beginDate DESC ").ToList();
                    foreach (var item in output)
                    {
                        row = myTable.NewRow();

                        row["ContractID"] = item.ContractID;
                        row["AccountID"] = item.AccountID;
                        try
                        {
                            row["ItemNumber"] = item.ItemNumber;
                        }
                        catch (Exception)
                        {

                            row["ItemNumber"] = item.ItemNumber.Substring(0, 4);
                        }
                        row["ItemDescription"] = item.ItemDescription;
                        row["Brand"] = item.Brand;
                        row["Color"] = item.Color;
                        row["Size"] = item.Size;
                        row["Prop"] = item.Prop;
                        row["SalesPrice"] = item.SalesPrice;
                        row["CostPrice"] = item.CostPrice;
                        if (!String.IsNullOrEmpty(item.BeginDate))
                            row["BeginDate"] = item.BeginDate;
                        else
                            row["BeginDate"] = DBNull.Value;
                        if (!String.IsNullOrEmpty(item.EndDate))
                            row["EndDate"] = item.EndDate;
                        else
                            row["EndDate"] = DBNull.Value;
                        if (!String.IsNullOrEmpty(item.SoldDate))
                            row["SoldDate"] = item.SoldDate;
                        else
                            row["SoldDate"] = DBNull.Value;
                        if (!String.IsNullOrEmpty(item.PayoutDate))
                            row["PayoutDate"] = item.PayoutDate;
                        else
                            row["PayoutDate"] = DBNull.Value;

                        myTable.Rows.Add(row);
                    }
                    return myTable;
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Problem beim einlesen der Vertragnummern {ex}");
                    throw;
                }

            }
        }

        public DataTable GetAllItemsReportDeleted()
        {
            string test = Helper.ConnectionString;

            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                ReportDataTable table = new ReportDataTable();
                DataRow row;
                DataTable myTable = table.DataTable;

                try
                {
                    var output = connection.Query<Item>($"SELECT AccountID, itemNumber, itemDescription, brand, color, size, prop, salesPrice, costPrice, beginDate, " +
                               "endDate, soldDate, payoutDate  FROM items WHERE DeleteDate != '' ").ToList();
                    foreach (var item in output)
                    {
                        row = myTable.NewRow();

                        row["AccountID"] = item.AccountID;
                        try
                        {
                            row["ItemNumber"] = item.ItemNumber;
                        }
                        catch (Exception)
                        {

                            row["ItemNumber"] = item.ItemNumber.Substring(0, 4);
                        }

                        row["ItemDescription"] = item.ItemDescription;
                        row["Brand"] = item.Brand;
                        row["Color"] = item.Color;
                        row["Size"] = item.Size;
                        row["Prop"] = item.Prop;
                        row["SalesPrice"] = item.SalesPrice;
                        row["CostPrice"] = item.CostPrice;
                        if (!String.IsNullOrEmpty(item.BeginDate))
                            row["BeginDate"] = item.BeginDate;
                        else
                            row["BeginDate"] = DBNull.Value;
                        if (!String.IsNullOrEmpty(item.EndDate))
                            row["EndDate"] = item.EndDate;
                        else
                            row["EndDate"] = DBNull.Value;
                        if (!String.IsNullOrEmpty(item.SoldDate))
                            row["SoldDate"] = item.SoldDate;
                        else
                            row["SoldDate"] = DBNull.Value;
                        if (!String.IsNullOrEmpty(item.PayoutDate))
                            row["PayoutDate"] = item.PayoutDate;
                        else
                            row["PayoutDate"] = DBNull.Value;

                        //if (!String.IsNullOrEmpty(item.DeleteDate))
                        //    row["DeleteDate"] = item.DeleteDate;
                        //else
                        //    row["DeleteDate"] = DBNull.Value;

                        myTable.Rows.Add(row);
                    }
                    return myTable;
                }
                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 1 || ex.ErrorCode == 14)  //ErrorCodes abfragen
                    {
                        //string connectionString = "";
                        //connectionString = $"CREATE TABLE items (ContractID TEXT NOT NULL, itemNumber TEXT, ItemDescription TEXT, " +
                        //    $" SalesPrice REAL, CostPrice REAL, payoutDate TEXT, soldDate TEXT, " +
                        //    $" withLabel BOOL, posNumber TEXT)";
                        //connection.Execute(connectionString);

                        //var output = connection.Query<Item>($"SELECT * FROM items ORDER BY ContractID, PosNumber ASC ").ToList();
                        //return output;
                    }

                    throw;
                }

            }
        }

        public List<Item> GetAllAktItems()
        {
            string test = Helper.ConnectionString;

            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<Item>($"SELECT * FROM items ORDER BY itemNumber ASC ").ToList();
                    foreach (var item in output)
                    {
                        item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                        item.PayoutDate = Item.ConvertSQLiteTimeStringToDateString(item.PayoutDate);
                        item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                        item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                        item.DeleteDate = Item.ConvertSQLiteTimeStringToDateString(item.DeleteDate);
                    }
                    return output;
                }
                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 14 || ex.ErrorCode == 1)  //ErrorCodes abfragen
                    {
                        string connectionString = "";
                        connectionString = $"CREATE TABLE IF NOT EXISTS items (AccountID TEXT NOT NULL, ContractID TEXT NOT NULL, itemNumber TEXT NOT NULL UNIQUE, ItemDescription TEXT, " +
                            $" SalesPrice REAL, CostPrice REAL, payoutDate TEXT, soldDate TEXT, beginDate TEXT, endDate TEXT, " +
                            $" color TEXT, brand TEXT, prop TEXT, size TEXT, deleteDate TEXT NOT NULL DEFAULT '' )";
                        connection.Execute(connectionString);

                        var output = connection.Query<Item>($"SELECT * FROM items ORDER BY itemNumber ASC ").ToList();
                        foreach (var item in output)
                        {
                            item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                            item.PayoutDate = Item.ConvertSQLiteTimeStringToDateString(item.PayoutDate);
                            item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                            item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                            item.DeleteDate = Item.ConvertSQLiteTimeStringToDateString(item.DeleteDate);
                        }
                        return output;
                    }
                    throw;
                }
            }
        }

        public List<ItemReport> GetAllItemsForReport()
        {
            string test = Helper.ConnectionString;
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<ItemReport>($"SELECT * FROM items ORDER BY itemNumber ASC ").ToList();
                    foreach (var item in output)
                    {
                        item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                        item.PayoutDate = Item.ConvertSQLiteTimeStringToDateString(item.PayoutDate);
                        item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                        item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                        item.DeleteDate = Item.ConvertSQLiteTimeStringToDateString(item.DeleteDate);
                    }
                    return output;
                }
                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 14 || ex.ErrorCode == 1)  //ErrorCodes abfragen
                    {
                        string connectionString = "";
                        connectionString = $"CREATE TABLE IF NOT EXISTS items (AccountID TEXT NOT NULL, ContractID TEXT NOT NULL, itemNumber TEXT NOT NULL UNIQUE, ItemDescription TEXT, " +
                            $" SalesPrice REAL, CostPrice REAL, payoutDate TEXT, soldDate TEXT, beginDate TEXT, endDate TEXT, " +
                            $" color TEXT, brand TEXT, prop TEXT, size TEXT deleteDate TEXT)";
                        connection.Execute(connectionString);

                        var output = connection.Query<ItemReport>($"SELECT * FROM items ORDER BY itemNumber ASC ").ToList();
                        foreach (var item in output)
                        {
                            item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                            item.PayoutDate = Item.ConvertSQLiteTimeStringToDateString(item.PayoutDate);
                            item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                            item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                            item.DeleteDate = Item.ConvertSQLiteTimeStringToDateString(item.DeleteDate);
                        }
                        return output;
                    }
                    throw;
                }
            }
        }

        public List<Item> GetAllItemsSorted(string aColumnName, string aSortDirection)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<Item>($"SELECT * FROM items ORDER BY {aColumnName} {aSortDirection} ").ToList();
                foreach (var item in output)
                {
                    item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                    item.PayoutDate = Item.ConvertSQLiteTimeStringToDateString(item.PayoutDate);
                    item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                    item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                    item.DeleteDate = Item.ConvertSQLiteTimeStringToDateString(item.DeleteDate);
                }
                return output;
            }
        }

        public List<Item> GetItemsWithItemNumber(string anItemNumber)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<Item>($"SELECT *  FROM items WHERE items.itemNumber = '{ anItemNumber }' ").ToList();
                foreach (var item in output)
                {
                    item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                    item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                    item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                    item.PayoutDate = Item.ConvertSQLiteTimeStringToDateString(item.PayoutDate);
                    item.DeleteDate = Item.ConvertSQLiteTimeStringToDateString(item.DeleteDate);
                }
                return output;
            }
        }

        public List<Item> GetItemsWithContractID(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<Item>($"SELECT *  FROM items WHERE items.contractID = '{ aContractID }' ").ToList();
                foreach (var item in output)
                {
                    item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                    item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                }
                return output;
            }
        }

        public List<Item> GetItemsWithAccountID(string anAccountID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<Item>($"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID  WHERE contracts.AccountID = '{ anAccountID }' ORDER BY itemNumber ASC ").ToList();
                foreach (var item in output)
                {
                    item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                    item.PayoutDate = Item.ConvertSQLiteTimeStringToDateString(item.PayoutDate);
                    item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                    item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                    item.DeleteDate = Item.ConvertSQLiteTimeStringToDateString(item.DeleteDate);
                }
                return output;
            }
        }

        public List<Item> GetAllItemsWithAccountID(string anAccountID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<Item>($"SELECT *  FROM items  WHERE AccountID = '{ anAccountID }' ORDER BY itemNumber ASC ").ToList();
                foreach (var item in output)
                {
                    item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                    item.PayoutDate = Item.ConvertSQLiteTimeStringToDateString(item.PayoutDate);
                    item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                    item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                    item.DeleteDate = Item.ConvertSQLiteTimeStringToDateString(item.DeleteDate);
                }
                return output;
            }
        }

        public List<ItemGrouped> GetItemsWithContractIDGrouped(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<ItemGrouped>
                    ($"SELECT ContractID, posNumber, itemDescription, SUM(SalesPrice) as SumPrice, COUNT(posNUmber) as ItemCount,  SUM(WithLabel) as WithLabelCount FROM items WHERE ContractID = '{ aContractID }' GROUP BY PosNumber ").ToList();
                return output;
            }
        }

        public List<ItemAllGrouped> GetAllItemsGrouped()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<ItemAllGrouped>
                    ($"SELECT ContractID, SUM(SalesPrice) as SumPrice, SUM(CostPrice) as SumCost, COUNT(itemNumber) as ItemCount  " +
                    $"FROM items " +
                    $"GROUP BY ContractID ").ToList();
                return output;
            }
        }

        public List<ItemAllGrouped> GetAllItemsGrouped(string anAccountID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<ItemAllGrouped>
                    ($"SELECT ContractID, SUM(SalesPrice) as SumPrice, SUM(CostPrice) as SumCost, COUNT(itemNumber) as ItemCount  " +
                    $"FROM items " +
                    $"GROUP BY ContractID WHERE accountId = {anAccountID} ").ToList();
                return output;
            }
        }

        public List<ItemAllGrouped> GetAllItemsGroupedSoldNotPayed(string anAccountID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<ItemAllGrouped>
                    ($"SELECT ContractID, SUM(SalesPrice) as SumPrice, SUM(CostPrice) as SumCost  " +
                    $"FROM items WHERE accountId = {anAccountID} AND soldDate <> '' AND payoutDate = ''  " +
                    $"GROUP BY accountID ").ToList();
                return output;
            }
        }

        public List<ItemAllGrouped> GetAllItemsGroupedNotSold(string anAccountID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<ItemAllGrouped>
                    ($"SELECT accountID, SUM(SalesPrice) as SumPrice, SUM(CostPrice) as SumCost  " +
                    $"FROM items WHERE accountId = {anAccountID} AND soldDate = '' " +
                    $"GROUP BY accountID ").ToList();
                return output;
            }
        }

        public List<ItemAllGrouped> GetAllItemsGroupedSoldNotPayedButSold(string anAccountID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<ItemAllGrouped>
                    ($"SELECT ContractID, SUM(SalesPrice) as SumPrice, SUM(CostPrice) as SumCost  " +
                    $"FROM items WHERE accountId = {anAccountID} AND soldDate <> '' AND payoutDate = ''  " +
                    $"GROUP BY accountID ").ToList();
                return output;
            }
        }

        public List<ItemAllGroupedByItemNumber> GetAllItemsGroupedByItemNumber()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<ItemAllGroupedByItemNumber>
                    ($"SELECT ItemNumber, COUNT(itemNumber) as ItemsCount FROM items GROUP BY ItemNumber  ").ToList();
                return output;
            }
        }

        //Alle Artikel, die heute verkauft wurden
        public List<CashCloseSoldItem> GetItemsCashCloseSold()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString;
                string myAktDate = DateTime.Today.ToShortDateString();
                myAktDate = Item.ConvertDateStringToSQLiteTimeString(myAktDate);
                connectionString = $"SELECT  contractID, items.itemNumber, items.AccountID, customers.LastName, customers.FirstName, itemDescription, salesPrice, costPrice " +
                    $"FROM items LEFT JOIN customers ON items.AccountID = customers.AccountID " +
                    $"WHERE items.SoldDate = '{myAktDate}' ";
                var output = connection.Query<CashCloseSoldItem>(connectionString).ToList();
                return output;
            }
        }

        public List<CashClosePayedItem> GetItemsCashClosePayed()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string myAktDate = DateTime.Today.ToShortDateString();
                myAktDate = Item.ConvertDateStringToSQLiteTimeString(myAktDate);
                string connectionString = $"SELECT contractID, items.itemNumber, items.AccountID, customers.LastName, customers.FirstName, itemDescription, CostPrice " +
                    $"FROM items LEFT JOIN customers ON items.AccountID = customers.AccountID " +
                    $"WHERE PayoutDate = '{myAktDate}'  ";
                var output = connection.Query<CashClosePayedItem>(connectionString).ToList();
                return output;
            }
        }

        public decimal GetItemsTotalSumToPay()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
                {
                    var output = connection.Query<decimal>
                    ($"SELECT  " +
                        $"Sum(CostPrice) AS SumTotalSumToPay " +
                        $"FROM items " +
                        $"WHERE PayoutDate = '' AND SoldDate <> '' ").ToList();
                    if (output != null)
                        return Convert.ToDecimal(output[0]);
                    else
                        return (decimal)0.00;
                }
            }
            catch
            {
                return (decimal)0.00;
            }
        }

        public List<ItemSoldGrouped> GetItemsWithContractIDGroupedSold(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<ItemSoldGrouped>
                    ($"SELECT SoldDate, posNumber, itemDescription, SUM(SalesPrice) as SumPrice, COUNT(posNUmber) as ItemCount FROM items " +
                    $"WHERE ContractID = '{ aContractID }' AND SoldDate <> ''  GROUP BY SoldDate, PosNumber ").ToList();
                foreach (var item in output)
                    item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                return output;
            }
        }

        public List<ItemSoldGrouped> GetItemsWithContractIDGroupedSoldNotPayed(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<ItemSoldGrouped>
                    ($"SELECT SoldDate, posNumber, itemDescription, SUM(SalesPrice) as SumPrice, COUNT(posNUmber) as ItemCount FROM items " +
                    $"WHERE ContractID = '{ aContractID }' AND SoldDate <> '' AND PayoutDate = '' GROUP BY SoldDate, PosNumber ").ToList();
                foreach (var item in output)
                    item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                return output;
            }
        }

        public List<ItemPayedGrouped> GetItemsWithContractIDGroupedPayed(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<ItemPayedGrouped>
                    ($"SELECT PayoutDate, SUM(CostPrice) as SumPayed FROM items WHERE ContractID = '{ aContractID }' AND PayoutDate <> '' GROUP BY PayoutDate ").ToList();
                foreach (var item in output)
                    item.PayoutDate = Item.ConvertSQLiteTimeStringToDateString(item.PayoutDate);
                return output;
            }
        }

        public List<Item> GetItemsWithContractIDLabelPrint(string aContractID, string aPosNumberFrom, string aPosNumberTo)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<Item>($"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID" +
                    $" WHERE items.contractID = '{ aContractID }' AND items.WithLabel = '1' AND PosNumber >= '{aPosNumberFrom}' " +
                    $" AND PosNumber <= '{aPosNumberTo}' ORDER BY PosNumber ASC ").ToList();
                foreach (var item in output)
                {
                    item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                    item.PayoutDate = Item.ConvertSQLiteTimeStringToDateString(item.PayoutDate);
                }
                return output;
            }
        }

        public List<Item> GetItemsWithContractIDLabelPrintOne(string aContractID, string aPosNumber, string anItemNumber)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<Item>($"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID" +
                    $" WHERE items.contractID = '{ aContractID }' AND items.WithLabel = '1' AND PosNumber >= '{ aPosNumber }' " +
                    $" AND itemNumber <= '{ anItemNumber }' ORDER BY PosNumber ASC ").ToList();
                foreach (var item in output)
                {
                    item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                    item.PayoutDate = Item.ConvertSQLiteTimeStringToDateString(item.PayoutDate);
                }
                return output;
            }
        }

        public List<ItemReturnGrouped> GetItemsWithContractIDReturnListTotal(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                var output = connection.Query<ItemReturnGrouped>($"SELECT PosNumber, ItemDescription, SalesPrice, COUNT(PosNumber) AS TotalItemsCount " +
                   $" FROM items " +
                   $" WHERE ContractID = '{ aContractID }' " +
                   $" GROUP BY ItemDescription, SalesPrice, SoldDate " +
                   $" (SELECT PosNumber, ItemDescription, SalesPrice, ) ").ToList();
                return output;
            }
        }

        public List<Item> GetItemsWithContractIDNotSold(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                var output = connection.Query<Item>($"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID  " +
                    $"WHERE items.contractID = '{ aContractID }' AND SoldDate = '' ORDER BY PosNumber ASC ").ToList();
                foreach (var item in output)
                {
                    item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                    item.PayoutDate = Item.ConvertSQLiteTimeStringToDateString(item.PayoutDate);
                }
                return output;
            }
        }

        public List<Item> GetItemsWithAccountIDNotPayed(string anAccountID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                var output = connection.Query<Item>($"SELECT accountID, itemNumber, itemDescription, color, brand, prop, " +
                    $"size, beginDate, salesPrice, costPrice, soldDate  FROM items " +
                    $"WHERE accountID = '{ anAccountID }' AND payoutDate = '' AND DeleteDate = '' ORDER BY itemNumber ASC ").ToList();
                foreach (var item in output)
                {
                    item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                    item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                    item.SalesPrice = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", Convert.ToDecimal(item.SalesPrice));
                }
                return output;
            }
        }

        //Alle Artikel verkauft aber nicht ausbezahlt
        public DataTable GetItemsWithAccountIDNotPayedToDT(string anAccountID)
        {
            ReportDataTable table = new ReportDataTable();
            DataRow row;
            DataTable myTable = table.DataTable;

            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {

                try
                {
                    var output = connection.Query<Item>($"SELECT accountID, itemNumber, itemDescription, color, brand, prop, " +
                        $"size, beginDate, salesPrice, costPrice, soldDate  FROM items " +
                        $"WHERE accountID = '{ anAccountID }' AND payoutDate = '' AND DeleteDate = '' ORDER BY itemNumber ASC ").ToList();

                    foreach (var item in output)
                    {
                        row = myTable.NewRow();

                        row["AccountID"] = item.AccountID;
                        try
                        {
                            row["ItemNumber"] = item.ItemNumber;
                        }
                        catch (Exception)
                        {

                            row["ItemNumber"] = item.ItemNumber.Substring(0, 4);
                        }

                        row["ItemDescription"] = item.ItemDescription;
                        row["Brand"] = item.Brand;
                        row["Color"] = item.Color;
                        row["Size"] = item.Size;
                        row["Prop"] = item.Prop;
                        row["SalesPrice"] = item.SalesPrice;
                        row["CostPrice"] = item.CostPrice;
                        if (!String.IsNullOrEmpty(item.BeginDate))
                            row["BeginDate"] = item.BeginDate;
                        else
                            row["BeginDate"] = DBNull.Value;
                        if (!String.IsNullOrEmpty(item.EndDate))
                            row["EndDate"] = item.EndDate;
                        else
                            row["EndDate"] = DBNull.Value;
                        if (!String.IsNullOrEmpty(item.SoldDate))
                            row["SoldDate"] = item.SoldDate;
                        else
                            row["SoldDate"] = DBNull.Value;
                        if (!String.IsNullOrEmpty(item.PayoutDate))
                            row["PayoutDate"] = item.PayoutDate;
                        else
                            row["PayoutDate"] = DBNull.Value;

                        myTable.Rows.Add(row);
                    }
                    return myTable;
                }
                catch (SQLiteException ex)
                {

                    MessageBox.Show($"Fehlercode: {ex.ErrorCode} ");

                    throw;
                }

            }

            //foreach (var item in output)
            //{
            //    item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
            //    item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
            //    item.SalesPrice = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", Convert.ToDecimal(item.SalesPrice));
            //}
            //return output;
    }

        public List<Item> GetItemsWithAccountIDNotPayedButSold(string anAccountID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                var output = connection.Query<Item>($"SELECT accountID, itemNumber, itemDescription, color, brand, prop, " +
                    $"size, beginDate, salesPrice, costPrice, soldDate  FROM items " +
                    $"WHERE accountID = '{ anAccountID }' AND payoutDate = '' AND soldDate <> '' ORDER BY itemNumber ASC ").ToList();
                foreach (var item in output)
                {
                    item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                    item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                    item.SalesPrice = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", Convert.ToDecimal(item.SalesPrice));
                    item.CostPrice = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", Convert.ToDecimal(item.CostPrice));
                }
                return output;
            }
        }

        public List<ItemReport> GetItemsWithStatusAllNotDeleted() //alle Artikel im Laden 
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                connectionString = $"SELECT *  FROM items  " +
                    $" WHERE deletedDate = ''  ORDER BY itemNumber ";
                var output = connection.Query<ItemReport>(connectionString).ToList();
                return output;
            }
        }

        public List<ItemReport> GetItemsWithStatusAllDeleted() //alle Artikel im Laden 
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                connectionString = $"SELECT *  FROM items  " +
                    $" WHERE deletedDate <> ''  ORDER BY itemNumber ";
                var output = connection.Query<ItemReport>(connectionString).ToList();
                return output;
            }
        }

        private string GetConnectionString(string anID, string anItemDescription, string aBrand, string aColor, string aSize, string aProperty)
        {
                //000000 0
                if (String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  ";
                //000001 1
                if (String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE size LIKE '{ aSize }'  ";
                //000010 2
                if (String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE color LIKE '{ aColor }%' ";
                //000011 3
                if (String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE color LIKE '{ aColor }%' AND size LIKE '{ aSize }'  ";
                //000100  4
                if (String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE brand LIKE '{ aBrand }%' ";
                //000101 5
                if (String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE brand LIKE '{ aBrand }%' AND size LIKE '{ aSize }'  ";
                //000110 6
                if (String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE brand LIKE '{ aBrand }%' AND color LIKE '{ aColor }%'  ";
                //000111 7
                if (String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE brand LIKE '{ aBrand }%' AND color LIKE '{ aColor }%' AND size LIKE '{ aSize }' ";
                //001000 8
                if (String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE accountID LIKE '{ anID }%'  ";
                //001001 9
                if (String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE accountID LIKE '{ anID }%' AND size LIKE '{ aSize }' ";
                //001010 10
                if (String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE accountID LIKE '{ anID }%' AND color LIKE '{ aColor }%' ";
                //001011 11
                if (String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE accountID LIKE '{ anID }%' AND color LIKE '{ aColor }%' AND size LIKE '{ aSize }' ";
                //001100 12
                if (String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE accountID LIKE '{ anID }%' AND brand LIKE '{ aBrand }%'  ";
                //001101 13
                if (String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE accountID LIKE '{ anID }%' AND brand LIKE '{ aBrand }%' AND size LIKE '{ aSize }'  ";
                //001110 14
                if (String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE accountID LIKE '{ anID }%' AND brand LIKE '{ aBrand }%' AND color LIKE '{ aColor }%'  ";
                //001111 15
                if (String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE accountID LIKE '{ anID }%' AND brand LIKE '{ aBrand }%' AND color LIKE '{ aColor }%' AND size LIKE '{ aSize }'  ";

                //010000 16
                if (String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE prop LIKE '{ aProperty }%'  ";
                //010001 17
                if (String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE size LIKE '{ aSize }'   AND prop LIKE '{ aProperty }%' ";
                //010010 18
                if (String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE color LIKE '{ aColor }%'  AND prop LIKE '{ aProperty }%' ";
                //010011 19
                if (String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE color LIKE '{ aColor }%' AND size LIKE '{ aSize }'  AND prop LIKE '{ aProperty }%'  ";
                //010100  20
                if (String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE  brand LIKE '{ aBrand }%' AND prop LIKE '{ aProperty }%'  ";
                //010101 21
                if (String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE brand LIKE '{ aBrand }%' AND size LIKE '{ aSize }'  AND prop LIKE '{ aProperty }%'  ";
                //010110 22
                if (String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE brand LIKE '{ aBrand }%' AND color LIKE '{ aColor }%'   AND prop LIKE '{ aProperty }%' ";
                //010111 23
                if (String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE brand LIKE '{ aBrand }%' AND color LIKE '{ aColor }%' AND size LIKE '{ aSize }'  AND prop LIKE '{ aProperty }%' ";
                //011000 24
                if (String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE accountID LIKE '{ anID }%' AND size LIKE '{ aSize }'  AND prop LIKE '{ aProperty }%' ";
                //011001 25
                if (String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE accountID LIKE '{ anID }%' AND size LIKE '{ aSize }'  AND prop LIKE '{ aProperty }%' ";
                //011010 26
                if (String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE accountID LIKE '{ anID }%' AND color LIKE '{ aColor }%'  AND prop LIKE '{ aProperty }%' ";
                //011011 27
                if (String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE accountID LIKE '{ anID }%' AND color LIKE '{ aColor }%' AND size LIKE '{ aSize }'  AND prop LIKE '{ aProperty }%' ";
                //011100 28
                if (String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE accountID LIKE '{ anID }%' AND brand LIKE '{ aBrand }%'   AND prop LIKE '{ aProperty }%' ";
                //011101 29
                if (String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE accountID LIKE '{ anID }%' AND brand LIKE '{ aBrand }%' AND size LIKE '{ aSize }'   AND prop LIKE '{ aProperty }%' ";
                //011110 30
                if (String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE accountID LIKE '{ anID }%' AND brand LIKE '{ aBrand }%' AND color LIKE '{ aColor }%'  AND prop LIKE '{ aProperty }%'  ";
                //011111 31
                if (String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE accountID LIKE '{ anID }%' AND brand LIKE '{ aBrand }%' AND color LIKE '{ aColor }%' AND size LIKE '{ aSize }'   AND prop LIKE '{ aProperty }%' ";

                //100000 32
                if (!String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT * FROM items " +
                         $"WHERE itemDescription LIKE '{ anItemDescription }%'  ";

                //100001 33
                if (!String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND size LIKE '{ aSize }'  ";
                //100010 34
                if (!String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND color LIKE '{ aColor }%' ";
                //100011 35
                if (!String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND color LIKE '{ aColor }%' AND size LIKE '{ aSize }'  ";
                //100100  36
                if (!String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND brand LIKE '{ aBrand }%' ";
                //100101 37
                if (!String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND brand LIKE '{ aBrand }%' AND size LIKE '{ aSize }'  ";
                //100110 38
                if (!String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND brand LIKE '{ aBrand }%' AND color LIKE '{ aColor }%'  ";
                //100111 39
                if (!String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND brand LIKE '{ aBrand }%' AND color LIKE '{ aColor }%' AND size LIKE '{ aSize }' ";
                //101000 40
                if (!String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND accountID LIKE '{ anID }%'  ";
                //101001 41
                if (!String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND accountID LIKE '{ anID }%' AND size LIKE '{ aSize }' ";
                //101010 42
                if (!String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND accountID LIKE '{ anID }%' AND color LIKE '{ aColor }%' ";
                //101011 43
                if (!String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND accountID LIKE '{ anID }%' AND color LIKE '{ aColor }%' AND size LIKE '{ aSize }' ";
                //101100 44
                if (!String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND accountID LIKE '{ anID }%' AND brand LIKE '{ aBrand }%'  ";
                //101101 45
                if (!String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND accountID LIKE '{ anID }%' AND brand LIKE '{ aBrand }%' AND size LIKE '{ aSize }'  ";
                //101110 46
                if (!String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND accountID LIKE '{ anID }%' AND brand LIKE '{ aBrand }%' AND color LIKE '{ aColor }%'  ";
                //101111 47
                if (!String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND  accountID LIKE '{ anID }%' AND brand LIKE '{ aBrand }%' AND color LIKE '{ aColor }%' AND size LIKE '{ aSize }'  ";

                //110000 48
                if (!String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND prop LIKE '{ aProperty }%'  ";
                //110001 49
                if (!String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND size LIKE '{ aSize }'   AND prop LIKE '{ aProperty }%' ";
                //110010 50
                if (!String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND color LIKE '{ aColor }%'  AND prop LIKE '{ aProperty }%' ";
                //110011 51
                if (!String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND color LIKE '{ aColor }%' AND size LIKE '{ aSize }'  AND prop LIKE '{ aProperty }%'  ";
                //110100  52
                if (!String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND brand LIKE '{ aBrand }%' AND prop LIKE '{ aProperty }%'  ";
                //110101 53
                if (!String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND brand LIKE '{ aBrand }%' AND size LIKE '{ aSize }'  AND prop LIKE '{ aProperty }%'  ";
                //110110 54
                if (!String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND brand LIKE '{ aBrand }%' AND color LIKE '{ aColor }%'   AND prop LIKE '{ aProperty }%' ";
                //110111 55
                if (!String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND brand LIKE '{ aBrand }%' AND color LIKE '{ aColor }%' AND size LIKE '{ aSize }'  AND prop LIKE '{ aProperty }%' ";
                //111000 56
                if (!String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND accountID LIKE '{ anID }%' AND size LIKE '{ aSize }'  AND prop LIKE '{ aProperty }%' ";
                //111001 57
                if (!String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND accountID LIKE '{ anID }%' AND size LIKE '{ aSize }'  AND prop LIKE '{ aProperty }%' ";
                //111010 58
                if (!String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND accountID LIKE '{ anID }%' AND color LIKE '{ aColor }%'  AND prop LIKE '{ aProperty }%' ";
                //111011 59
                if (!String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND accountID LIKE '{ anID }%' AND color LIKE '{ aColor }%' AND size LIKE '{ aSize }'  AND prop LIKE '{ aProperty }%' ";
                //111100 60
                if (!String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND accountID LIKE '{ anID }%' AND brand LIKE '{ aBrand }%'   AND prop LIKE '{ aProperty }%' ";
                //111101 61
                if (!String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND accountID LIKE '{ anID }%' AND brand LIKE '{ aBrand }%' AND size LIKE '{ aSize }'   AND prop LIKE '{ aProperty }%' ";
                //111110 62
                if (!String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND accountID LIKE '{ anID }%' AND brand LIKE '{ aBrand }%' AND color LIKE '{ aColor }%'  AND prop LIKE '{ aProperty }%'  ";
                //111111 63
                if (!String.IsNullOrEmpty(anItemDescription) && !String.IsNullOrEmpty(anID) && !String.IsNullOrEmpty(aBrand) && !String.IsNullOrEmpty(aColor) && !String.IsNullOrEmpty(aSize) && !String.IsNullOrEmpty(aProperty))
                    return $"SELECT *  FROM items  " +
                        $"WHERE itemDescription LIKE '{ anItemDescription }%'  AND accountID LIKE '{ anID }%' AND brand LIKE '{ aBrand }%' AND color LIKE '{ aColor }%' AND size LIKE '{ aSize }'   AND prop LIKE '{ aProperty }%' ";

            return $"SELECT *  FROM items  ORDER BY ";
        }

        //alle Artikel (Filter = AccountID and Brand and Color and Size)
        public List<ItemReport> GetItemsWithStatusAll(string anID, string anItemDescription, string aBrand, string aColor, string aSize, string aProperty, string beginDate, string endDate, bool deletedItem)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = GetConnectionString(anID, anItemDescription, aBrand, aColor, aSize, aProperty);
                beginDate = Item.ConvertDateStringToSQLiteTimeString(beginDate);
                endDate = Item.ConvertDateStringToSQLiteTimeString(endDate);
                if (!deletedItem)
                {
                    if (String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                        connectionString += $"  WHERE BeginDate >= '{ beginDate }' AND BeginDate <= '{ endDate }' AND deleteDate = '' ORDER BY itemNumber ";
                    else
                        connectionString += $"  AND  BeginDate >= '{ beginDate }' AND BeginDate <= '{ endDate }' AND deleteDate = '' ORDER BY itemNumber";
                }
                else
                {
                    if (String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                        connectionString += $"  WHERE BeginDate >= '{ beginDate }' AND BeginDate <= '{ endDate }' AND deleteDate <> '' ORDER BY itemNumber ";
                    else
                        connectionString += $"  AND  BeginDate >= '{ beginDate }' AND BeginDate <= '{ endDate }' AND deleteDate <> '' ORDER BY itemNumber";
                }

                var output = connection.Query<ItemReport>(connectionString).ToList();
                ConvertItemsDateFields(output);
                return output;
            }
        }

        //alle Artikel im Laden
        public List<ItemReport> GetItemsWithStatusInStore() //alle Artikel im Laden (Filter = ContractID oder AccountID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                    connectionString = $"SELECT *  FROM items  " +
                        $" WHERE SoldDate = '' ORDER BY itemNumber ";
                var output = connection.Query<ItemReport>(connectionString).ToList();
                ConvertItemsDateFields(output);
                return output;
            }
        }

        //alle Artikel im Laden (Filter = AccountID and Brand and Color and Size)
        public List<ItemReport> GetItemsWithStatusInStore(string anID, string anItemDescription, string aBrand, string aColor, string aSize, string aProperty, string beginDate, string endDate, bool deletedItem)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                beginDate = Item.ConvertDateStringToSQLiteTimeString(beginDate);
                endDate = Item.ConvertDateStringToSQLiteTimeString(endDate);
                string connectionString = GetConnectionString(anID, anItemDescription, aBrand, aColor, aSize, aProperty);
                if (!deletedItem)
                {
                    if (String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                        connectionString += $"  WHERE SoldDate = '' AND BeginDate >= '{ beginDate }' AND BeginDate <= '{ endDate }' AND deleteDate = '' ORDER BY itemNumber ";
                    else
                        connectionString += $"  AND SoldDate = '' AND BeginDate >= '{ beginDate }' AND BeginDate <= '{ endDate }' AND deleteDate = '' ORDER BY itemNumber ";
                }
                else
                {
                    if (String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                        connectionString += $"  WHERE SoldDate >= '{ beginDate }' AND SoldDate <= '{ endDate }' AND deleteDate <> '' ORDER BY itemNumber ";
                    else
                        connectionString += $"  AND SoldDate >= '{ beginDate }' AND SoldDate <= '{ endDate }' AND deleteDate <> '' ORDER BY itemNumber ";
                }
                var output = connection.Query<ItemReport>(connectionString).ToList();
                ConvertItemsDateFields(output);
                return output;
            }
        }

        //Alle Artikel Ausbezahlt 
        public List<ItemReport> GetItemsWithStatusPayed(string beginDate, string endDate) //Endabrechnung erfolgt (Filter = start und endDatum)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                beginDate = Item.ConvertDateStringToSQLiteTimeString(beginDate);
                endDate = Item.ConvertDateStringToSQLiteTimeString(endDate);
                string connectionString = "";
                connectionString = $"SELECT *  FROM items  " +
                    $" WHERE PayoutDate >= '{ beginDate }' AND PayoutDate <= '{ endDate }' ORDER BY itemNumber ";
                var output = connection.Query<ItemReport>(connectionString).ToList();
                ConvertItemsDateFields(output);
                return output;
            }
        }

        //alle Artikel ausbezahlt (Filter = AccountID and Brand and Color and Size)
        public List<ItemReport> GetItemsWithStatusPayed(string anID, string anItemDescription, string aBrand, string aColor, string aSize, string aProperty, string beginDate, string endDate, bool deletedItem)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                beginDate = Item.ConvertDateStringToSQLiteTimeString(beginDate);
                endDate = Item.ConvertDateStringToSQLiteTimeString(endDate);
                string connectionString = GetConnectionString(anID, anItemDescription, aBrand, aColor, aSize, aProperty );
                if (!deletedItem)
                {
                    if (String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                        connectionString += $"  WHERE PayoutDate >= '{ beginDate }' AND PayoutDate <= '{ endDate }' AND deleteDate = '' ORDER BY itemNumber ";
                    else
                        connectionString += $"  AND PayoutDate >= '{ beginDate }' AND PayoutDate <= '{ endDate }' AND deleteDate = '' ORDER BY itemNumber ";
                }
                else
                {
                    if (String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                        connectionString += $"  WHERE SoldDate >= '{ beginDate }' AND SoldDate <= '{ endDate }' AND deleteDate <> '' ORDER BY itemNumber ";
                    else
                        connectionString += $"  AND SoldDate >= '{ beginDate }' AND SoldDate <= '{ endDate }' AND deleteDate <> '' ORDER BY itemNumber ";
                }
                var output = connection.Query<ItemReport>(connectionString).ToList();
                ConvertItemsDateFields(output);
                return output;
            }
        }

        //Alle Artikel verkauft 
        public List<ItemReport> GetItemsWithStatusSold(string beginDate, string endDate) //Endabrechnung erfolgt (Filter = start und endDatum)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                beginDate = ItemReport.ConvertDateStringToSQLiteTimeString(beginDate);
                endDate = ItemReport.ConvertDateStringToSQLiteTimeString(endDate);
                string connectionString = "";
                connectionString = $"SELECT *  FROM items " +
                    $" WHERE SoldDate >= '{ beginDate }' AND SoldDate <= '{ endDate }' ORDER BY itemNumber ";
                var output = connection.Query<ItemReport>(connectionString).ToList();
                ConvertItemsDateFields(output);
                return output;
            }
        }

        //alle Artikel verkauft (Filter = AccountID and Brand and Color and Size)
        public List<ItemReport> GetItemsWithStatusSold(string anID, string anItemDescription, string aBrand, string aColor, string aSize, string aProperty, string beginDate, string endDate, bool deletedItem)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                beginDate = ItemReport.ConvertDateStringToSQLiteTimeString(beginDate);
                endDate = ItemReport.ConvertDateStringToSQLiteTimeString(endDate);
                string connectionString = GetConnectionString(anID, anItemDescription, aBrand, aColor, aSize, aProperty);
                if (!deletedItem)
                {
                    if (String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                        connectionString += $"  WHERE SoldDate >= '{ beginDate }' AND SoldDate <= '{ endDate }' AND deleteDate = '' ORDER BY itemNumber ";
                    else
                        connectionString += $"  AND SoldDate >= '{ beginDate }' AND SoldDate <= '{ endDate }' AND deleteDate = '' ORDER BY itemNumber ";
                }
                else
                {
                    if (String.IsNullOrEmpty(anID) && String.IsNullOrEmpty(anItemDescription) && String.IsNullOrEmpty(aBrand) && String.IsNullOrEmpty(aColor) && String.IsNullOrEmpty(aSize) && String.IsNullOrEmpty(aProperty))
                        connectionString += $"  WHERE SoldDate >= '{ beginDate }' AND SoldDate <= '{ endDate }' AND deleteDate <> '' ORDER BY itemNumber ";
                    else
                        connectionString += $"  AND SoldDate >= '{ beginDate }' AND SoldDate <= '{ endDate }' AND deleteDate <> '' ORDER BY itemNumber ";
                }
                var output = connection.Query<ItemReport>(connectionString).ToList();
                ConvertItemsDateFields(output);
                return output;
            }
        }


        public List<ItemReport> GetItemsWithStatusClosed(string beginDate, string endDate) //Endabrechnung erfolgt (Filter = start und endDatum)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                beginDate = ItemReport.ConvertDateStringToSQLiteTimeString(beginDate);
                endDate = ItemReport.ConvertDateStringToSQLiteTimeString(endDate);
                string connectionString = "";
                connectionString = $"SELECT *  FROM items  " +
                    $" WHERE CloseDate >= '{ beginDate }' AND CloseDate <= '{ endDate }' ORDER BY itemNumber ";
                var output = connection.Query<ItemReport>(connectionString).ToList();
                ConvertItemsDateFields(output);
                return output;
            }
        }

        public List<ItemReport> GetItemsWithStatusClosed(string anID, string beginDate, string endDate) //Endabrechnung erfolgt (Filter = ContractID oder AccountID und start- und endDatum)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                beginDate = ItemReport.ConvertDateStringToSQLiteTimeString(beginDate);
                endDate = ItemReport.ConvertDateStringToSQLiteTimeString(endDate);
                string connectionString = "";
                if (anID.Length == 4)
                    connectionString = $"SELECT *  FROM items  " +
                        $" WHERE accountID = '{ anID }' AND CloseDate >= '{ beginDate }' AND CloseDate <= '{ endDate }' ORDER BY itemNumber ";
                var output = connection.Query<ItemReport>(connectionString).ToList();
                ConvertItemsDateFields(output);
                return output;
            }
        }

        public static List<ItemReport> ConvertItemsDateFields(List<ItemReport> anItemsList)
        {
            foreach (var item in anItemsList)
            {
                item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                item.PayoutDate = Item.ConvertSQLiteTimeStringToDateString(item.PayoutDate);
                item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                item.ContractID = Item.ConvertContractIDToContractNumber(item.ContractID);
            }
            return anItemsList;
        }

        public List<ItemSalesVolumeGrouped> GetItemsGroupedSalesVolume(string aContractID, string anAccountID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                if (!String.IsNullOrWhiteSpace(aContractID))
                {
                    connectionString = $"SELECT items.ContractID,  itemDescription, SoldDate, COUNT(posNUmber) as ItemCount, contracts. Margin, SUM(SalesPrice) as SumPrice, SUM(CostPrice) as SumCostPrice  " + 
                        $"FROM items LEFT JOIN contracts ON items.contractID = contracts.ContractID " +
                        $"WHERE items.contractID = '{ aContractID }' AND items.SoldDate <> '' " + 
                        $"GROUP BY items.ContractID, PosNumber ORDER BY items.ContractID, PosNumber ";
                }
                if (!String.IsNullOrWhiteSpace(anAccountID))
                {
                    connectionString = $"SELECT items.ContractID,  itemDescription, SoldDate, COUNT(posNUmber) as ItemCount, contracts. Margin, SUM(SalesPrice) as SumPrice, SUM(CostPrice) as SumCostPrice  FROM items LEFT JOIN contracts ON items.contractID = contracts.ContractID " +
                        $" WHERE contracts.AccountID = '{ aContractID }' AND items.SoldDate <> '' GROUP BY items.ContractID, PosNumber ORDER BY items.ContractID, PosNumber ";
                }
                if (String.IsNullOrWhiteSpace(anAccountID) && String.IsNullOrWhiteSpace(aContractID))
                {
                    connectionString = $"SELECT items.ContractID,  itemDescription, SoldDate, COUNT(posNUmber) as SoldCount, contracts. Margin as Comission, SUM(SalesPrice) as SumSoldPrice, SUM(CostPrice) as SumCostPrice  FROM items LEFT JOIN contracts ON items.contractID = contracts.ContractID " +
                        $"WHERE items.SoldDate <> '' GROUP BY items.ContractID, PosNumber ORDER BY items.ContractID, PosNumber ";
                }
                var output = connection.Query<ItemSalesVolumeGrouped>(connectionString).ToList();
                foreach (var item in output)
                {
                    item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                }
                return output;
            }
        }

        public List<Item> GetAllItemsSold()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                var output = connection.Query<Item>($"SELECT *  FROM items WHERE SoldDate <> '' ORDER BY SoldDate ASC ").ToList();
                foreach (var item in output)
                {
                    item.SoldDate = Item.ConvertSQLiteTimeStringToDateString(item.SoldDate);
                    item.PayoutDate = Item.ConvertSQLiteTimeStringToDateString(item.PayoutDate);
                    item.BeginDate = Item.ConvertSQLiteTimeStringToDateString(item.BeginDate);
                    item.EndDate = Item.ConvertSQLiteTimeStringToDateString(item.EndDate);
                }
                return output;
            }
        }

        public List<CashVolumeMonthly> GetMonthlySums()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString;
                ArrayList myMonatsListe = new ArrayList();
                string[] myMonate = { "Jan", "Feb", "Mrz", "April", "Mai", "Juni", "Juli", "Aug", "Sep", "Okt", "Nov", "Dez" };
                connectionString = $"SELECT strftime('%Y' , soldDate) as Year, strftime('%m', soldDate) as Monthname, SUM(salesPrice) as SalesSum, a.CostSum FROM items " +
                                   $"Left Join " +
                                   $"(Select strftime('%Y', payoutDate) as year1, strftime('%m', payoutDate) as monthname1, Sum(costPrice) as CostSum " +
                                   $"FROM items Where payoutDate<> '' " +
                                   $"GROUP BY year1, monthname1) AS a " +
                                   $"ON Year = a.year1 And monthname = a.monthname1 " +
                                   $"WHERE soldDate<> '' GROUP BY Year, Monthname ";
                var output = connection.Query<CashVolumeMonthly>(connectionString).ToList();
                foreach (var item in output)
                {
                    item.ProvisionSum = item.SalesSum - item.CostSum;
                    item.Monthname = myMonate[Convert.ToInt32( item.Monthname)-1];
                }
                return output;
            }
        }

        public void InsertItem(Item anItem)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string soldDate, payoutDate, beginDate, endDate, deleteDate;
                soldDate = Item.ConvertDateStringToSQLiteTimeString(anItem.SoldDate);
                payoutDate = Item.ConvertDateStringToSQLiteTimeString(anItem.PayoutDate);
                endDate = Item.ConvertDateStringToSQLiteTimeString(anItem.EndDate);
                beginDate = Item.ConvertDateStringToSQLiteTimeString(anItem.BeginDate);
                deleteDate = Item.ConvertDateStringToSQLiteTimeString(anItem.DeleteDate);

                string connectionString = $"INSERT INTO items ( [AccountID], [contractID], [itemNumber], [itemDescription],  [salesPrice], [costPrice], [payoutDate], " +
                                          $"[soldDate], [BeginDate], [EndDate], [DeleteDate], [color], [brand], [prop], [size])  " +
                                          $" VALUES( '{anItem.AccountID}', '{anItem.ContractID}', '{anItem.ItemNumber}', '{Store.SQLEscape(anItem.ItemDescription)}', '{anItem.SalesPrice}', " + 
                                          $"'{anItem.CostPrice}', '{payoutDate}', '{soldDate}', '{beginDate}', '{endDate}', '{deleteDate}', '{Store.SQLEscape(anItem.Color)}', '{Store.SQLEscape(anItem.Brand)}', " +
                                          $"'{Store.SQLEscape(anItem.Prop)}', '{Store.SQLEscape(anItem.Size)}')";
                connection.Execute(connectionString);
            }
        }

        public bool InsertItems(List<Item> anItemList)
        {
            using (var connection = new SQLiteConnection(Helper.ConnectionString))
            {
                connection.Open();
                string soldDate, payoutDate, beginDate, endDate, deleteDate;
                using (var cmd = new SQLiteCommand(connection))
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        // 100,000 inserts
                        foreach (var anItem in anItemList)
                        {
                            soldDate = Item.ConvertDateStringToSQLiteTimeString(anItem.SoldDate);
                            payoutDate = Item.ConvertDateStringToSQLiteTimeString(anItem.PayoutDate);
                            endDate = Item.ConvertDateStringToSQLiteTimeString(anItem.EndDate);
                            beginDate = Item.ConvertDateStringToSQLiteTimeString(anItem.BeginDate);
                            deleteDate = Item.ConvertDateStringToSQLiteTimeString(anItem.DeleteDate);
                            cmd.CommandText =
                                $"INSERT OR IGNORE INTO items ( [AccountID], [contractID], [itemNumber], [itemDescription],  [salesPrice], [costPrice], [payoutDate], " +
                                    $"[soldDate], [BeginDate], [EndDate], [DeleteDate], [color], [brand], [prop], [size])  " +
                                    $" VALUES( '{anItem.AccountID}', '{anItem.ContractID}', '{anItem.ItemNumber}', '{Store.SQLEscape(anItem.ItemDescription)}', '{anItem.SalesPrice}', " +
                                    $"'{anItem.CostPrice}', '{payoutDate}', '{soldDate}', '{beginDate}', '{endDate}',  '{deleteDate}', '{Store.SQLEscape(anItem.Color)}', '{Store.SQLEscape(anItem.Brand)}', " +
                                    $"'{Store.SQLEscape(anItem.Prop)}', '{Store.SQLEscape(anItem.Size)}')";
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                }
                using (var cmd = new SQLiteCommand(connection))
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        foreach (var anItem in anItemList)
                        {
                            soldDate = Item.ConvertDateStringToSQLiteTimeString(anItem.SoldDate);
                            payoutDate = Item.ConvertDateStringToSQLiteTimeString(anItem.PayoutDate);
                            endDate = Item.ConvertDateStringToSQLiteTimeString(anItem.EndDate);
                            beginDate = Item.ConvertDateStringToSQLiteTimeString(anItem.BeginDate);
                            deleteDate = Item.ConvertDateStringToSQLiteTimeString(anItem.DeleteDate);
                            cmd.CommandText =
                                $"UPDATE items SET itemDescription =  '{anItem.ItemDescription}', salesPrice = '{anItem.SalesPrice}',  costPrice = '{anItem.CostPrice}', " +
                                $"payoutDate = '{payoutDate}', soldDate = '{soldDate}', BeginDate = '{beginDate}', EndDate = '{endDate}', DeleteDate = '{deleteDate}', color = '{anItem.Color}', " +
                                $"brand = '{anItem.Brand}', prop = '{anItem.Prop}', size = '{anItem.Size}' WHERE itemNUmber = '{anItem.ItemNumber}' " ;
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                }
                connection.Close();
            }
            return true;
        }

        public void UpdateItem(Item anItem)
            {
                using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
                {
                    string connectionString = "";
                    string soldDate, payoutDate, endDate, beginDate, deleteDate; 

                    soldDate = Item.ConvertDateStringToSQLiteTimeString(anItem.SoldDate);
                    payoutDate = Item.ConvertDateStringToSQLiteTimeString(anItem.PayoutDate);
                    endDate = Item.ConvertDateStringToSQLiteTimeString(anItem.EndDate);
                    beginDate = Item.ConvertDateStringToSQLiteTimeString(anItem.BeginDate);
                    deleteDate = Item.ConvertDateStringToSQLiteTimeString(anItem.DeleteDate);

                    connectionString = $"UPDATE items SET " + 
                                        $"[itemNumber] = '{anItem.ItemNumber}',  [itemDescription] = '{Store.SQLEscape(anItem.ItemDescription)}', " +
                                        $"[salesPrice] = '{anItem.SalesPrice}', [costPrice] = '{anItem.CostPrice}', [payoutDate] = '{payoutDate}', " +
                                        $"[soldDate] = '{soldDate}', [BeginDate] = '{beginDate}', [EndDate] = '{endDate}', [deleteDate] = '{deleteDate}', [color] = '{Store.SQLEscape(anItem.Color)}',  " +
                                        $"[brand] = '{Store.SQLEscape(anItem.Brand)}', [prop] = '{Store.SQLEscape(anItem.Prop)}', [size] = '{Store.SQLEscape(anItem.Size)}' " +
                                        $" WHERE itemNumber = '{anItem.ItemNumber}' ";
                    connection.Execute(connectionString);
                }
            }

        public void UpdateItemsPayedWithItemNumber(string anItemNumber, string aPayoutDate)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                connectionString = $"UPDATE items SET PayoutDate = '{aPayoutDate}' " +
                    $"WHERE itemNumber = '{anItemNumber}' AND  soldDate <> ''  AND payoutDate = '' ";
                connection.Execute(connectionString);
            }
        }

        public void UpdateItemsPayedWithAccountID(string anAccountID, string aPayoutDate)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                connectionString = $"UPDATE items SET PayoutDate = '{aPayoutDate}' " +
                    $"WHERE accountID = '{anAccountID}' AND  soldDate <> ''  AND payoutDate = '' ";
                connection.Execute(connectionString);
            }
        }

        public void UpdateItemSoldWithItemNumber(string anItemNumber, string aSoldDate)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                connectionString = $"UPDATE items SET soldDate = '{aSoldDate}' WHERE itemNumber = '{anItemNumber}' ";
                connection.Execute(connectionString);
            }
        }

        public void UpdateItemWithItemNumber(string anItemNumber, string aSalesPrice, string aCostPrice)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                connectionString = $"UPDATE items SET salesPrice = '{aSalesPrice}', costPrice = '{aCostPrice}' " +
                    $"WHERE itemNumber = '{anItemNumber}' ";
                connection.Execute(connectionString);
            }
        }

        public void UpdateItemItemNumber(string anItemNumber)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                connectionString = $"UPDATE items SET itemNumber = '{anItemNumber}' " +
                    $"WHERE itemNumber = '{anItemNumber}' ";
                connection.Execute(connectionString);
            }
        }

        public void DeleteAllItemsWithContractID(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                connectionString = $"DELETE FROM items WHERE contractID = '{aContractID}'";
                connection.Execute(connectionString);
            }
        }

        public void UpdateItemDeletedWithItemNumber(string anItemNumber, string aDeleteDate)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string deleteDate = Item.ConvertDateStringToSQLiteTimeString(aDeleteDate);
                string connectionString = "";
                connectionString = $"UPDATE items SET DeleteDate = '{deleteDate}' " +
                    $"WHERE itemNumber = '{anItemNumber}' ";
                connection.Execute(connectionString);
            }
        }

        public void DeleteItemWithItemNumber(string anItemNumber)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                connectionString = $"DELETE FROM items WHERE itemNumber = '{anItemNumber}'";
                connection.Execute(connectionString);
            }
        }

        public void DeleteItem(string anItemNumber)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                connectionString = $"DELETE FROM items WHERE ItemNumber = '{anItemNumber}'";
                connection.Execute(connectionString);
            }
        }

        public string GetMaxBeginDate() //From ConfigData
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<string>($"SELECT MAX(BeginDate) FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID  ").ToList();
                    return output[0];
                }
                catch
                {
                    throw;
                }
            }
        }

        public string GetMinBeginDate() //From ConfigData
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<string>($"SELECT MIN(BeginDate) FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID  ").ToList();
                    return output[0];
                }
                catch
                {
                    throw;
                }
            }
        }

        public string GetLastContractID() //From ConfigData
        {
            ConfigData myconfigData = new ConfigData();
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<ConfigData>($"SELECT LastContractID FROM configData").ToList();
                    if (output.Count > 0)
                    {
                        myconfigData = output.Last();
                    }
                }

                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 1 || ex.ErrorCode == 14)
                    {
                        //Wenn configData Tabelle nicht vorhanden                
                        string connectionString = "";
                        connectionString = $"CREATE TABLE configData (LastContractID VARCHAR(6) NOT NULL  DEFAULT '170000', " +
                            $" LastItemNumber VARCHAR(6) NOT NULL  DEFAULT '000000', LastItemNumber VARCHAR(6) NOT NULL  DEFAULT '000000', " +
                            $"BackupDirectory TEXT, KassenBestand REAL NOT NULL, Period INTEGER NOT NULL  DEFAULT 90,  Margin INTEGER NOT NULL  DEFAULT 50)";
                        connection.Execute(connectionString);
                        //ersten DatenSatz mit default Werten eintragen
                        string myContractID = DateTime.Today.Year.ToString().Substring(2, 2) + "0000";
                        string myInvoiceID = DateTime.Today.Year.ToString().Substring(2, 2) + "000000";
                        string myItemNumber = "000000";
                        string myBackupDirectory = Store.GetPersonalFolder() + "\\2ndHandWare\\Backup\\";
                        connectionString = $"INSERT INTO configData ( [LastContractID], [LastItemNumber], [LastInvoiceID] [BackupDirectory], " +
                            $" [KassenBestand], [Period], [Margin] ) " +
                            $" VALUES ('{myContractID}', '{myItemNumber}', {myInvoiceID}', {myBackupDirectory}', 150, 90, 50)";
                        connection.Execute(connectionString);
                        var output = connection.Query<ConfigData>($"SELECT LastContractID FROM configData").ToList();
                        if (output.Count > 0)
                        {
                            myconfigData = output.Last();
                        }
                    }
                }

                return myconfigData.LastContractID;
            }
        }

        public string GetLastItemNumber() //From ConfigData
        {
            ConfigData myconfigData = new ConfigData();
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<ConfigData>($"SELECT LastItemNumber FROM configData").ToList();
                    if (output.Count > 0)
                    {
                        myconfigData = output.Last();
                    }
                }

                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 1 || ex.ErrorCode == 14)
                    {
                        //Wenn configData Tabelle nicht vorhanden                
                        string connectionString = "";
                        connectionString = $"CREATE TABLE IF NOT EXISTS configData (LastContractID VARCHAR(6) NOT NULL  DEFAULT '170000', " +
                            $" LastItemNumber VARCHAR(6) NOT NULL  DEFAULT '000000', LastItemNumber VARCHAR(6) NOT NULL  DEFAULT '000000', " +
                            $"BackupDirectory TEXT, KassenBestand REAL NOT NULL, Period INTEGER NOT NULL  DEFAULT 90,  Margin INTEGER NOT NULL  DEFAULT 50)";
                        connection.Execute(connectionString);
                        //ersten DatenSatz mit default Werten eintragen
                        string myContractID = DateTime.Today.Year.ToString().Substring(2, 2) + "000000";
                        string myInvoiceID = DateTime.Today.Year.ToString().Substring(2, 2) + "000000";
                        string myItemNumber = "000000";
                        string myBackupDirectory = Store.GetPersonalFolder() + "\\PINK2ndHand\\Backup\\";
                        connectionString = $"INSERT INTO configData ( [LastContractID], [LastItemNumber], [LastInvoiceID], [BackupDirectory], " +
                            $" [KassenBestand], [Period], [Margin] ) " +
                            $" VALUES ('{myContractID}', '{myItemNumber}', '{myInvoiceID}', '{myBackupDirectory}', 150, 90, 50)";
                        connection.Execute(connectionString);
                        var output = connection.Query<ConfigData>($"SELECT LastItemNumber FROM configData").ToList();
                        if (output.Count > 0)
                        {
                            myconfigData = output.Last();
                        }
                    }
                }
                return myconfigData.LastItemNumber;
            }
        }

        public string GetLastInvoiceNumber() //From ConfigData
        {
            ConfigData myconfigData = new ConfigData();
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<ConfigData>($"SELECT LastInvoiceID FROM configData").ToList();
                    if (output.Count > 0)
                    {
                        myconfigData = output.Last();
                    }
                }

                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 1 || ex.ErrorCode == 14)
                    {
                        //Wenn configData Tabelle nicht vorhanden                
                        string connectionString = "";
                        connectionString = $"CREATE TABLE IF NOT EXISTS configData (LastContractID VARCHAR(6) NOT NULL  DEFAULT '000000', " +
                            $" LastItemNumber VARCHAR(6) NOT NULL  DEFAULT '000000', LastInvoiceID VARCHAR(6) NOT NULL  DEFAULT '000000', BackupDirectory TEXT, " +
                            $" KassenBestand REAL NOT NULL, Period INTEGER NOT NULL  DEFAULT 90,  Margin INTEGER NOT NULL  DEFAULT 50)";
                        connection.Execute(connectionString);
                        //ersten DatenSatz mit default Werten eintragen
                        string myContractID = DateTime.Today.Year.ToString().Substring(2, 2) + "0000";
                        string myItemNumber = DateTime.Today.Year.ToString().Substring(2, 2) + "0000";
                        string myInvoiceID = DateTime.Today.Year.ToString().Substring(2, 2) + "0000"; ;
                        string myBackupDirectory = Store.GetPersonalFolder() + "\\2ndHandWare\\Backup\\";
                        connectionString = $"INSERT INTO configData ( [LastContractID], [LastItemNumber], [LastInvoiceID], [BackupDirectory], " +
                            $" [KassenBestand], [Period], [Margin] ) " +
                            $" VALUES ('{myContractID}', '{myItemNumber}', '{myInvoiceID}', '{myBackupDirectory}', 150, 90, 50)";
                        connection.Execute(connectionString);
                        var output = connection.Query<ConfigData>($"SELECT LastInvoiceID FROM configData").ToList();
                        if (output.Count > 0)
                        {
                            myconfigData = output.Last();
                        }
                    }
                }
                return myconfigData.LastInvoiceID;
            }
        }

        public List<ConfigData>GetConfigData() //From ConfigData
        {
            List<ConfigData> output = new List<ConfigData>();
            
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                try
                {
                    output   = connection.Query<ConfigData>($"SELECT * FROM configData").ToList();
 
                }

                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 1 || ex.ErrorCode == 14)
                    {
                        //Wenn configData Tabelle nicht vorhanden                
                        connectionString = $"CREATE TABLE IF NOT EXISTS configData (LastContractID VARCHAR(6) NOT NULL  DEFAULT '000000', " +
                            $" LastItemNumber VARCHAR(6) NOT NULL  DEFAULT '000000', LastInvoiceID VARCHAR(6) NOT NULL  DEFAULT '000000', " +
                            $"BackupDirectory TEXT, KassenBestand REAL NOT NULL, Period INTEGER NOT NULL  DEFAULT 90,  Margin INTEGER NOT NULL  DEFAULT 50)";
                        connection.Execute(connectionString);
                        //ersten DatenSatz mit default Werten eintragen
                        string myContractID = DateTime.Today.Year.ToString().Substring(2, 2) + "0000";
                        string myItemNumber = DateTime.Today.Year.ToString().Substring(2, 2) + "0000";
                        string myInvoiceID = DateTime.Today.Year.ToString().Substring(2, 2) + "0000";
                        string myBackupDirectory = "";
                        connectionString = $"INSERT INTO configData ( [LastContractID], [LastItemNumber], [LastInvoiceID], [BackupDirectory], " +
                            $" [KassenBestand], [Period], [Margin] ) " +
                            $" VALUES ('{myContractID}', '{myItemNumber}', '{myInvoiceID}', '{myBackupDirectory}', 150, 90, 50)";
                        connection.Execute(connectionString);
                        output = connection.Query<ConfigData>($"SELECT LastContractID FROM configData").ToList();
                                            }

                }
            }
            return output;
        }

        public void UpdateConfigDatLastInvoiceID(string aLastInvoiceID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                connectionString = $"UPDATE configData SET LastInvoiceID = '{aLastInvoiceID}' ";
                connection.Execute(connectionString);
            }
        }

        public void UpdateConfigDat(ConfigData aData)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                string connectionString = "";
                connectionString = $"UPDATE configData SET LastContractID = '{aData.LastContractID}',  " +
                    $" LastItemNumber = '{aData.LastItemNumber}', BackupDirectory = '{ aData.BackupDirectory }', KassenBestand = '{aData.KassenBestand}', " + 
                    $" KassenBestand = '{aData.KassenBestand}', Period = '{ aData.Period }', Margin = '{aData.Margin}' ";
                connection.Execute(connectionString);
            }
        }
    }
}
