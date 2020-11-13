using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SQLite;

namespace ConsignmentShopLibrary
{
    public class DataAccessItems
    {
        Store store = new Store();
        public List<Contract> GetAllContracts()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                try
                {
                    var output = connection.Query<Contract>($"SELECT contracts.ContractID, contracts.AccountID, BeginDate, " + 
                        $"CloseDate, EndDate, NumberOfItems, ProvisionSum, SoldNumbers, SoldSum, PayedSum, ContractInfo, contracts.Margin," +
                        $"  customers.LastName, customers.FirstName FROM contracts LEFT JOIN customers ON contracts.accountID = customers.accountID " + 
                        $"WHERE Archived = 'False' ORDER BY contractID ASC ").ToList();
                    return output;
                }

                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 1)
                    {
                        //Wenn contracts Tabelle nicht vorhanden                
                        string connectionString = "";
                        connectionString = $"CREATE TABLE IF NOT EXISTS contracts (ContractID TEXT PRIMARY KEY  NOT NULL, AccountID TEXT NOT NULL, BeginDate TEXT, " +
                            $" CloseDate TEXT, EndDate TEXT, NumberOfitems INTEGER, ProvisionSum REAL, SoldNumbers INTEGER, SoldSum REAL, PayedSum REAL, " +
                            $" ContractInfo TEXT, Margin INTEGER, Archived TEXT NOT NULL  DEFAULT False)";
                        connection.Execute(connectionString);
                        var output = connection.Query<Contract>($"SELECT ContractID, AccountID, NumberOfItems, BeginDate, EndDate, CloseDate, ContractInfo, " +
                            $" SoldNumbers, SoldSum, Margin, PayedSum, ProvisionSum Archived FROM contracts ORDER BY ContractID ASC ").ToList();
                        return output;
                    }
                    throw;
                }
            }
        }

        public List<Contract> GetAllArchivedContracts()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                try
                {
                    var output = connection.Query<Contract>($"SELECT contracts.ContractID, contracts.AccountID, BeginDate, CloseDate, " +
                        $" EndDate, NumberOfItems, ProvisionSum, SoldNumbers, SoldSum, PayedSum, ContractInfo, Margin," +
                        $" customers.LastName, customers.FirstName FROM contracts LEFT JOIN customers ON contracts.accountID = customers.accountID " + 
                        $" WHERE Archived = 'true' ORDER BY contracts.contractID ASC ").ToList();
                    return output;
                }

                catch (SQLiteException ex)
                {
                    throw;
                }
            }
        }

        public List<Contract> GetAllContractsSorted(string aColumnName, string aSortDirection)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                try
                {//return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                    var output = connection.Query<Contract>($"SELECT contracts.ContractID, contracts.AccountID, BeginDate, " + 
                        $"CloseDate, EndDate, NumberOfItems, ProvisionSum, SoldNumbers, SoldSum, PayedSum, ContractInfo, contracts.Margin," +
                        $"  customers.LastName, customers.FirstName FROM contracts LEFT JOIN customers ON contracts.accountID = customers.accountID " +
                        $"WHERE Archived = 'False' ORDER BY {aColumnName} {aSortDirection} ").ToList();
                    return output;
                }
                catch(SQLiteException ex)
                {
                    if (ex.ErrorCode == 1)
                    {
                        //Wenn contracts Tabelle nicht vorhanden                
                        string connectionString = "";
                        connectionString = $"CREATE TABLE IF NOT EXISTS contracts (ContractID TEXT PRIMARY KEY  NOT NULL, AccountID TEXT NOT NULL, BeginDate TEXT, " +
                            $" CloseDate TEXT, EndDate TEXT, NumberOfitems INTEGER, ProvisionSum REAL, SoldNumbers INTEGER, SoldSum REAL, PayedSum REAL, " +
                            $" ContractInfo TEXT, Margin INTEGER, Archived TEXT NOT NULL  DEFAULT False)";
                        connection.Execute(connectionString);
                        var output = connection.Query<Contract>($"SELECT ContractID, AccountID, NumberOfItems, BeginDate, EndDate, CloseDate, ContractInfo, " +
                            $" SoldNumbers, SoldSum, Margin, PayedSum, ProvisionSum Archived FROM contracts ORDER BY ContractID ASC ").ToList();
                        return output;
                    }
                    throw;
                }
            }
        }

        public List<Contract> GetAllArchivedContractsSorted(string aColumnName, string aSortDirection)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                try
                {//return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                    var output = connection.Query<Contract>($"SELECT contracts.ContractID, contracts.AccountID, BeginDate, " +
                        $"CloseDate, EndDate, NumberOfItems, ProvisionSum, SoldNumbers, SoldSum, PayedSum, ContractInfo, contracts.Margin," +
                        $"  customers.LastName, customers.FirstName FROM contracts LEFT JOIN customers ON contracts.accountID = customers.accountID " +
                        $"WHERE Archived = 'True' ORDER BY {aColumnName} {aSortDirection} ").ToList();
                    return output;
                }
                catch (SQLiteException ex)
                {
                    throw;
                }
            }
        }

        public List<Contract> GetContractWithContractID(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<Contract>($"SELECT contracts.ContractID, contracts.AccountID, BeginDate, " +
                        $"CloseDate, EndDate, NumberOfItems, ProvisionSum, SoldNumbers, SoldSum, PayedSum, ContractInfo, contracts.Margin," +
                        $"customers.LastName, customers.FirstName FROM contracts LEFT JOIN customers ON contracts.accountID = customers.accountID " +
                        $"WHERE ContractID = '{ aContractID }' ").ToList();
                return output;
            }
        }

        public void InsertContract(Contract aContract)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string connectionString = "";
                connectionString = $"INSERT INTO contracts ( [ContractID], [AccountID], [NumberOfItems], [BeginDate], [EndDate], [CloseDate], [ContractInfo], " +
                    $" [SoldNumbers], [SoldSum], [Margin], [PayedSum], [ProvisionSum], [Archived] )" +
                    $"  VALUES( '{aContract.ContractID}', '{aContract.AccountID}', '{ aContract.NumberOfItems }', '{aContract.BeginDate}'," +
                    $" '{aContract.EndDate}', '{aContract.CloseDate}', '{aContract.ContractInfo}', '{aContract.SoldNumbers}', '{aContract.SoldSum}', " +
                    $" '{aContract.Margin}', '{aContract.PayedSum}', '{aContract.ProvisionSum}', 'False' )";
                SQLiteCommand command = new SQLiteCommand(connectionString, connection);

                connection.Execute(connectionString);
                //Update configData
                connectionString = $"UPDATE configData SET LastContractID =  '{aContract.ContractID}' ";
                connection.Execute(connectionString);
            }
        }

        public void InsertArchivedContract(Contract aContract)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string connectionString = "";
                connectionString = $"INSERT INTO archivedContracts ( [ContractID], [AccountID], [NumberOfItems], [BeginDate], [EndDate], [CloseDate], [ContractInfo], " +
                    $" [SoldNumbers], [SoldSum], [Margin], [PayedSum], [ProvisionSum] )" +
                    $"  VALUES( '{aContract.ContractID}', '{aContract.AccountID}', '{ aContract.NumberOfItems }', '{aContract.BeginDate}'," +
                    $" '{aContract.EndDate}', '{aContract.CloseDate}', '{aContract.ContractInfo}', '{aContract.SoldNumbers}', '{aContract.SoldSum}', " +
                    $" '{aContract.Margin}', '{aContract.PayedSum}', '{aContract.ProvisionSum}' )";
                SQLiteCommand command = new SQLiteCommand(connectionString, connection);

                connection.Execute(connectionString);
            }
        }

        public void UpdateContract(Contract aContract)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string connectionString = "";
                connectionString = $"UPDATE contracts SET ContractID = '{aContract.ContractID}', AccountID = '{aContract.AccountID}', " +
                    $" BeginDate = '{ aContract.BeginDate }', CloseDate = '{aContract.CloseDate}', EndDate = '{ aContract.EndDate }', NumberOfItems = {aContract.NumberOfItems}, " +
                    $" ProvisionSum = '{aContract.ProvisionSum}', SoldNumbers = {aContract.SoldNumbers}, SoldSum = {aContract.SoldSum}, " +
                    $" PayedSum = {aContract.PayedSum},  ContractInfo = '{aContract.ContractInfo}', Margin = {aContract.Margin}, Archived = '{aContract.Archived}' " +
                    $" WHERE (ContractID='{aContract.ContractID}')";
                connection.Execute(connectionString);
            }
        }

        public void UpdateContractCloseDate(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string myPayoutDate = DateTime.Today.ToShortDateString();
                string connectionString = "";
                connectionString = $"UPDATE contracts SET CloseDate = '{myPayoutDate}'  WHERE (ContractID='{aContractID}')";
                connection.Execute(connectionString);
            }
        }

        public void UpdateContractPayedSum(string aContractID, string aPayedSum, string aProvisionSum)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string myPayoutDate = DateTime.Today.ToShortDateString();
                string connectionString = "";
                connectionString = $"UPDATE contracts SET PayedSum = '{aPayedSum}', ProvisionSum = '{aProvisionSum}' WHERE (ContractID='{aContractID}')";
                connection.Execute(connectionString);
            }
        }

        public void DeleteContract(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string connectionString = "";
                connectionString = $"DELETE FROM contracts WHERE ContractID = '{aContractID}' ";
                connection.Execute(connectionString);
            }
        }

        public void DeleteItemsWithPosNUmber(string aContractID, string aPosNumber)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string connectionString = "";
                connectionString = $"DELETE FROM items WHERE ContractID = '{aContractID}' AND PosNumber = '{aPosNumber}' ";
                connection.Execute(connectionString);
            }
        }

        public void DeleteItem(string aContractID,  string aPosNumber, string anItemNumber)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string connectionString = "";
                connectionString = $"DELETE FROM items WHERE ContractID = '{aContractID}' AND PosNumber = '{aPosNumber}' AND ItemNumber = '{anItemNumber}'";
                connection.Execute(connectionString);
            }
        }

        public List<Item> GetAllItems()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                try
                {
                    var output = connection.Query<Item>($"SELECT *  FROM items  LEFT JOIN contracts ON items.ContractID = contracts.ContractID ORDER BY contractID, posNumber ASC ").ToList();
                    return output;
                }
                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 1) //ErrorCodes abfragen
                    {
                        string connectionString = "";
                        connectionString = $"CREATE TABLE items (ContractID TEXT NOT NULL, itemNumber TEXT, ItemDescription TEXT, " +
                            $" SalesPrice REAL, CostPrice REAL, payoutDate TEXT, soldDate TEXT, " +
                            $" withLabel BOOL, posNumber TEXT)";
                        connection.Execute(connectionString);

                        var output = connection.Query<Item>($"SELECT * FROM items ORDER BY ContractID, PosNumber ASC ").ToList();
                        return output;
                    }

                    throw;
                }

            }
        }

        public List<Item> GetAllItemsSorted(string aColumnName, string aSortDirection)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<Item>($"SELECT * FROM items ORDER BY {aColumnName} {aSortDirection} ").ToList();
                return output;
            }
        }

        public List<Item> GetItemsWithContractID(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<Item>($"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID  WHERE items.contractID = '{ aContractID }' ORDER BY PosNumber ASC ").ToList();
                return output;
            }
        }

        public List<Item> GetItemsWithAccountID(string anAccountID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<Item>($"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID  WHERE contracts.AccountID = '{ anAccountID }' ORDER BY PosNumber ASC ").ToList();
                return output;
            }
        }

        public List<ItemGrouped> GetItemsWithContractIDGrouped(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<ItemGrouped>
                    ($"SELECT ContractID, posNumber, itemDescription, SUM(SalesPrice) as SumPrice, COUNT(posNUmber) as ItemCount,  SUM(WithLabel) as WithLabelCount FROM items WHERE ContractID = '{ aContractID }' GROUP BY PosNumber ").ToList();
                return output;
            }
        }

        public List<ItemAllGrouped> GetAllItemsGrouped()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<ItemAllGrouped>
                    ($"SELECT ContractID, SUM(SalesPrice) as SumPrice, SUM (CostPrice) as SumCost, COUNT(posNUmber) as ItemsCount FROM items GROUP BY ContractID  ").ToList();
                return output;
            }
        }

        public List<ItemSoldGrouped> GetItemsWithContractIDGroupedSold(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<ItemSoldGrouped>
                    ($"SELECT SoldDate, posNumber, itemDescription, SUM(SalesPrice) as SumPrice, COUNT(posNUmber) as ItemCount FROM items WHERE ContractID = '{ aContractID }' AND SoldDate <> ''  GROUP BY PosNumber ").ToList();
                return output;
            }
        }

        public List<CashCloseSoldItem> GetItemsCashCloseSold()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string myAktDate = DateTime.Today.ToShortDateString();
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<CashCloseSoldItem>
                    ($"SELECT ContractID, AccountID, posNumber, itemDescription, SalesPrice FROM items WHERE SoldDate = '{myAktDate}' ").ToList();
                return output;
            }
        }

        public List<ItemSoldGrouped> GetItemsWithContractIDGroupedSoldNotPayed(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<ItemSoldGrouped>
                    ($"SELECT SoldDate, posNumber, itemDescription, SUM(SalesPrice) as SumPrice, COUNT(posNUmber) as ItemCount FROM items WHERE ContractID = '{ aContractID }' AND SoldDate <> '' AND PayoutDate = '' GROUP BY PosNumber ").ToList();
                return output;
            }
        }

        public List<ItemPayedGrouped> GetItemsWithContractIDGroupedPayed(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<ItemPayedGrouped>
                    ($"SELECT PayoutDate, SUM(CostPrice) as SumPayed FROM items WHERE ContractID = '{ aContractID }' AND PayoutDate <> '' GROUP BY PayoutDate ").ToList();
                return output;
            }
        }

        public List<Item> GetItemsWithContractIDLabelPrint(string aContractID, string aPosNumberFrom, string aPosNumberTo )
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<Item>($"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID" +
                    $" WHERE items.contractID = '{ aContractID }' AND items.WithLabel = '1' AND PosNumber >= '{aPosNumberFrom}' " + 
                    $" AND PosNumber <= '{aPosNumberTo}' ORDER BY PosNumber ASC ").ToList();
                return output;
            }
        }

        public List<Item> GetItemsWithContractIDLabelPrintOne(string aContractID, string aPosNumber, string anItemNumber)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                var output = connection.Query<Item>($"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID" +
                    $" WHERE items.contractID = '{ aContractID }' AND items.WithLabel = '1' AND PosNumber >= '{ aPosNumber }' " +
                    $" AND itemNumber <= '{ anItemNumber }' ORDER BY PosNumber ASC ").ToList();
                return output;
            }
        }

        public List<ItemReturnGrouped> GetItemsWithContractIDReturnListTotal(string aContractID )
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                var output = connection.Query<ItemReturnGrouped>($"SELECT PosNumber, ItemDescription, SalesPrice, soldDate, COUNT(PosNumber) AS TotalItemsCount " +
                   $" FROM items " +
                   $" WHERE ContractID = '{ aContractID }' " +
                   $" GROUP BY ItemDescription, SalesPrice, SoldDate " + 
                   $" (SELECT PosNumber, ItemDescription, SalesPrice, ) ").ToList();
                return output;
            }
        }

        public List<Item> GetItemsWithContractIDNotSold(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                var output = connection.Query<Item>($"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID  WHERE items.contractID = '{ aContractID }' AND SoldDate = '' ORDER BY PosNumber ASC ").ToList();
                return output;
            }
        }

        public List<Item> GetItemsWithStatusAll(string aContractID, string anAccountID, string BeginDate, string EndDate)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string connectionString = "";
                if (!String.IsNullOrWhiteSpace(aContractID))
                {
                    connectionString = $"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID " +
                        $" WHERE items.contractID = '{ aContractID }' AND contracts.BeginDate >= '{BeginDate}'  AND contracts.BeginDate <= '{EndDate}' ORDER BY ContractID, PosNumber ";
                }
                if (!String.IsNullOrWhiteSpace(anAccountID))
                {
                    connectionString = $"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID " +
                        $" WHERE contract.AccountID = '{ aContractID }' AND contracts.BeginDate >= '{BeginDate}'  AND contracts.BeginDate <= '{EndDate}' ORDER BY ContractID, PosNumber ";
                }
                if (String.IsNullOrWhiteSpace(anAccountID) && String.IsNullOrWhiteSpace(aContractID))
                {
                    connectionString = $"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID " +
                        $" WHERE contracts.BeginDate >= '{BeginDate}'  AND contracts.BeginDate <= '{EndDate}' ORDER BY ContractID, PosNumber ";
                }
                var output = connection.Query<Item>(connectionString).ToList();
                return output;
            }
        }

        public List<Item> GetItemsWithStatusInStore(string aContractID, string anAccountID, string BeginDate, string EndDate)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string connectionString = "";
                if (!String.IsNullOrWhiteSpace(aContractID))
                {
                    connectionString = $"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID " +
                        $" WHERE items.contractID = '{ aContractID }'  AND items.SoldDate = '' ORDER BY ContractID, PosNumber ";
                }
                if (!String.IsNullOrWhiteSpace(anAccountID))
                {
                    connectionString = $"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID " +
                        $" WHERE contract.AccountID = '{ aContractID }' AND items.SoldDate = '' ORDER BY ContractID, PosNumber ";
                }
                if (String.IsNullOrWhiteSpace(anAccountID) && String.IsNullOrWhiteSpace(aContractID))
                {
                    connectionString = $"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID " +
                        $" WHERE items.SoldDate = '' ORDER BY ContractID, PosNumber ";
                }
                var output = connection.Query<Item>(connectionString).ToList();
                return output;
            }
        }

        public List<Item> GetItemsWithStatusSold(string aContractID, string anAccountID, string BeginDate, string EndDate)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string connectionString = "";
                if (!String.IsNullOrWhiteSpace(aContractID))
                {
                    connectionString = $"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID " +
                        $" WHERE items.contractID = '{ aContractID }' AND items.SoldDate >= '{BeginDate}'  AND items.SoldDate <= '{EndDate}' ORDER BY ContractID, PosNumber  ";
                }
                if (!String.IsNullOrWhiteSpace(anAccountID))
                {
                    connectionString = $"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID " +
                        $" WHERE contract.AccountID = '{ aContractID }' AND items.SoldDate >= '{BeginDate}'  AND items.SoldDate <= '{EndDate}' ORDER BY ContractID, PosNumber  ";
                }
                if (String.IsNullOrWhiteSpace(anAccountID) && String.IsNullOrWhiteSpace(aContractID))
                {
                    connectionString = $"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID " +
                        $" WHERE items.SoldDate >= '{BeginDate}'  AND items.SoldDate <= '{EndDate}' ORDER BY ContractID, PosNumber ";
                }
                var output = connection.Query<Item>(connectionString).ToList();
                return output;
            }
        }

        public List<Item> GetItemsWithStatusPayed(string aContractID, string anAccountID, string BeginDate, string EndDate)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string connectionString = "";
                if (!String.IsNullOrWhiteSpace(aContractID))
                {
                    connectionString = $"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID " +
                        $" WHERE items.contractID = '{ aContractID }' AND items.PayoutDate >= '{BeginDate}'  AND items.PayoutDate <= '{EndDate}' ORDER BY ContractID, PosNumber ";
                }
                if (!String.IsNullOrWhiteSpace(anAccountID))
                {
                    connectionString = $"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID " +
                        $" WHERE contract.AccountID = '{ aContractID }' AND items.PayoutDate >= '{BeginDate}'  AND items.PayoutDate <= '{EndDate}' ORDER BY ContractID, PosNumber ";
                }
                if (String.IsNullOrWhiteSpace(anAccountID) && String.IsNullOrWhiteSpace(aContractID))
                {
                    connectionString = $"SELECT *  FROM items LEFT JOIN contracts ON items.ContractID = contracts.ContractID " +
                        $" WHERE items.PayoutDate >= '{BeginDate}'  AND items.PayoutDate <= '{EndDate}' ORDER BY ContractID, PosNumber ";
                }
                var output = connection.Query<Item>(connectionString).ToList();
                return output;
            }
        }

        public List<ItemSalesVolumeGrouped> GetItemsGroupedSalesVolume(string aContractID, string anAccountID, string BeginDate, string EndDate)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string connectionString = "";
                if (!String.IsNullOrWhiteSpace(aContractID))
                {
                    connectionString = $"SELECT items.ContractID,  itemDescription, COUNT(posNUmber) as ItemCount, contracts. Margin, SUM(SalesPrice) as SumPrice, SUM(CostPrice) as SumCostPrice  FROM items LEFT JOIN contracts ON items.contractID = contracts.ContractID " +
                        $" WHERE items.contractID = '{ aContractID }' AND items.PayoutDate >= '{BeginDate}'  AND items.PayoutDate <= '{EndDate}' GROUP BY items.ContractID, PosNumber ORDER BY items.ContractID, PosNumber ";
                }
                if (!String.IsNullOrWhiteSpace(anAccountID))
                {
                    connectionString = $"SELECT items.ContractID,  itemDescription, COUNT(posNUmber) as ItemCount, contracts. Margin, SUM(SalesPrice) as SumPrice, SUM(CostPrice) as SumCostPrice  FROM items LEFT JOIN contracts ON items.contractID = contracts.ContractID " +
                        $" WHERE contract.AccountID = '{ aContractID }' AND items.PayoutDate >= '{BeginDate}'  AND items.PayoutDate <= '{EndDate}' GROUP BY items.ContractID, PosNumber ORDER BY items.ContractID, PosNumber ";
                }
                if (String.IsNullOrWhiteSpace(anAccountID) && String.IsNullOrWhiteSpace(aContractID))
                {
                    connectionString = $"SELECT items.ContractID,  itemDescription, COUNT(posNUmber) as SoldCount, contracts. Margin as Comission, SUM(SalesPrice) as SumSoldPrice, SUM(CostPrice) as SumCostPrice  FROM items LEFT JOIN contracts ON items.contractID = contracts.ContractID WHERE items.PayoutDate >= '01.07.2017'  AND items.PayoutDate <= '31.07.2017' GROUP BY items.ContractID, PosNumber ORDER BY items.ContractID, PosNumber ";
                }
                var output = connection.Query<ItemSalesVolumeGrouped>(connectionString).ToList();
                return output;
            }
        }

        public void InsertItem(Item anItem)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {

                string connectionString = $"INSERT INTO items ( [contractID], [itemNumber],  [itemDescription],  [salesPrice], [costPrice], [payoutDate], [soldDate], [withLabel], [posNumber]) " +
                    $" VALUES( '{anItem.ContractID}', '{anItem.ItemNumber}', '{anItem.ItemDescription}', '{anItem.SalesPrice}', '{anItem.CostPrice}', '{anItem.PayoutDate}', '{anItem.SoldDate}', '{anItem.WithLabel}', '{anItem.PosNumber}')";
                connection.Execute(connectionString);
            }
        }

        public void UpdateItem(Item anItem)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string connectionString = "";
                connectionString = $"UPDATE items SET ContractID = '{anItem.ContractID}', " +
                    $"  ItemDescription = '{anItem.ItemDescription}',  ItemNumber = '{anItem.ItemNumber}', " +
                    $"  PosNumber = '{anItem.PosNumber}', PayoutDate = '{anItem.PayoutDate}', SoldDate = '{anItem.SoldDate}',  WithLabel = '{anItem.WithLabel}', " +
                    $" CostPrice = {anItem.CostPrice}, SalesPrice = {anItem.SalesPrice} " +
                    $" WHERE ContractID = '{anItem.ContractID}' AND  itemNumber = '{anItem.ItemNumber}' AND  posNumber = '{anItem.PosNumber}'";
                connection.Execute(connectionString);
            }
        }

        public void UpdateItemsPayedWithContractID(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string myPayoutDate = DateTime.Today.ToShortDateString();
                string connectionString = "";
                connectionString = $"UPDATE items SET PayoutDate = '{myPayoutDate}' WHERE ContractID = '{aContractID}' AND  soldDate <> ''  AND payoutDate = '' ";
                connection.Execute(connectionString);
            }
        }

        public void DeleteAllItems(string aContractID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string connectionString = "";
                connectionString = $"DELETE FROM items WHERE ContractID = '{aContractID}' ";
                connection.Execute(connectionString);
            }
        }

        public string GetMaxBeginDate() //From ConfigData
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
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
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
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
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
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
                    if (ex.ErrorCode == 1)
                    {
                        //Wenn configData Tabelle nicht vorhanden                
                        string connectionString = "";
                        connectionString = $"CREATE TABLE configData (LastContractID VARCHAR(6) NOT NULL  DEFAULT '170000', " +
                            $" LastLabelNumber INTEGER NOT NULL, BackupDirectory TEXT, " +
                            $" KassenBestand REAL NOT NULL, Period INTEGER NOT NULL  DEFAULT 90,  Margin INTEGER NOT NULL  DEFAULT 50)";
                        connection.Execute(connectionString);
                        //ersten DatenSatz mit default Werten eintragen
                        string myContractID = DateTime.Today.Year.ToString().Substring(2, 2) + "0000";
                        string myBackupDirectory = store.getPersonalFolder() + "\\2ndHandWare\\Backup\\";
                        connectionString = $"INSERT INTO configData ( [LastContractID],  [LastLabelNumber], [BackupDirectory], [KassenBestand], [Period], [Margin] ) " +
                            $" VALUES ('{myContractID}', 0, '{myBackupDirectory}', 150, 90, 50)";
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

        public List<ConfigData> GetConfigData() //From ConfigData
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string connectionString = "";
                try
                {
                    var output = connection.Query<ConfigData>($"SELECT * FROM configData").ToList();
                    return output;
                }

                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 1)
                    {
                        //Wenn configData Tabelle nicht vorhanden                
                        connectionString = $"CREATE TABLE configData (LastContractID TEXT NOT NULL  DEFAULT '0000', " +
                            $" LastLabelNumber TEXT NOT NULL  DEFAULT '0', BackupDirectory TEXT, " +
                            $" KassenBestand DOUBLE NOT NULL  DEFAULT 150,  Period INTEGER NOT NULL  DEFAULT 90,  Margin INTEGER NOT NULL  DEFAULT 50)";
                        connection.Execute(connectionString);

                    }
                    //ersten DatenSatz mit default Werten eintragen
                    string myContractID = DateTime.Today.Year.ToString().Substring(2, 2) + "0000";
                    string myBackupDirectory = store.getPersonalFolder() + "\\2ndHandWare\\Backup\\";

                    connectionString = $"INSERT INTO configData ([LastContractID],  [LastLabelNumber], [BackupDirectory], [KassenBestand], [period], [margin] ) " +
                        $"VALUES ('{myContractID}', '0000', '{myBackupDirectory}', 150.0, 90, 50)";
                    connection.Execute(connectionString);

                    var output = connection.Query<ConfigData>($"SELECT * FROM configData").ToList();
                    return output;
                }

            }
        }

        public void UpdateConfigDat(ConfigData aData)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string connectionString = "";
                connectionString = $"UPDATE configData SET LastContractID = '{aData.LastContractID}', LastLabelNumber = '{aData.LastLabelNumber}', " +
                    $" BackupDirectory = '{ aData.BackupDirectory }', KassenBestand = '{aData.KassenBestand}', Period = '{ aData.Period }', Margin = '{aData.Margin}' ";
                connection.Execute(connectionString);
            }
        }

        public void UpdateConfigDataLastLabel(int LastLabelNumber)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Helper.CnnVal("SecondHandCollection")))
            {
                string connectionString = "";
                connectionString = $"UPDATE configData SET LastLabelNumber = '{LastLabelNumber}' ";
                connection.Execute(connectionString);
            }
        }
    }
}
