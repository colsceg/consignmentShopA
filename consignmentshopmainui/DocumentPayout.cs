using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Documents;
using ConsignmentShopLibrary;
using System.Drawing.Printing;

namespace ConsignmentShopMainUI
{
    public partial class DocumentPayout : Form
    {


        private DataAccessItems DbItems = new DataAccessItems();
        private DataAccessVendors DbVendors = new DataAccessVendors();
        private List<Contract> ContractsList = new List<Contract>();
        private List<Item> ItemsList = new List<Item>();
        private Store Store = new Store();
        private string myAccountID; 
        private bool myFinalInvoice;
        private bool myContractPrinted;
        private string myInvoiceID;

        public string MyAccountID { get; set; }
        public bool MyFinalInvoce { get; set; }
        public string MyPayedSum { get; set; } //Der Betrag der nach Auszahlung dieses Dokumentes bezahlt wurde
        public string MyProvisionSum { get; set; }
        public bool MyContractPrinted { get; set; }

        public DocumentPayout()
        {
            InitializeComponent();
        }

        private void DocumentPayout_Load(object sender, EventArgs e)
        {
            this.myAccountID = this.MyAccountID;
            this.myFinalInvoice = this.MyFinalInvoce;
            this.myContractPrinted = this.MyContractPrinted;
        }

        private void Setup()
        {
            //ContractRichTextBox.Controls.Add(dgv);
            //this.ContractRichTextBox.Rtf = InsertTableInRichTextBox(4, 5, 750);
            //CreateDocument();
            CreateDocumentEx();
            //MyRichTextBox = ContractRichTextBox;
            //dgv.Show();
        }

        private void DocumentPayout_Shown(object sender, EventArgs e)
        {
            Setup();
        }

        private void CreateDocumentEx()
        {
            richTextBoxEx2.Font = new Font("Arial", 12f, FontStyle.Regular);
            richTextBoxEx2.BackColor = System.Drawing.Color.White;
            string header = "Quittung\n";

            richTextBoxEx2.Font = new Font("Arial", 12f, FontStyle.Bold);
            richTextBoxEx2.SelectionAlignment = HorizontalAlignment.Center;
            richTextBoxEx2.AppendText(header);

            //Kundendaten einlesen
            List<Vendor> myVendorList = new List<Vendor>();
            myVendorList = DbVendors.GetVendorWithAccountID(myAccountID);
            Vendor myVendor = myVendorList[0];

            //Geschäftsdaten einlesen
            List<Vendor> myOwnerList = new List<Vendor>();
            myOwnerList = DbVendors.GetOwner();
            Vendor myOwner = myOwnerList[0];

            //Artikelliste einlesen
            List<Item> myToPayItemList = new List<Item>();
            myToPayItemList = DbItems.GetItemsWithAccountIDNotPayedButSold(myAccountID);

            //Auszahlungsliste einlesen

            List<ItemAllGrouped> myNotPayedItemList = new List<ItemAllGrouped>();
            //myContractPayedItemList = DbItems.GetItemsWithContractIDGroupedPayed(MyAccountID);
            myNotPayedItemList = DbItems.GetAllItemsGroupedSoldNotPayedButSold(myAccountID);

            richTextBoxEx2.SelectionAlignment = HorizontalAlignment.Left;

            //Adressen eintragen
            int[] tabs = { 10, 450 };
            richTextBoxEx2.SelectionTabs = tabs;
            //Rechnungsnummer bilden
            myInvoiceID = DbItems.GetLastInvoiceNumber();
            myInvoiceID = Convert.ToString(Convert.ToInt32(myInvoiceID) + 1);
            DbItems.UpdateConfigDatLastInvoiceID(myInvoiceID);
            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            richTextBoxEx2.SelectedText = "\t\t" + "RechnungsNr: " + Item.ConvertContractIDToContractNumber(myInvoiceID) + "\n";
            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            richTextBoxEx2.SelectedText = "\t" + myVendor.LastName + " " + myVendor.FirstName + "\tInh. " + myOwner.LastName + " " + myOwner.FirstName + "\n";
            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            richTextBoxEx2.SelectedText = "\t" + myVendor.Street + "\t" + myOwner.Street + "\n";
            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            richTextBoxEx2.SelectedText = "\t" + myVendor.Plz + " " + myVendor.Town + "\t" + myOwner.Plz + " " + myOwner.Town + "\n";
            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            richTextBoxEx2.SelectedText = "\tKundenNr: " + myVendor.AccountID + "\tTelefon: " + myOwner.PhoneNumber1 + "\n";
            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            richTextBoxEx2.SelectedText = "\t\tMobil: " + myOwner.PhoneNumber2 + "\n";
            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);

            //Mittigen Strich erzeugen
            Byte[] By = { 33 };
            By[0] = 196;
            string underline = Store.ASCII8ToString(By);
            string underlineShort = Store.ASCII8ToString(By);
            for (int i = 0; i < 64; i++)
            {
                underline += Store.ASCII8ToString(By);
            }

            //string underline="_", underlineShort="_";
            //underline.PadLeft(60, '_');
            //underlineShort.PadLeft(20, '_');

            for (int i = 0; i < 30; i++)
            {
                underlineShort += Store.ASCII8ToString(By);
            }

            //Tabellenüberschrift
            int[] tabs1 = { 10, 96, 200, 300, 420, 520, 560 };
            richTextBoxEx2.SelectionTabs = tabs1;
            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            richTextBoxEx2.SelectedText = "\t" + underline + "\n";
            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            richTextBoxEx2.SelectedText = "\t" + "Datum" +  "\t" + "Artikel" + "\t" + "Farbe " + "\t" + "Marke " + "\t" +  "  VK-Preis" + "\t" + "Auszahlung" + "\n";
            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            richTextBoxEx2.SelectedText = "\t" + underline + "\n";

            decimal myTotalSum = 0;
            decimal myTotalToPaySum = 0;
            int row = 0;
            int[] tabs1a = { 10, 96, 144, 400, 520 };
            richTextBoxEx2.SelectionTabs = tabs1;

            foreach (var item in myToPayItemList)
            {
                string mySoldDate = item.SoldDate;
                string mySinglePrice = Store.SetStringLengthToTen(item.SalesPrice);
                string myCostPrice = Store.SetStringLengthToTen(item.CostPrice);
                string myAttrib1 = item.Color;
                string myAttrib2 = item.Brand;
                if (myAttrib1.Length > 15)
                    myAttrib1 = myAttrib1.Substring(0, 15);
                if (myAttrib2.Length > 15)
                    myAttrib2 = myAttrib2.Substring(0, 15);

                   //Prices als String mit Leerzeichen auf eine Länge von 9 bringen
                string myOutString = "\t" + mySoldDate + "\t" + item.ItemDescription + "\t" + myAttrib1 + "\t" + myAttrib2 + "\t" + mySinglePrice  + "\t" + myCostPrice + "\n";
                richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
                richTextBoxEx2.SelectedText = myOutString;
                row += 1;
                myTotalSum += Store.ConvertCurrencyToDecimal( item.SalesPrice);

            }
            decimal myMargin = myVendorList[0].Margin;
            decimal myTotalProvision = myTotalSum * myMargin / 100;
            myTotalToPaySum += myTotalSum - myTotalProvision;

            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            richTextBoxEx2.SelectedText = "\t" + underline + "\n";

            //Summenzeilen
            int[] tabs3 = { 10, 310, 420, 520 };
            //Summe aller Verkäufe
            richTextBoxEx2.SelectionTabs = tabs3;
            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            richTextBoxEx2.SelectedText = "\t" + "\t" + "Summe Verkäufe\t" + Store.SetStringLengthToTen(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", myTotalSum)) + "\n";
            //Summe aller Provisionen
            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            richTextBoxEx2.SelectionTabs = tabs3;
            richTextBoxEx2.SelectedText = "\t\t" + "abzüglich Provision\t" + Store.SetStringLengthToTen(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", myTotalProvision)) + "\n";
            //Bereits ausgezahlt
            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            richTextBoxEx2.SelectionTabs = tabs3;
            richTextBoxEx2.SelectedText = "\t\t " + underlineShort + "\n";
            //Noch zu zahlen    
            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            richTextBoxEx2.SelectedText = "\t\t" + "Auszahlungsbetrag\t" + Store.SetStringLengthToTen(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", myTotalToPaySum)) + "\n";
            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            richTextBoxEx2.SelectedText = "\t\t " + underlineShort + "\n";
            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            richTextBoxEx2.SelectedText = "\t" + underline + "\n";
            if (myTotalToPaySum > 0)
            {
                richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
                richTextBoxEx2.SelectedText = "\n\tHiermit bestätige ich den Empfang von:" + Store.SetStringLengthToTen(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", myTotalToPaySum)) + "\n";
            }

            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            richTextBoxEx2.SelectedText = "\n\t" + myOwner.Town + ", den " + DateTime.Today.ToShortDateString() + "\n";
            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            richTextBoxEx2.SelectedText = "\n\t__________________                              _______________________\n";
            richTextBoxEx2.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            richTextBoxEx2.SelectedText = "\n\n\t Unterschrift des Kunden                        Unterschrift " + myOwner.Annex1 + "\n";
        }

        private void PayAndPrintBtn_Click(object sender, EventArgs e)
        {
            //zur Abfrage Drucken Speichern Abbrechen
            //MessageBox.Show("not implemented yet");
            PrintRichTextContents myPrint = new PrintRichTextContents();
            myPrint.MyPrintDialog = printDialog1;
            myPrint.MyRichTextBoxEx = richTextBoxEx2;
            myPrint.PageNumberEnabled = true;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                MyContractPrinted = true;
                myPrint.PrintRTContents();                //Print Vertrag
            }
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            myInvoiceID = Convert.ToString(Convert.ToInt32(myInvoiceID) - 1);
            DbItems.UpdateConfigDatLastInvoiceID(myInvoiceID);
            Close();
        }

        private void PayNotPrintBtn_Click(object sender, EventArgs e)
        {
            //rechnungsnummer zurücksetzen
            myInvoiceID = DbItems.GetLastInvoiceNumber();
            myInvoiceID = Convert.ToString(Convert.ToInt32(myInvoiceID) - 1);
            DbItems.UpdateConfigDatLastInvoiceID(myInvoiceID);
            MyContractPrinted = true;
            Close();
        }

        private void DocumentPayout_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}

