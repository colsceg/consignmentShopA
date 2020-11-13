using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Documents;
using ConsignmentShopLibrary;
using System.Text;
using System.Drawing.Printing;

namespace ConsignmentShopMainUI
{
    public partial class DocumentContract : Form
    {
        private DataAccessItems DbItems = new DataAccessItems();
        private DataAccessVendors DbVendors = new DataAccessVendors();

        private List<Item> ItemsList = new List<Item>();
        private Store Store = new Store();
        private string myContractID;

        public string MyContractID { get; set; }
        public bool MyContractPrinted { get; set; }

        private List<Item> myContractItemList = new List<Item>();

        public List<Item> ContractItemList
        {
            get { return myContractItemList; }
            set { myContractItemList = value; }
        }


        public DocumentContract()
        {
            InitializeComponent();
        }

        private void DocumentContract_Load(object sender, EventArgs e)
        {
            this.myContractID = this.MyContractID;
        }

        private void Setup()
        {
            CreateDocumentEx();
        }

        private void DocumentContract_Shown(object sender, EventArgs e)
        {
            Setup();
        }

        //private RichTextBoxEx myRichTextBoxEx = new RichTextBoxEx();
        private void CreateDocumentEx()
        {
            myRichTextBoxEx.Font = new Font("Arial", 16f, FontStyle.Regular);
            myRichTextBoxEx.BackColor = System.Drawing.Color.White;


            //myRichTextBoxEx.SelectionFont = new Font("Arial", 12f, FontStyle.Bold);
            //myRichTextBoxEx.AppendText("zwischen\n");
            //myRichTextBoxEx.SelectionFont = new Font("Arial", 12f, FontStyle.Bold);
            //myRichTextBoxEx.AppendText("und\n");


            List<Contract> myContractList = new List<Contract>();
            List<Vendor> myVendorList = new List<Vendor>();
            Vendor myVendor;

            //Vertragsdaten einlesen
            if (myContractItemList.Count > 0)
            {
                //Aus ReportListe

                //Header setzen
                string header = "Kommissionsvertrag Nr: " + Item.ConvertContractIDToContractNumber(myContractItemList[0].ContractID) + "\n\n";
                myRichTextBoxEx.Font = new Font("Arial", 12f, FontStyle.Bold);
                myRichTextBoxEx.SelectionAlignment = HorizontalAlignment.Center;
                myRichTextBoxEx.AppendText(header);

                //Kundendaten einlesen
                myVendorList = DbVendors.GetVendorWithAccountID(myContractItemList[0].AccountID);
                myVendor = myVendorList[0];
                //Geschäftsdaten einlesen
                List<Vendor> myOwnerList = new List<Vendor>();
                myOwnerList = DbVendors.GetOwner();
                Vendor myOwner = myOwnerList[0];

                myRichTextBoxEx.SelectionAlignment = HorizontalAlignment.Left;

                //Adressen eintragen
                int[] tabs = { 10, 400 };
                myRichTextBoxEx.SelectionTabs = tabs;
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
                myRichTextBoxEx.SelectedText = "\t\t" + myOwner.Annex1 + "\n";
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
                myRichTextBoxEx.SelectedText = "\t" + myVendor.LastName + " " + myVendor.FirstName + "\tInh. " + myOwner.LastName + " " + myOwner.FirstName + "\n";
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
                myRichTextBoxEx.SelectedText = "\t" + myVendor.Street + "\t" + myOwner.Street + "\n";
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
                myRichTextBoxEx.SelectedText = "\t" + myVendor.Plz + " " + myVendor.Town + "\t" + myOwner.Plz + " " + myOwner.Town + "\n";
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
                myRichTextBoxEx.SelectedText = "\tKundenNr: " + myVendor.AccountID + "\tTelefon: " + myOwner.PhoneNumber1 + "\n";
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
                myRichTextBoxEx.SelectedText = "\t\tMobil: " + myOwner.PhoneNumber2 + "\n";
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
                myRichTextBoxEx.SelectedText = "\t\tVertragsbeginn:\t" + myContractItemList[0].BeginDate + "\n";
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
                myRichTextBoxEx.SelectedText = "\t\tVertragsende:    \t" + myContractItemList[0].EndDate + "\n";
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
                myRichTextBoxEx.SelectedText = "\tüber den Verkauf nachfolgender Artikel\n";

                //Mittigen Strich erzeugen
                Byte[] By = { 33 };
                By[0] = 196;
                string underline = Store.ASCII8ToString(By);
                for (int i = 0; i < 65; i++)
                {
                    underline += Store.ASCII8ToString(By);
                }
                //Tabellenüberschrift
                int[] tabs1 = { 10, 55, 180, 300, 380, 440, 550 };
                myRichTextBoxEx.SelectionTabs = tabs1;
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
                myRichTextBoxEx.SelectedText = "\t" + underline + "\n";
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
                myRichTextBoxEx.SelectedText = "\t" + "ArtNr" +
                    "\t" + "Artikel " +  //10
                    "\t" + " Marke " +
                    "\t" + " Farbe " +
                    "\t" + " Grösse " +
                    "\t" + "Sonstiges" +
                    "\t" + "VK-Preis" +
                    "\n";
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
                myRichTextBoxEx.SelectedText = "\t" + underline + "\n";

                decimal myTotalSum = 0;
                int row = 0;
                int[] tabs2 = { 10, 55, 180, 300, 380, 440, 545 };
                myRichTextBoxEx.SelectionTabs = tabs2;
                foreach (var item in myContractItemList)
                {
                    //string myAmount = Store.SetStringLengthToFour(Convert.ToString(item.ItemCount));
                    //Prices als String mit Leerzeichen auf eine Länge von 10 bringen
                    //string mySumPrice = Store.SetStringLengthToTen(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", item.SumPrice));
                    string mySinglePrice, myItemDescription, myBrand, myColor, mySize, myAttrib3; ;
                    decimal myPrice = Convert.ToDecimal(item.SalesPrice);

                    mySinglePrice = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", myPrice);
                    mySinglePrice = mySinglePrice.PadLeft(10, ' ');
                    myItemDescription = item.ItemDescription.Substring(0, item.ItemDescription.Length < 17 ? item.ItemDescription.Length : 17);
                    myItemDescription = myItemDescription.PadRight(17, ' ');
                    myBrand = item.Brand.Substring(0, item.Brand.Length < 17 ? item.Brand.Length : 17);
                    myBrand = myBrand.PadRight(17, ' ');
                    myColor = item.Color.Substring(0, item.Color.Length < 11 ? item.Color.Length : 11);
                    myColor = myColor.PadRight(11, ' ');
                    mySize = item.Size.Substring(0, item.Size.Length < 5 ? item.Size.Length : 5);
                    mySize = mySize.PadLeft(5, ' ');
                    myAttrib3 = item.Prop.Substring(0, item.Prop.Length < 12 ? item.Prop.Length : 12);
                    myAttrib3 = myAttrib3.PadRight(12, ' ');

                    //item.Attribute2.CopyTo(0, myItemDescription, 0, 15);
                    string myOutString = "\t" + item.ItemNumber + "\t" + myItemDescription + "\t" + myBrand + "\t" + myColor +
                        "\t" + mySize + "\t" + myAttrib3 + "\t" + mySinglePrice + "\n";
                    myRichTextBoxEx.SelectionFont = new Font("Segoe UI", 10f, FontStyle.Regular);
                    myRichTextBoxEx.SelectedText = myOutString;
                    row += 1;
                    myTotalSum += Convert.ToDecimal(item.SalesPrice);
                }

                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
                myRichTextBoxEx.SelectedText = "\t" + underline + "\n";

                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
                string mySumPrice = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", myTotalSum);
                mySumPrice = mySumPrice.PadLeft(10, ' ');
                //myRichTextBoxEx.SelectedText = "\t\t\t\t\t\t" + "Summe" + "\t" + mySumPrice + " \n";

                //myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
                //myRichTextBoxEx.SelectedText = "\t" + underline + "\n";

                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
                myRichTextBoxEx.SelectedText = "\n\t" + myOwner.Town + " den " + DateTime.Today.ToShortDateString() + "\n";
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
                myRichTextBoxEx.SelectedText = "\n\tFalls Sie die Restware zurück haben möchten, muss diese bis spätestens 10 Tage\n";
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
                myRichTextBoxEx.SelectedText = "\tnach Vertragsablauf abgeholt werden. Danach geht diese in das Eigentum des Geschäftes über. \n";
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
                myRichTextBoxEx.SelectedText = "\tMit der Unterschrift akzeptieren Sie diese Kommissionsbedingungen\n\n";
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
                myRichTextBoxEx.SelectedText = "\t Restware zurück  Ja:     Nein:  \n\n\n\n";

                // zwei Striche 
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
                myRichTextBoxEx.SelectedText = "\n\t______________________________                  _______________________________\n";
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
                myRichTextBoxEx.SelectedText = "\n\n\t Unterschrift des Kunden                                       Unterschrift des Geschäftes\n";
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            //zur Abfrage Drucken Speichern Abbrechen
            //MessageBox.Show("not implemented yet");
            PrintRichTextContents myPrint = new PrintRichTextContents();
            myPrint.MyPrintDialog = printDialog1;
            myPrint.MyRichTextBoxEx = myRichTextBoxEx;
            myPrint.PageNumberEnabled = true;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                MyContractPrinted = true;
                myPrint.PrintRTContents();
            }
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            MyContractPrinted = false;
            Close();
        }
    }
}
