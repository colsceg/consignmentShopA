using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Documents;
using ConsignmentShopLibrary;
using System.Drawing.Printing;

namespace ConsignmentShopMainUI
{
    public partial class DocumentReturnList : Form
    {

        private DataAccessItems DbItems = new DataAccessItems();
        private DataAccessVendors DbVendors = new DataAccessVendors();
        private List<Contract> ContractsList = new List<Contract>();
        private List<Item> ItemsList = new List<Item>();
        private Store Store = new Store();
        private string myContractID;

        public string MyContractID { get; set; }

        public DocumentReturnList()
        {
            InitializeComponent();
        }

        private void DocumentReturnList_Load(object sender, EventArgs e)
        {
            this.myContractID = Store.ConvertContractNumberToContractID(this. MyContractID);
        }

        private void Setup()
        {
            CreateDocument();
        }

        private void DocumentReturnList_Shown(object sender, EventArgs e)
        {
            Setup();
        }

        private void CreateDocument()
        {
            myRichTextBoxEx.Font = new Font("Arial", 12f, FontStyle.Regular);
            myRichTextBoxEx.BackColor = System.Drawing.Color.White;
            string header = "";
            //Header setzen

            header = "Rücklieferschein\n";
            myRichTextBoxEx.Font = new Font("Arial", 14f, FontStyle.Bold);
            myRichTextBoxEx.SelectionAlignment = HorizontalAlignment.Center;
            myRichTextBoxEx.AppendText(header);
            myRichTextBoxEx.AppendText("für\n");
            header = "Kommissionsvertrag Nr: " + Item.ConvertContractIDToContractNumber(myContractID) + "\n\n";
            myRichTextBoxEx.Font = new Font("Arial", 14f, FontStyle.Bold);
            myRichTextBoxEx.SelectionAlignment = HorizontalAlignment.Center;
            myRichTextBoxEx.AppendText(header);

            //Vertragsdaten einlesen
            List<Contract> myContractList = new List<Contract>();
            myContractList = DbItems.GetContractWithContractID( myContractID);
            Contract myContract = myContractList[0];

            //Kundendaten einlesen
            List<Vendor> myVendorList = new List<Vendor>();
            myVendorList = DbVendors.GetVendorWithAccountID(myContract.AccountID);
            Vendor myVendor = myVendorList[0];

            //Geschäftsdaten einlesen
            List<Vendor> myOwnerList = new List<Vendor>();
            myOwnerList = DbVendors.GetOwner();
            Vendor myOwner = myOwnerList[0];

            //Artikelliste einlesen
            List<Item> myContractItemList = new List<Item>();
            //Gruppierte Liste aller Positionen mit Artikelbeschreibung - Summe Geliefert - Summe Verkauft - Summe Rückgabe - SalesPrice 
            //Count(PosNumber) - Count(PosNumber with soldDate <> "" - 
            myContractItemList = DbItems.GetItemsWithContractID(myContractID);
            List<ItemReturnGrouped> myContractGroupedItemList = new List<ItemReturnGrouped>();
            myContractGroupedItemList = buildItemDataCollectionReturn(myContractItemList);

            myRichTextBoxEx.SelectionAlignment = HorizontalAlignment.Left;

            //Adressen eintragen
            int[] tabs = { 400, 450 };
            myRichTextBoxEx.SelectionTabs = tabs;
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = "\t" + myOwner.Annex1 + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            myRichTextBoxEx.SelectedText =  myVendor.LastName + " " + myVendor.FirstName + "\tInh. " + myOwner.LastName + " " + myOwner.FirstName + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            myRichTextBoxEx.SelectedText = myVendor.Street + "\t" + myOwner.Street + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            myRichTextBoxEx.SelectedText =  myVendor.Plz + " " + myVendor.Town + "\t" + myOwner.Plz + " " + myOwner.Town + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            myRichTextBoxEx.SelectedText = "KundenNr: " + myVendor.AccountID + "\tTelefon: " + myOwner.PhoneNumber1 + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            myRichTextBoxEx.SelectedText = "\tMobil: " + myOwner.PhoneNumber2 + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = "\tVertragsbeginn: \t" + myContract.BeginDate + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = "\tVertragsende:\t" + myContract.EndDate + "\n";

            //Mittigen Strich erzeugen
            Byte[] By = { 33 };
            By[0] = 196;
            string underline = Store.ASCII8ToString(By);
            string underlineShort = Store.ASCII8ToString(By);
            for (int i = 0; i < 59; i++)
            {
                underline += Store.ASCII8ToString(By);
            }

            //Tabellenüberschrift
            int[] tabs1 = { 320, 380, 440, 520 };
            myRichTextBoxEx.SelectionTabs = tabs1;

            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = "Artikelbestand" + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = underline + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = "Artikel" + "\t" + "Geliefert" + "\t" + "Verkauft" + "\t" + "Rückgabe" + "\t" + "E-Preis" + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = underline + "\n";

            int[] tabs2 = { 340, 400, 460, 500 };
            myRichTextBoxEx.SelectionTabs = tabs2;
            foreach (var item in myContractGroupedItemList)
            {
                string myItemDescription = item.ItemDescription;
                
                string myPosNumber = item.PosNumber;

                int myTotalItemsCount = item.TotalItemsCount;
                int mySoldItemsCount = item.SoldItemsCount;
                int myReturnItemsCount = myTotalItemsCount - mySoldItemsCount;

                string myTotalItemsCountString = Store.SetStringLengthToFour(Convert.ToString( item.TotalItemsCount));
                string mySoldItemsCountString = Store.SetStringLengthToFour(Convert.ToString(item.SoldItemsCount));
                string myReturnItemsCountString = Store.SetStringLengthToFour(Convert.ToString(myReturnItemsCount));
                string mySalesPrice = Store.SetStringLengthToTen(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", Convert.ToDecimal(item.SalesPrice)));

                //Prices als String mit Leerzeichen auf eine Länge von 9 bringen
                string myOutString = myItemDescription + "\t" + myTotalItemsCountString + "\t" + mySoldItemsCountString + "\t" + myReturnItemsCountString + "\t" + mySalesPrice + "\n";
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
                myRichTextBoxEx.SelectedText = myOutString;
            }
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = underline + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            myRichTextBoxEx.SelectedText = "\n" + myOwner.Town + " den " + DateTime.Today.ToShortDateString() + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = "\nHiermit bestätige ich den Empfang der oben aufgeführten Artikel \n";

            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            myRichTextBoxEx.SelectedText = "\n" + myOwner.Town + " den " + DateTime.Today.ToShortDateString() + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = "\n\n    __________________ \n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            myRichTextBoxEx.SelectedText = "   Unterschrift des Kunden ";
        }

        private List<ItemReturnGrouped> buildItemDataCollectionReturn(List<Item> anItemCollection)
        {
            List<ItemReturnGrouped> myGroupedList = new List<ItemReturnGrouped>();
            Item myItemOld = new Item();
            Item myItemTemp = new Item();
            ItemReturnGrouped myGroupedItem = new ItemReturnGrouped();
            int i = 0, menge = 1, pos = 1, mySoldCount = 0;

            if (anItemCollection.Count > 0)
            {
                foreach (var item in anItemCollection)
                {
                    if (i == 0)
                    {
                        myItemOld.ItemNumber = item.ItemNumber;
                        myItemOld.ItemDescription = item.ItemDescription;
                        myItemOld.SalesPrice = item.SalesPrice;
                        myItemOld.PosNumber = item.PosNumber;
                        if (item.SoldDate != "")
                        {
                            mySoldCount += 1;
                        }
                        myItemTemp.ItemNumber = item.ItemNumber;
                        myItemTemp.ItemDescription = item.ItemDescription;
                        myItemTemp.SalesPrice = item.SalesPrice;
                        myItemTemp.PosNumber = item.PosNumber;
                    }
                    else
                    {
                        if (item.PosNumber != myItemOld.PosNumber)
                        {
                            //posNumber vom Folgesatz ist nicht gleich posNumber vom vorherigen
                            //dann item in myGroupedList speichern
                            myGroupedItem.ItemDescription = myItemTemp.ItemDescription;
                            myGroupedItem.SalesPrice = myItemTemp.SalesPrice;
                            myGroupedItem.TotalItemsCount = menge;
                            myGroupedItem.SoldItemsCount = mySoldCount;
                            myGroupedList.Add(myGroupedItem);
                            mySoldCount = 0;
                            myGroupedItem = new ItemReturnGrouped();
                            //dann temp und Old gleich item setzen menge = 1 (pos = 1??)
                            myItemOld.ItemNumber = item.ItemNumber;
                            myItemOld.ItemDescription = item.ItemDescription;
                            myItemOld.SalesPrice = item.SalesPrice;
                            myItemOld.PosNumber = item.PosNumber;
                            if (item.SoldDate != "")
                                mySoldCount += 1;
                            myItemTemp.ItemNumber = item.ItemNumber;
                            myItemTemp.ItemDescription = item.ItemDescription;
                            myItemTemp.SalesPrice = item.SalesPrice;
                            myItemTemp.PosNumber = item.PosNumber;
                            menge = 1;
                            pos += 1;
                        }
                        else
                        {
                            //aktuelle posNumber gleich der vorherigen menge+=1 und item in old speichern
                            menge += 1;
                            if (item.SoldDate != "")
                                mySoldCount += 1;
                            myItemOld.ItemNumber = item.ItemNumber;
                            myItemOld.ItemDescription = item.ItemDescription;
                            myItemOld.SalesPrice = item.SalesPrice;
                            myItemOld.PosNumber = item.PosNumber;
                        }
                    }
                    i += 1;
                }
                myGroupedItem.ItemDescription = myItemTemp.ItemDescription;
                myGroupedItem.SalesPrice = myItemTemp.SalesPrice;
                myGroupedItem.TotalItemsCount = menge;
                myGroupedItem.SoldItemsCount = mySoldCount;
                myGroupedList.Add(myGroupedItem);
            }
            return myGroupedList;
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
                myPrint.PrintRTContents();
            }
            this.Close();
        }
    }
}
