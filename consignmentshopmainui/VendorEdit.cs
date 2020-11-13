using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsignmentShopLibrary;
using ConsignmentShopMainUI;

namespace VendorEditUI
{
    

    public partial class VendorEdit : Form
    {
        public Store store = new Store();
        public Boolean updateRecord = false;
        private Vendor aVendor = new Vendor();
        private DataAccessVendors db = new DataAccessVendors();
        private VendorTableUI vT;
        

        public VendorEdit(VendorTableUI caller)
        {

            InitializeComponent();
            // vendorIDTextBox.Text = store.vendors[0].accountID.ToString();
            // lastnameTextBox.Text= store.vendors[0].name.ToString();
            vT = caller;
            //vT.Hide;

        }

        private void VendorEdit_Load(object sender, EventArgs e)
        {
            //Feststellen ob neu oder vorhanden bearbeiten
            DataGridView customersGridView = vT.Controls["vendorDataGridView"] as DataGridView;
            Vendor newVendor = new Vendor(); 
            if (customersGridView.SelectedRows.Count >0)
            {
                string selectedAccountID = customersGridView.SelectedRows[0].Cells[0].Value.ToString();
                List<Vendor> currentVendors = db.GetVendorWithAccountID(selectedAccountID);
                if (currentVendors.Count > 0)
                {
                    newVendor =  getVendorFromList(currentVendors);
                    fillAllEditFields(newVendor);
                    updateRecord = true;
                }
            }
            else  //Neuer Kunde
            {
                //letzte Kundennummer aktualisieren + 1
                string lastAccountID = db.GetLastAccountID();
                int lastAccountIDint = Convert.ToInt32(lastAccountID);
                lastAccountIDint += 1;
                //Felder mit Default Werten füllen
                vendorIDTextBox.Text = store.buildNumberToString(Convert.ToString(lastAccountIDint));
                commissionTextBox.Text = "50";
                expirationTimeTextBox.Text = "90";
                updateRecord = false;
            }
        }

        private void fillAllEditFields(Vendor aVendor)
        {
            Vendor newVendor = aVendor;
            vendorIDTextBox.Text = newVendor.accountID;
            lastnameTextBox.Text = newVendor.name;
            firstnameTextBox.Text = newVendor.firstName;
            streetTextBox.Text = newVendor.street;
            plzTextBox.Text = newVendor.plz;
            townTextBox.Text = newVendor.town;
            telefonTextBox.Text = newVendor.phoneNumber1;
            mobilteTextBox.Text = newVendor.phoneNumber2;
            emailTextBox.Text = newVendor.emailAccount;
            commissionTextBox.Text = Convert.ToString(newVendor.margin);
            expirationTimeTextBox.Text = Convert.ToString(newVendor.period);
        }

        private List<Vendor> getVendorsFromTable(List<string> vendorsListStrings)
        {
            if (vendorsListStrings.Count > 0)
            {
                foreach (string item in vendorsListStrings)
                {
                    Vendor each = new Vendor();
                    String[] substr = item.Split(';');
                    each.accountID = substr[0];
                    each.name = substr[1];
                    each.firstName = substr[2];
                    each.annex1 = substr[3];
                    each.annex2 = substr[4];
                    each.street = substr[5];
                    each.plz = substr[6];
                    each.town = substr[7];
                    each.phoneNumber1 = substr[8];
                    each.phoneNumber2 = substr[9];
                    each.emailAccount = substr[10];
                    //try { each.margin = Convert.ToInt32(" "); }
                    //catch { each.margin = 0; }
                    //try { each.expireTime = Int32.Parse(substr[12]); }
                    //catch { each.expireTime = 0; }
                    //try { each.payoutValue = Int32.Parse(substr[13]); }
                    //catch { each.payoutValue = 0; }
                    //try { each.payedOutValue = Int32.Parse(substr[14]); }
                    //catch { each.payedOutValue = 0; }
                    store.vendors.Add(each);
                }
            }
            return store.vendors;
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

        private void clearAllFields()
        {
            // Alle Eingabefelder der leer

        }

        private void saveNewVendorButton_Click(object sender, EventArgs e)
        {
            //alle Eingaben in Vendor model speichern dann DataAccess aufrufen
            List<Vendor> vendorsList = new List<Vendor>();
            DataGridView customersGridView = vT.Controls["vendorDataGridView"] as DataGridView;

            aVendor.accountID = vendorIDTextBox.Text;
            aVendor.name = lastnameTextBox.Text;
            aVendor.firstName = firstnameTextBox.Text;
            aVendor.street = streetTextBox.Text;
            aVendor.plz = plzTextBox.Text;
            aVendor.town = townTextBox.Text;
            aVendor.phoneNumber1 = telefonTextBox.Text;
            aVendor.phoneNumber1 = mobilteTextBox.Text;
            aVendor.emailAccount = emailTextBox.Text;
            aVendor.margin = Convert.ToUInt32(commissionTextBox.Text);
            aVendor.period = Convert.ToUInt32(expirationTimeTextBox.Text);
            aVendor.annex1 = "";
            aVendor.annex2 = "";

            //vorhandenen Kunden updaten  

            //Neuen Lieferanten in customers Tabelle einfügen
            if (updateRecord)
            {
                db.UpdatePerson(aVendor);
            }
            else
            {
                db.InsertPerson(aVendor);
            }

            //Tabelle in VendorTableUI (vendorDataGridView) updaten
            vendorsList = db.GetAllVendors();
            customersGridView.DataSource = vendorsList;

            String searchValue = aVendor.accountID;
            int rowIndex = -1;
            foreach (DataGridViewRow row in customersGridView.Rows)
            {
                if (row.Cells[0].Value != null) // Need to check for null if new row is exposed
                {
                    if (row.Cells[0].Value.ToString().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
            }

            if (rowIndex >= customersGridView.Rows.Count)
            {
                customersGridView.FirstDisplayedScrollingRowIndex = customersGridView.Rows.Count - 1;
                customersGridView.Rows[customersGridView.Rows.Count - 1].Selected = true;
            }
            else
            {
                customersGridView.FirstDisplayedScrollingRowIndex = rowIndex;
                customersGridView.Rows[rowIndex].Selected = true;
            }

            //Fenster schließen
            Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {

            Close();
        }

    }
}
