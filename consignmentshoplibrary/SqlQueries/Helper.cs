using System;
using System.Configuration;
using System.Text;
using System.Xml;

namespace ConsignmentShopLibrary
{
    public static class Helper
    {
        public static string AppDataDirectory { get; } = Store.GetAppDataFolder() + "\\chairfit";
        public static string WorkingDirectory { get; } = Store.GetPersonalFolder() + "\\PINK2ndHand";
        public static string BackupDirectory { get; } = WorkingDirectory + "\\Backup";
        public static string MyDBFilename { get; } = "\\SecondHandCollection.db";
        public static string ConnectionString { get { return "Data Source=" + WorkingDirectory + MyDBFilename + "; version=3;"; } }

        /// <summary>
        /// Gets the connectionstring from App.Config
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CnnVal(string name)
        {
            //PersonalFolder d.h. Drive:\Users\user\documents
            string WorkingDirectory = Store.GetPersonalFolder() + "\\PINK2ndHand";
            //Data Source = C:\Users\NBC\Documents\PINK2ndHand\SecondHandCollection.db; version = 3;
            //return ( "Data Source="+ WorkingDirectory + myDBFileName + "; version=3;" );
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        /// <summary>
        /// builds a connectionString with Data Source = dataSource
        /// </summary>
        /// <param dataSource="dataSource"></param>
        public static void SetCnnVal(string dataSource)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //config.AppSettings.Settings["UserId"].Value = "myUserId";

            //Constructing connection string from the inputs
            StringBuilder Con = new StringBuilder("Data Source=");
            Con.Append(dataSource);
            Con.Append("; version=3;");
            string strCon = Con.ToString();
            var connectionStringName = "SecondHandCollection_old";
            // Create a connection string element.
            ConnectionStringSettings connectionStringSettings = new ConnectionStringSettings(connectionStringName,
                strCon);
            //updateConfigFile(strCon);
            //AddAndSaveOneConnectionStringSettings(config, connectionStringSettings);
            //UpdateConfigFile(strCon);

            //to refresh connection string each time else it will use previous connection string
            ConfigurationManager.RefreshSection("connectionStrings");
            //config.Save(ConfigurationSaveMode.Modified);
        }

        /// <summary>
        /// NOT USED
        /// </summary>
        /// <param name="con"></param>
        private static void UpdateConfigFile(string con)
        {
            //updating config file
            XmlDocument XmlDoc = new XmlDocument();
            //Loading the Config file
            XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            foreach (XmlElement xElement in XmlDoc.DocumentElement)
            {
                if (xElement.Name == "connectionStrings")
                {
                    if (string.IsNullOrEmpty(xElement.FirstChild.Attributes[1].Value))
                        //setting the coonection string
                        xElement.FirstChild.Attributes[1].Value = con;
                    break;
                }
            }
            //writing the connection string in config file
            XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }


        /// <summary>
        /// Adds a connection string settings entry & saves it to the associated config file.
        /// NOT USED
        /// This may be app.config, or an auxiliary file that app.config points to or some
        /// other xml file.
        /// ConnectionStringSettings is the confusing type name of one entry including: 
        /// name + connection string + provider entry
        /// </summary>
        /// <param name="configuration">Pass in ConfigurationManager.OpenMachineConfiguration, 
        /// ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) etc. </param>
        /// <param name="connectionStringSettings">The entry to add</param>

        public static void AddAndSaveOneConnectionStringSettings(
               System.Configuration.Configuration configuration,
               System.Configuration.ConnectionStringSettings connectionStringSettings)
        {
            // You cannot add to ConfigurationManager.ConnectionStrings using
            // ConfigurationManager.ConnectionStrings.Add
            // (connectionStringSettings) -- This fails.

            // But you can add to the configuration section and refresh the ConfigurationManager.

            // Get the connection strings section; Even if it is in another file.
            ConnectionStringsSection connectionStringsSection = configuration.ConnectionStrings;

            // Add the new element to the section.
            connectionStringsSection.ConnectionStrings.Add(connectionStringSettings);

            // Save the configuration file.
            configuration.Save(ConfigurationSaveMode.Minimal);

            // This is needed. Otherwise the connection string does not show up in
            // ConfigurationManager
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        public static void AddUpdateConnectionStringSettings(string name, string value)
        {
            bool result = false;
            ConnectionStringSettings newConnectionString = new ConnectionStringSettings();
            newConnectionString.Name = name;
            newConnectionString.ConnectionString = value;
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Get the connection strings section.
                ConnectionStringsSection csSection = configFile.ConnectionStrings;
                foreach (ConnectionStringSettings connection in csSection.ConnectionStrings)
                {
                    if (name == connection.Name)
                    {
                        // amend the details and save
                        connection.ConnectionString = value;
                        result = true;
                        break;
                    }
                }

                if (!result)
                {
                    csSection.ConnectionStrings.Add(newConnectionString);
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}
