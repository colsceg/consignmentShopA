using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsignmentShopLibrary;

namespace ConsignmentShopMainUI
{
    public partial class OwnerEditUI : Form
    {
        private DataAccessVendors DBVendors = new DataAccessVendors();
        private DataAccessItems DBItems = new DataAccessItems();
        private DataAccessZipCode DBZipCode = new DataAccessZipCode();

        private List<Vendor> newOwnerList = new List<Vendor>();
        private List<ConfigData> myConfigData = new List<ConfigData>();

        private Store store = new Store();
        private Boolean loaded = false;
        private Vendor newVendor = new Vendor();

        public Vendor NewVendorFromOwnerEdit
        {
            get { return this.newVendor; }
        }

        public OwnerEditUI()
        {
            InitializeComponent();
        }
        
        private void OwnerEditUI_Load(object sender, EventArgs e)
        {
            if (!loaded)
            {
                //PopulateDataGridView();
                // lädt die Tabelle customers aus der SQLite DB
                Disp();
                loaded = true;
            }
        }

        private void Disp()
        {
            newOwnerList = DBVendors.GetOwner();
            myConfigData = DBItems.GetConfigData();

            // Alle Textfelder mit OwnerDaten füllen
            //wenn newOwner leer neuen Kunden in customers anlegen mit accountID = 1000

            if (newOwnerList.Count > 0)
            {
                newVendor.AccountID = newOwnerList[0].AccountID;
                newVendor.Annex1 = newOwnerList[0].Annex1; //enthält storeName
                newVendor.LastName = newOwnerList[0].LastName;
                newVendor.FirstName = newOwnerList[0].FirstName;
                newVendor.Street = newOwnerList[0].Street;
                newVendor.Plz = newOwnerList[0].Plz;
                newVendor.Town = newOwnerList[0].Town;
                newVendor.PhoneNumber1 = newOwnerList[0].PhoneNumber1;
                newVendor.PhoneNumber2 = newOwnerList[0].PhoneNumber2;
                newVendor.Margin = newOwnerList[0].Margin; 
                newVendor.Period = newOwnerList[0].Period;

                newVendor.EmailAccount = newOwnerList[0].EmailAccount;
                newVendor.Margin = newOwnerList[0].Margin;
                newVendor.Period = newOwnerList[0].Period;

                //TextFelder in Formular füllen 
                StoreNameTextBox.Text = newVendor.Annex1;
                OwnerNameTextBox.Text = newVendor.LastName;
                FirstNameTextBox.Text = newVendor.FirstName;
                StreetTextBox.Text = newVendor.Street;
                PlzTextBox.Text = newVendor.Plz;
                TownTextBox.Text = newVendor.Town;
                PhoneNumberTextBox.Text = newVendor.PhoneNumber1;
                MobilNumberTextBox.Text = newVendor.PhoneNumber2;
                EmailAccountTextBox.Text = newVendor.EmailAccount;

                LastContractNumberTextBox.Text = Item.ConvertContractIDToContractNumber( myConfigData[0].LastContractID);

                //Defaultwerte für alle Lieferanten
                MarginTextBox.Text = myConfigData[0].Margin.ToString();
                PeriodTextBox.Text = myConfigData[0].Period.ToString();
            }
            else
            {
                string myAktYear = DateTime.Today.Year.ToString();
                myAktYear = myAktYear.Substring(2, 2);
                LastContractNumberTextBox.Text = Item.ConvertContractIDToContractNumber( myAktYear + "0000");

                MarginTextBox.Text = myConfigData[0].Margin.ToString();
                PeriodTextBox.Text = myConfigData[0].Period.ToString();
            }
        }

        private void StoreButton_Click(object sender, EventArgs e)
        {
            //Inhalt der TextFelder in customers unter accountID 1000 speichern
            newOwnerList = DBVendors.GetOwner();
            if (newOwnerList.Count > 0)
            {
                //Update vorhandenen Datensatz
                DBVendors.UpdatePerson(newVendor);
                DBItems.UpdateConfigDat(myConfigData[0]);
                Close();
            }
            else
            {
                //newVendor wird mit Inhalt der TextFelder gefüllt sobald eine Änderung dort geschieht
                //Prüfen ob wenigstens Inhabername ausgefüllt sonst Fehlermeldung
                if (!String.IsNullOrEmpty( newVendor.LastName))
                {
                    //Add neuen Datensatz in customers mit accountID = '1000' 
                    newVendor.AccountID = "1000";
                    newVendor.Margin = 100;
                    newVendor.Period = Convert.ToInt32(PeriodTextBox.Text);
                    DBVendors.InsertPerson(newVendor);
                    DBItems.UpdateConfigDat(myConfigData[0]);
                    Close();
                }
                else
                {
                    MessageBox.Show("Kein Inhabername angegeben", "OK", MessageBoxButtons.OK);
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //Prüfen ob wenigstens Inhabername ausgefüllt sonst Fehlermeldung
            if (String.IsNullOrEmpty(newVendor.LastName))
                MessageBox.Show("Kein Inhabername angegeben", "OK", MessageBoxButtons.OK);
            else
                Close();
        }
        
        //Eingaben in newVendor speichern
        private void OwnerNameTextBox_Leave(object sender, EventArgs e)
        {
            OwnerNameTextBox.Text= Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(OwnerNameTextBox.Text);
            newVendor.LastName = OwnerNameTextBox.Text;
        }

        private void StoreNameTextBox_Leave(object sender, EventArgs e)
        {
            StoreNameTextBox.Text= Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(StoreNameTextBox.Text);
            newVendor.Annex1 = StoreNameTextBox.Text;
        }

        private void EmailAccountTextBox_Leave(object sender, EventArgs e)
        {
            newVendor.EmailAccount = EmailAccountTextBox.Text;
        }

        private void FirstNameTextBox_Leave(object sender, EventArgs e)
        {
            FirstNameTextBox.Text= Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(FirstNameTextBox.Text);
            newVendor.FirstName = FirstNameTextBox.Text;
        }

        private void StreetTextBox_Leave(object sender, EventArgs e)
        {
            StreetTextBox.Text= Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(StreetTextBox.Text);
            newVendor.Street = StreetTextBox.Text;
        }

        private void PlzTextBox_Leave(object sender, EventArgs e)
        {
            //5-stellig
            if (PlzTextBox.Text.Length == 5)
            {
                List<ZIPCode> myZipCodeList = new List<ZIPCode>();
                myZipCodeList = DBZipCode.GetAllZIPCodesByPlz(PlzTextBox.Text.ToString());
                if (myZipCodeList.Count == 1)
                {
                    TownTextBox.Text = myZipCodeList[0].Ort.ToString();
                }
                newVendor.Plz = PlzTextBox.Text;
            }
            else
            {
                if (PlzTextBox.Text.Length > 0)
                {
                    MessageBox.Show("PLZ muss 5-stellig sein");
                    PlzTextBox.Focus();
                }
            }
        }

        private void TownTextBox_Leave(object sender, EventArgs e)
        {
            TownTextBox.Text= Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(TownTextBox.Text);
            newVendor.Town = TownTextBox.Text;
        }

        private void PhoneNumberTextBox_Leave(object sender, EventArgs e)
        {
            newVendor.PhoneNumber1 = PhoneNumberTextBox.Text;
        }

        private void MobilNumberTextBox_Leave(object sender, EventArgs e)
        {
            newVendor.PhoneNumber2 = MobilNumberTextBox.Text;
        }

        private void MarginTextBox_Leave(object sender, EventArgs e)
        {
            //Defaultwert für alle Lieferanten
            if (myConfigData[0].Margin != Convert.ToInt32(MarginTextBox.Text))
            {
                myConfigData[0].Margin = Convert.ToInt32(MarginTextBox.Text);
                //Kommission in allen Vendor Datensätzen ändern
                DBVendors.UpdateMargin(myConfigData[0].Margin);
            }
            
        }

        private void PeriodTextBox_Leave(object sender, EventArgs e)
        {
            if (myConfigData[0].Period != Convert.ToInt32(PeriodTextBox.Text))
            {
                //Defaultwert für alle Lieferanten
                myConfigData[0].Period = Convert.ToInt32(PeriodTextBox.Text);
                //Laufzeit in allen Vendor Datensätzen ändern
                DBVendors.UpdatePeriod(myConfigData[0].Period);
            }
            
        }

        private void LastContractNumberTextBox_Leave(object sender, EventArgs e)
        {
            //Prüfen ob eingegebene Vertragsnummer größer als letzte
            if (Convert.ToInt32(myConfigData[0].LastContractID) <= Convert.ToInt32(store.ConvertContractNumberToContractID(LastContractNumberTextBox.Text)))
                myConfigData[0].LastContractID = store.ConvertContractNumberToContractID(LastContractNumberTextBox.Text);
            else
                MessageBox.Show("Eingegebene Vertragsnummer muss größer oder gleich der letzten vergebenen Vertragsnummer sein");

            LastContractNumberTextBox.Text = Item.ConvertContractIDToContractNumber(myConfigData[0].LastContractID);
        }



        private void OwnerEditUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(newVendor.LastName))
            {
                MessageBox.Show("Bitte Inhabernamen eingeben");
                e.Cancel = true;
                return;
            }
            else
                e.Cancel = false;
        }

        private void OwnerEditUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            OwnerEditUI ownerEditWindow = sender as OwnerEditUI;
            if (ownerEditWindow != null)
            {
                Vendor myNewVendor = new Vendor();
                myNewVendor = ownerEditWindow.NewVendorFromOwnerEdit;
                if (myNewVendor.AccountID != null)
                    ownerEditWindow.FormClosed -= new FormClosedEventHandler(OwnerEditUI_FormClosed);
            }
        }
    }
}
