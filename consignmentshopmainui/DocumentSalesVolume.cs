using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Documents;
using ConsignmentShopLibrary;
using System.Drawing.Printing;
using System.Linq;

namespace ConsignmentShopMainUI
{
    public partial class DocumentSalesVolume : Form
    {
        private DataAccessItems DbItems = new DataAccessItems();
        private DataAccessVendors DbVendors = new DataAccessVendors();
        private List<Contract> ContractsList = new List<Contract>();
        private List<Item> ItemsList = new List<Item>();
        private Store Store = new Store();

        public string MyAccountID { get; set; }
        public string MyContractID { get; set; }
        public bool MyContractPrinted { get; set; }
        public string MyFromDate { get; set; }
        public string MyToDate { get; set; }
        public List<ItemReport> MyItemsList { get; set; }
        public string MyTitle { get; set; }
        public string MyDateHeader { get; set; }

        public DocumentSalesVolume()
        {
            InitializeComponent();
        }

        private void DocumentSalesVolume_Load(object sender, EventArgs e)
        {
            //
        }

        private void DocumentSalesVolume_Shown(object sender, EventArgs e)
        {
            Setup();
        }

        private void Setup()
        {
            //ContractRichTextBox.Controls.Add(dgv);
            //this.ContractRichTextBox.Rtf = InsertTableInRichTextBox(4, 5, 750);
            CreateDocumentEx();
            //dgv.Show();
        }

        private void CreateDocumentEx()
        {
            List<ItemSalesVolumeGrouped> mySalesVolumeItemsList = new List<ItemSalesVolumeGrouped>();
            if (MyItemsList.Count > 0)
            {
                ItemSalesVolumeGrouped mySalesVolumeItem = new ItemSalesVolumeGrouped();

                decimal mySalesSum = 0, myCostSum = 0;
                int myItemCount = 0;

                foreach (var item in MyItemsList)
                {
                    mySalesSum = Store.ConvertCurrencyToDecimal(item.SalesPrice);
                    myCostSum = Store.ConvertCurrencyToDecimal(item.CostPrice);
                    mySalesVolumeItem.ContractID = item.ContractID;
                    mySalesVolumeItem.ItemDescription = item.ItemDescription;
                    mySalesVolumeItem.SumSoldPrice = Convert.ToString(mySalesSum);
                    mySalesVolumeItem.SumCostPrice = Convert.ToString(myCostSum);
                    mySalesVolumeItem.SoldCount = myItemCount;
                    mySalesVolumeItemsList.Add(mySalesVolumeItem);
                    myItemCount += 1;
                }
            }


            myRichTextBoxEx.Font = new Font("Arial", 16f, FontStyle.Regular);
            myRichTextBoxEx.BackColor = System.Drawing.Color.White;
            int[] tabs = {150, 500 };
            myRichTextBoxEx.SelectionTabs = tabs;
            //Header setzen
            string header = $"\t{MyTitle}  " ;
            myRichTextBoxEx.Font = new Font("Arial", 14f, FontStyle.Bold);
            myRichTextBoxEx.SelectionAlignment = HorizontalAlignment.Center;
            myRichTextBoxEx.AppendText(header);
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            myRichTextBoxEx.AppendText("vom: " + MyFromDate + " bis: " + MyToDate + "\tStand ");
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            myRichTextBoxEx.AppendText(DateTime.Today.ToShortDateString() + "\n");

            //Mittigen Strich erzeugen
            Byte[] By = { 33 };
            By[0] = 196;
            string underline = Store.ASCII8ToString(By);
            for (int i = 0; i < 78; i++)
            {
                underline += Store.ASCII8ToString(By);
            }
            //Tabellenüberschrift
            int[] tabs1 = { 90, 230, 330, 410, 520, 630 };
            myRichTextBoxEx.SelectionTabs = tabs1;
            myRichTextBoxEx.SelectionAlignment = HorizontalAlignment.Left;
            myRichTextBoxEx.SelectionFont = new Font("Arial", 9f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = underline + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 9f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = $"ArtikelNr\tArtikel\t{MyDateHeader}\tProv. %\tVK-Preis\tAuszahlung\tProvision\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 9f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = underline + "\n";

            decimal myTotalSumComission = 0;
            decimal myTotalSumSoldPrice = 0;
            decimal myTotalSumCostPrice = 0;

            if (MyItemsList.Count > 0)
            {
                decimal myComission = 0;
                decimal mySoldPrice = 0;
                decimal myCostPrice = 0;

                string myComissionString;
                string mySoldPriceString;
                string myCostPriceString;
                string myItemNumber;
                string myItemDescription;
                int myMarge = 0;

                int[] tabs2 = { 90, 235, 330, 405, 520, 620 };
                myRichTextBoxEx.SelectionTabs = tabs2;
                foreach (var item in MyItemsList)
                {
                    mySoldPrice = Store.ConvertCurrencyToDecimal(item.SalesPrice);
                    myCostPrice = Store.ConvertCurrencyToDecimal(item.CostPrice);
                    myComission = mySoldPrice - myCostPrice;
                    if (mySoldPrice > 0)
                    {
                        myTotalSumComission += myComission;
                        myTotalSumCostPrice += myCostPrice;
                        myTotalSumSoldPrice += mySoldPrice;

                        myItemNumber = item.ItemNumber;
                        myMarge = Convert.ToInt32((mySoldPrice - myCostPrice) * 100 / mySoldPrice);
                        myItemDescription = item.ItemDescription.Substring(0, item.ItemDescription.Length < 16 ? item.ItemDescription.Length : 15);
                        myComissionString = Store.SetStringLengthToTen(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", myComission));
                        mySoldPriceString = Store.SetStringLengthToTen(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", mySoldPrice));
                        myCostPriceString = Store.SetStringLengthToTen(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", myCostPrice));
                        myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
                        myRichTextBoxEx.SelectedText = myItemNumber + "\t" + myItemDescription + "\t" + item.SoldDate + "\t" + Store.SetStringLengthToFour(Convert.ToString(myMarge)) + "\t" + mySoldPriceString + "\t" + myCostPriceString + "\t" + myComissionString + "\n";
                    }
                }
            }
            myRichTextBoxEx.SelectionFont = new Font("Arial", 9f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = underline + "\n";

            //Summe aller Verkäufe
            int[] tabs3 = { 10, 460, 620 };
            myRichTextBoxEx.SelectionTabs = tabs3;
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = "Zusammenfassung\t" + "Gesamtumsatz\t" + Store.SetStringLengthToTen(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", myTotalSumSoldPrice)) + "\n";
            //Summe aller Provisionen
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            //myRichTextBoxEx.SelectionTabs = tabs4;
            myRichTextBoxEx.SelectedText = "\t\t" + "Summe Auszahlungen\t" + Store.SetStringLengthToTen(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", myTotalSumCostPrice)) + "\n";
            //Bereits ausgezahlt
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            //myRichTextBoxEx.SelectionTabs = tabs4;
            myRichTextBoxEx.SelectedText = "\t\t" + "Summe Kommission\t" + Store.SetStringLengthToTen(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", myTotalSumComission)) + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 9f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = underline + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            //myRichTextBoxEx.SelectionTabs = tabs4;
            myRichTextBoxEx.SelectedText = "Bei den Auszahlungen handelt es sich um die im Kommissionsvertrag vorgesehenen Summen";
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
            //SaveMyFile();
            this.Close();
        }

        public void SaveMyFile()
        {
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                myRichTextBoxEx.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveMyFile();
        }
    }
}
