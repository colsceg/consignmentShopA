﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SQLite;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

namespace ConsignmentShopLibrary
{
    public class DataAccessAttributes
    {
        public Store Store { get; } = new Store();
        /// <summary>
        /// Creates a SQLite database
        /// </summary>
        /// <param name="DatabaseName"></param>
        public void CreateDataBase(string DatabaseName)
        {
            try
            {
                SQLiteConnection.CreateFile(DatabaseName);
            }
            catch (Exception ex)
            {
                Store.ShowErrors(ex);
            }   
            
        }

        #region Gets Attributes from existing items
        /// <summary>
        /// Gets all item descriptions from a table
        /// </summary>
        /// <returns></returns>
        public BindingList<string> GetAllItemDescriptionFromItems()
        {
            BindingList<string> temp = new BindingList<string>();
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<string>($"SELECT itemDescription FROM items GROUP BY itemDescription ORDER BY itemDescription ASC ").ToList();

                    foreach (var item in output)
                    {
                        temp.Add(item);
                    }
                    return temp;
                }
                catch (SQLiteException ex)
                {
                    Store.ShowErrors(ex);
                }

                return temp;
            }
        }

        /// <summary>
        /// Gets all brands used in all existing items
        /// </summary>
        /// <returns></returns>
        public BindingList<string> GetAllBrandsFromItems()
        {
            BindingList<string> temp = new BindingList<string>();
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<string>($"SELECT attribute2 FROM items GROUP BY attribute2 ORDER BY attribute2 ASC ").ToList();

                    foreach (var item in output)
                    {
                        temp.Add(item);
                    }
                    return temp;
                }
                catch (SQLiteException ex)
                {
                    Store.ShowErrors(ex);
                }

                return temp;
            }
        }

        /// <summary>
        /// Gets all colors used in all existing items
        /// </summary>
        /// <returns></returns>
        public BindingList<string> GetAllColorsFromItems()
        {
            BindingList<string> temp = new BindingList<string>();
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<string>($"SELECT attribute1 FROM items GROUP BY attribute1 ORDER BY attribute1 ASC ").ToList();

                    foreach (var item in output)
                    {
                        temp.Add(item);
                    }
                    return temp;
                }
                catch (SQLiteException ex)
                {
                    Store.ShowErrors(ex);
                }
                return temp;
            }
        }

        /// <summary>
        /// Gets all sizes used in all existing items
        /// </summary>
        /// <returns></returns>
        public BindingList<string> GetAllSizesFromItems()
        {
            BindingList<string> temp = new BindingList<string>();
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<string>($"SELECT attribute4 FROM items GROUP BY attribute4 ORDER BY attribute4 ASC ").ToList();

                    foreach (var item in output)
                    {
                        temp.Add(item);
                    }
                    return temp;
                }
                catch (SQLiteException ex)
                {
                    Store.ShowErrors(ex);
                }
                return temp;
            }
        }

        /// <summary>
        /// Gets all extra properties used in all existing items
        /// </summary>
        /// <returns></returns>
        public BindingList<string> GetAllPropertiesFromItems()
        {
            BindingList<string> temp = new BindingList<string>();
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<string>($"SELECT attribute3 FROM items GROUP BY attribute3 ORDER BY attribute4 ASC ").ToList();

                    foreach (var item in output)
                    {
                        temp.Add(item);
                    }
                    return temp;
                }
                catch (SQLiteException ex)
                {
                    Store.ShowErrors(ex);
                }
                return temp;
            }
        }
        #endregion

        #region Get all attributes from a table

        /// <summary>
        /// Get a list of all brands from a table named labels
        /// </summary>
        /// <returns></returns>
        public BindingList<string> GetAllBrands()
        {
            BindingList<string> temp = new BindingList<string>();
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<string>($"SELECT name FROM labels ORDER BY name ASC ").ToList();

                    foreach (var item in output)
                    {
                        temp.Add(item);
                    }
                    return temp;
                }

                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 14 || ex.ErrorCode == 1)
                    {
                        //Wenn contracts Tabelle nicht vorhanden                
                        string connectionString = "";
                        connectionString = $"CREATE TABLE IF NOT EXISTS labels (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL UNIQUE, premium	INTEGER)";

                        connection.Execute(connectionString);
                        var output = connection.Query<string>($"SELECT * FROM labels ORDER BY name ASC ").ToList();
                        foreach (var item in output)
                        {
                            temp.Add(item);
                        }
                        return temp;
                    }
                    Store.ShowErrors(ex);
                }
                return temp;
            }
        }

        /// <summary>
        /// Get a list of all colors from a table named colors
        /// </summary>
        /// <returns></returns>
        public BindingList<string> GetAllColors()
        {
            BindingList<string> temp = new BindingList<string>();
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<string>($"SELECT * FROM colors ORDER BY name ASC ").ToList();
                    foreach (var item in output)
                    {
                        temp.Add(item);
                    }
                    return temp;
                }

                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 1)
                    {
                        //Wenn contracts Tabelle nicht vorhanden                
                        string connectionString = "";
                        connectionString = $"CREATE TABLE IF NOT EXISTS colors (name TEXT PRIMARY KEY  NOT NULL UNIQUE )";

                        connection.Execute(connectionString);
                        var output = connection.Query<string>($"SELECT * FROM colors ORDER BY name ASC ").ToList();
                        foreach (var item in output)
                        {
                            temp.Add(item);
                        }
                        return temp;
                    }
                    Store.ShowErrors(ex);
                }
            }
            return temp;
        }

        /// <summary>
        /// Get a list of all properties from a table named properties
        /// </summary>
        /// <returns></returns>
        public BindingList<string> GetAllProperties()
        {
            BindingList<string> temp = new BindingList<string>();
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<string>($"SELECT * FROM properties ORDER BY name Desc ").ToList();
                    foreach (var item in output)
                    {
                        temp.Add(item);
                    }
                    return temp;
                }

                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 1)
                    {
                        //Wenn contracts Tabelle nicht vorhanden                
                        string connectionString = "";
                        connectionString = $"CREATE TABLE IF NOT EXISTS properties (name TEXT PRIMARY KEY  NOT NULL UNIQUE )";

                        connection.Execute(connectionString);
                        var output = connection.Query<string>($"SELECT * FROM properties ORDER BY name DESC ").ToList();
                        foreach (var item in output)
                        {
                            temp.Add(item);
                        }
                        return temp;
                    }
                    Store.ShowErrors(ex);
                }
                return temp;
            }
        }

        /// <summary>
        /// Get a list of all colors from a table named colors
        /// </summary>
        /// <returns></returns>
        public BindingList<string> GetAllSizes()
        {
            BindingList<string> temp = new BindingList<string>();
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<string>($"SELECT * FROM sizes ORDER BY name ASC ").ToList();
                    foreach (var item in output)
                    {
                        temp.Add(item);
                    }
                    return temp;
                }

                catch (SQLiteException ex)
                {
                    if (ex.ErrorCode == 1)
                    {
                        //Wenn contracts Tabelle nicht vorhanden                
                        string connectionString = "";
                        connectionString = $"CREATE TABLE IF NOT EXISTS sizes (name TEXT PRIMARY KEY  NOT NULL UNIQUE)";

                        connection.Execute(connectionString);
                        var output = connection.Query<string>($"SELECT * FROM sizes ORDER BY name ASC ").ToList();
                        foreach (var item in output)
                        {
                            temp.Add(item);
                        }
                        return temp;
                    }
                    Store.ShowErrors(ex);
                }
                return temp;
            }
        }

        #endregion

        #region Find a specific attribute
        /// <summary>
        /// Find a specific color in table colors
        /// </summary>
        /// <param name="aColor"></param>
        /// <returns>True if color found</returns>
        public bool FindColor(string aColor)
        {
            int i = 0;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
                {
                    string connectionString = $"SELECT name FROM colors  WHERE colors.name = '{Store.SQLEscape(aColor)}'";
                    var output = connection.Query(connectionString);
                    foreach (var item in output)
                    {
                        i++;
                    }
                    if (i > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                Store.ShowErrors(ex);
            }
            return false;
        }

        /// <summary>
        /// Find a specific brand in table brands
        /// We need the founded brand in mainwindow to look if premium brand or not
        /// </summary>
        /// <param name="aBrand"></param>
        /// <returns>List of all brands found</returns>
        public List<Brand> FindBrand(string aBrand)
        {
            List<Brand> temp = new List<Brand>();
            using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
            {
                try
                {
                    var output = connection.Query<Brand>($"SELECT * FROM labels  WHERE labels.name = '{Store.SQLEscape(aBrand)}'").ToList();
                    foreach (var item in output)
                    {
                        temp.Add(item);
                    }
                    return temp;
                }
                catch (Exception ex)
                {
                    Store.ShowErrors(ex);
                }
                return temp;
            }
        }

        /// <summary>
        /// Find a specific item description in table items
        /// </summary>
        /// <param name="anItemdescription"></param>
        /// <returns>True if item description was found</returns>
        public bool FindItemdescription(string anItemdescription)
        {
            int i = 0;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
                {
                    //return connection.Query<Person>("SELECT * FROM customers WHERE name = '{ name }'").ToList();
                    var output = connection.Query<Brand>($"SELECT itemDescription FROM items WHERE itemDescription = '{Store.SQLEscape(anItemdescription) }' GROUP BY itemDescription ORDER BY itemDescription ASC ").ToList();
                    foreach (var item in output)
                    {
                        i++;
                    }
                    if (i > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Fehler {e}");
                return false;
            }
        }

        /// <summary>
        /// Find a specific property in table properties
        /// </summary>
        /// <param name="aProp"></param>
        /// <returns>True if property was found</returns>
        public bool FindProp(string aProp)
        {
            int i = 0;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
                {
                    string connectionString = $"SELECT name FROM properties  WHERE properties.name = '{Store.SQLEscape(aProp)}'";
                    var output = connection.Query(connectionString);
                    foreach (var item in output)
                    {
                        i++;
                    }
                    if (i > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Find a specific size in table sizes
        /// </summary>
        /// <param name="aSize"></param>
        /// <returns>True if size was found</returns>
        public bool FindSize(string aSize)
        {
            int i = 0;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
                {
                    string connectionString = $"SELECT name FROM sizes  WHERE sizes.name = '{Store.SQLEscape(aSize)}'";
                    var output = connection.Query(connectionString);
                    foreach (var item in output)
                    {
                        i++;
                    }
                    if (i > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                Store.ShowErrors(ex);
            }
            return false;
        }
        #endregion

        #region insert new attributes 

        public bool InsertBrand(Brand aBrand)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
                {
                    string connectionString = $"INSERT INTO labels ( [name], [premium]) VALUES( '{Store.SQLEscape(aBrand.Name)}', '{aBrand.Premium}')";
                    connection.Execute(connectionString);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool InsertBrands(List<Brand> aBrandList)
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
                            foreach (var anItem in aBrandList)
                            {
                                cmd.CommandText =
                                     $"INSERT INTO labels ( [name], [premium]) VALUES( '{Store.SQLEscape(anItem.Name)}', '{anItem.Premium}')";
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
                MessageBox.Show("Fehler beim Einlesen der Labels: " + ex.Message);
                return false;
            }
}

        public bool InsertColor(string aColor)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
                {
                    string connectionString = $"INSERT INTO colors ( [name]) VALUES( '{Store.SQLEscape(aColor)}')";
                    connection.Execute(connectionString);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool InsertColors(string[] aColorList)
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
                            foreach (var item in aColorList)
                            {
                                cmd.CommandText = $"INSERT INTO colors ( [name]) VALUES( '{Store.SQLEscape(item)}')";
                                cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                    }
                    connection.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool InsertProp(string aProp)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
                {
                    string connectionString = $"INSERT INTO properties ( [name]) VALUES( '{Store.SQLEscape(aProp)}')";
                    connection.Execute(connectionString);
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool InsertProps(string[] aPropList)
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
                            foreach (var item in aPropList)
                            {
                                cmd.CommandText = $"INSERT INTO properties ( [name]) VALUES( '{Store.SQLEscape(item)}')";
                                cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                    }
                    connection.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool InsertSize(string aSize)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Helper.ConnectionString))
                {
                    string connectionString = $"INSERT INTO sizes ( [name]) VALUES( '{Store.SQLEscape(aSize)}')";
                    connection.Execute(connectionString);
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool InsertSizes(string[] aSizeList)
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
                            foreach (var item in aSizeList)
                            {
                                cmd.CommandText = $"INSERT INTO sizes ( [name]) VALUES( '{Store.SQLEscape(item)}')";
                                cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                    }
                    connection.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void __insertColors(string[] aList)
        {
            InsertColors(aList);
        }

        public void __insertLabels(List<Brand> aList)
        {
            InsertBrands(aList);
        }

        public void __insertProps(string[] aList)
        {
            InsertProps(aList);
        }

        public void __insertSizes(string[] aList)
        {
            InsertSizes(aList);
        }

        #endregion
    }
}
