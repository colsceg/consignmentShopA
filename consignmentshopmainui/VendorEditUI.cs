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
using ConsignmentShopMainUI;

namespace VendorEditUI
{
    public partial class VendorEdit : Form
    {
        public Store store = new Store();
        public bool updateRecord = false;
        private Vendor aVendor = new Vendor();
        private DataAccessVendors DBVendors = new DataAccessVendors();
        private DataAccessItems DBItems = new DataAccessItems();
        private DataAccessZipCode DBZipCode = new DataAccessZipCode();
        private OwnerEditUI OwnerEdit = new OwnerEditUI();

        public Vendor NewVendorFromVendorEdit
        {
            get { return this.aVendor; }
        }

        public bool VendorInserted { get; set; }

        public string IDInVendorIDTextBox
        {
            get { return this.VendorIDTextBox.Text; }
            set { this.VendorIDTextBox.Text = value; }
        }

        public string MarginInCommissionTextBox
        {
            get { return this.CommissionTextBox.Text; }
            set { this.CommissionTextBox.Text = value; }
        }

        public string FullNameInnameTextBox
        {
            get { return this.LastnameTextBox.Text + " ; " + FirstnameTextBox.Text + " ; " + VendorIDTextBox.Text; }
        }

        public string PeriodInExpirationTimeTextBox
        {
            get { return this.ExpirationTimeTextBox.Text; }
            set { this.ExpirationTimeTextBox.Text = value; }
        }

        public string PhoneNumberInTelefonTextBox
        {
            get { return this.TelefonTextBox.Text != "" ? this.TelefonTextBox.Text : this.MobilteTextBox.Text; }
        }

        private int lastAccountIDint;

        public VendorEdit()
        {
            InitializeComponent();
            //vT.Hide;
        }

        private void VendorEdit_Load(object sender, EventArgs e)
        {
                //Feststellen ob neu oder vorhanden bearbeiten
            Vendor newVendor = new Vendor();
            string selectedAccountID = VendorIDTextBox.Text;
            List<Vendor> currentVendors = DBVendors.GetVendorWithAccountID(selectedAccountID);
            if (currentVendors.Count > 0)
            {
                newVendor = getVendorFromList(currentVendors);
                fillAllEditFields(newVendor);
                updateRecord = true;
            }
            else  //Neuer Kunde
            {
                //letzte Kundennummer aktualisieren + 1
                string lastAccountID = DBVendors.GetLastAccountID();
                if (lastAccountID == null)
                {
                    MessageBox.Show("Bitte zuerst Stammdaten eintragen und speichern");
                    OwnerEdit.Show();
                }
                else
                {
                    lastAccountIDint = Convert.ToInt32(lastAccountID);
                    lastAccountIDint += 1;
                    //Felder mit Default Werten füllen

                    VendorIDTextBox.Text = store.BuildNumberToString(Convert.ToString(lastAccountIDint));
                    List<ConfigData> myConfigData = DBItems.GetConfigData();
                    CommissionTextBox.Text = Convert.ToString(myConfigData[0].Margin);
                    ExpirationTimeTextBox.Text = Convert.ToString(myConfigData[0].Period);
                    updateRecord = false;
                }
             }
        }

        private void VendorEdit_Shown(object sender, EventArgs e)
        {
            LastnameTextBox.Focus();
        }

        private void fillAllEditFields(Vendor aVendor)
        {
            Vendor newVendor = aVendor;
            VendorIDTextBox.Text = newVendor.AccountID;
            LastnameTextBox.Text = newVendor.LastName;
            FirstnameTextBox.Text = newVendor.FirstName;
            StreetTextBox.Text = newVendor.Street;
            PlzTextBox.Text = newVendor.Plz;
            TownTextBox.Text = newVendor.Town;
            TelefonTextBox.Text = newVendor.PhoneNumber1;
            MobilteTextBox.Text = newVendor.PhoneNumber2;
            EmailTextBox.Text = newVendor.EmailAccount;
            CommissionTextBox.Text = Convert.ToString(newVendor.Margin);
            ExpirationTimeTextBox.Text = Convert.ToString(newVendor.Period);
        }

        private List<Vendor> getVendorsFromTable(List<string> vendorsListStrings)
        {
            if (vendorsListStrings.Count > 0)
            {
                foreach (string item in vendorsListStrings)
                {
                    Vendor each = new Vendor();
                    String[] substr = item.Split(';');
                    each.AccountID = substr[0];
                    each.LastName = substr[1];
                    each.FirstName = substr[2];
                    each.Annex1 = substr[3];
                    each.Annex2 = substr[4];
                    each.Street = substr[5];
                    each.Plz = substr[6];
                    each.Town = substr[7];
                    each.PhoneNumber1 = substr[8];
                    each.PhoneNumber2 = substr[9];
                    each.EmailAccount = substr[10];
                    //try { each.margin = Convert.ToInt32(" "); }
                    //catch { each.margin = 0; }
                    //try { each.expireTime = Int32.Parse(substr[12]); }
                    //catch { each.expireTime = 0; }
                    //try { each.payoutValue = Int32.Parse(substr[13]); }
                    //catch { each.payoutValue = 0; }
                    //try { each.payedOutValue = Int32.Parse(substr[14]); }
                    //catch { each.payedOutValue = 0; }
                    store.Vendors.Add(each);
                }
            }
            return store.Vendors;
        }

        private Vendor getVendorFromList(List<Vendor> aVendorsList)
        {
            Vendor newVendor = new Vendor();
            if (aVendorsList.Count > 0)
            {
                newVendor = aVendorsList[0];
            }
            return newVendor;
        }

        //react to Button events
        private void SaveNewVendorButton_Click(object sender, EventArgs e)
        {
            DialogResult result;
            if (!String.IsNullOrWhiteSpace(LastnameTextBox.Text))
            {
                //alle Eingaben in Vendor model speichern dann DataAccess aufrufen
                List<Vendor> vendorsList = new List<Vendor>();
                //Global object aVendor
                aVendor.AccountID = VendorIDTextBox.Text;
                aVendor.LastName = LastnameTextBox.Text;
                if (String.IsNullOrWhiteSpace(FirstnameTextBox.Text))
                {
                    result = MessageBox.Show("Es wurde kein Vorname eingeben! Trotzdem speichern?", "", MessageBoxButtons.YesNo);
                    if ( result == DialogResult.Yes)
                        aVendor.FirstName = String.Empty;
                    else
                    {
                        LastnameTextBox.Focus();
                        return;
                    }
                }
                else
                    aVendor.FirstName = FirstnameTextBox.Text.Trim();
                
                aVendor.Street = StreetTextBox.Text.Trim();
                aVendor.Plz = PlzTextBox.Text.Trim();
                aVendor.Town = TownTextBox.Text.Trim();
                aVendor.PhoneNumber1 = TelefonTextBox.Text.Trim();
                aVendor.PhoneNumber2 = MobilteTextBox.Text.Trim();
                aVendor.EmailAccount = EmailTextBox.Text.Trim();
                try
                {
                    aVendor.Margin = Convert.ToInt32(CommissionTextBox.Text);
                }
                catch (Exception)
                {

                    aVendor.Margin = 50;
                }
                try
                {
                    aVendor.Period = Convert.ToInt32(ExpirationTimeTextBox.Text);
                }
                catch (Exception)
                {
                    aVendor.Period = 90;
                }                
                aVendor.Annex1 = String.Empty;
                aVendor.Annex2 = String.Empty;

                //if vendor exists update existing vendor
                vendorsList = DBVendors.GetVendorWithAccountID(aVendor.AccountID);
                if (vendorsList.Count > 0)
                {
                    DBVendors.UpdatePerson(aVendor);
                }
                else
                {   
                    //neuer Kunde in Datenbank eintragen
                    DBVendors.InsertPerson(aVendor);
                    VendorInserted = true;
                    //prüfen ob es einen Kunden mit Lastname, Firstname und Phonenumer schon gibt
                    vendorsList =  DBVendors.GetVendorsDouble(aVendor);
                    if (vendorsList.Count > 1)
                    {
                        //einen Kunden gefunden
                        result = MessageBox.Show("Es wurde ein ähnlicher Kunde gefunden \n" + vendorsList[0].LastName + ", " + vendorsList[0].FirstName + ", " + 
                                vendorsList[0].PhoneNumber1 + "\n Möchten Sie trotzdem speichern", "Warnung", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            //wenn ein Kunde mit gleichem Namen und Vornamen existiert
                            //und nicht gespeichert werden soll
                            DBVendors.DeletePerson(aVendor.AccountID);
                            aVendor.LastName = vendorsList[0].LastName;
                            aVendor.FirstName = vendorsList[0].FirstName;
                            aVendor.AccountID = vendorsList[0].AccountID;
                            VendorInserted = false;
                            return;
                        }
                    }
                }
                //Fenster schließen
                Close();
            }
            else
            {
                MessageBox.Show("Bitte Nachnamen eingeben");
                LastnameTextBox.Focus();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            VendorIDTextBox.Text = "";
            Close();
        }

        //react to Fields events
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

        private void CommissionTextBox_Leave(object sender, EventArgs e)
        {
            short value;
            if (Int16.TryParse(CommissionTextBox.Text, out value))
                CommissionTextBox.Text = string.Format("{0}", value);
            else
                CommissionTextBox.Text = string.Format("{0}", 50);
        }

        private void CommissionTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            short value;
            if (Int16.TryParse(CommissionTextBox.Text, out value))
                if (value > 100)
                {
                    MessageBox.Show("Maximal 100% möglich");
                    CommissionTextBox.Text = string.Format("{0}", 50);
                    CommissionTextBox.SelectAll();
                }
        }

        private void ExpirationTimeTextBox_Leave(object sender, EventArgs e)
        {
                short value;
                if (Int16.TryParse(ExpirationTimeTextBox.Text, out value))
                    ExpirationTimeTextBox.Text = string.Format("{0}", value);
                else
                    ExpirationTimeTextBox.Text = string.Format("{0}", 90);
        }

        private void LastnameTextBox_Leave(object sender, EventArgs e)
        {
            LastnameTextBox.Text = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(LastnameTextBox.Text);
        }

        private void FirstnameTextBox_Leave(object sender, EventArgs e)
        {
            FirstnameTextBox.Text= Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(FirstnameTextBox.Text);
        }

        private void StreetTextBox_Leave(object sender, EventArgs e)
        {
            StreetTextBox.Text= Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(StreetTextBox.Text);
        }

        private void TownTextBox_Leave(object sender, EventArgs e)
        {
            TownTextBox.Text= Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(TownTextBox.Text);
        }
    }
}
