using ConsignmentShopLibrary;
using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace ConsignmentShopMainUI
{
    public partial class KeyInputWindow : Form
    {
        private string SerNo { get; set; }
        private Hashtable keys = new Hashtable();
        private string LicenseFile;
        private string AppDataDirectory;
        private Store Store = new Store();
        public bool Licensed { get; set; }

        public KeyInputWindow()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            //Directorys bestimmen
            AppDataDirectory = Helper.AppDataDirectory; ; //Drive:\Users\user\AppData\local                                                       
            LicenseFile = AppDataDirectory + "\\2nd.dta";
            SerNo = Store.ReadSerNoFromFile(LicenseFile);
            TBSerNo.Text = SerNo;
        }

        private void InfoWindow_Shown(object sender, EventArgs e)
        {
            Setup();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TBKey.Text))
            {
                //alle Schlüssel einlesen 
                Hashtable hash = Store.GetKeyList();

                //Get Last to digits of SerialNumber
                int serno = Convert.ToInt16( SerNo.Substring(SerNo.Length - 2, 2));

                //get inputted key
                string input = TBKey.Text;

                if (hash.ContainsKey(serno))
                {
                    //Schlüssel for the eingegebene seriennummer
                    string keyValue = (hash[serno].ToString());

                    //md5 Wert von value in Datei speichern
                    if (input == keyValue)
                    {
                        Licensed = true;

                        //Schlüssel mit MD5 verschlüsseln
                        string hashValue = Store.StringtoMD5(keyValue);

                        //verschlüsselten Schlüssel in Datei eintragen
                        try
                        {
                            FileStream bw = new FileStream(LicenseFile, FileMode.Append, FileAccess.Write);
                            StreamWriter sw = new StreamWriter(bw);
                            sw.Write(hashValue);
                            sw.Close();
                            MessageBox.Show("Die Vollversion ist freigeschaltet");
                            //Titel im Mainwindow ändern
                            Licensed = true;
                            Close();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Problem beim Lesen der Lizensierungsdatei");
                            throw;
                        }
                    }
                    else
                    {
                        Licensed = false;
                        MessageBox.Show("Der eingegebene Schlüssel ist nicht korrekt");
                    }
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
