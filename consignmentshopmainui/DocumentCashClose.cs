using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentShopMainUI
{
    public partial class DocumentCashClose : Form
    {
        private DataAccessItems DbItems = new DataAccessItems();
        private DataAccessVendors DbVendors = new DataAccessVendors();
        private List<Contract> ContractsList = new List<Contract>();
        private List<Item> ItemsList = new List<Item>();
        private Store Store = new Store();

        public List<CashCloseSoldItem> MySoldItemsList { get; set; }
        public List<CashClosePayedItem> MyPayedItemsList { get; set; }
        public CashClosePrintItem MyCashClosePrintItem { get; set; }

        public DocumentCashClose()
        {
            InitializeComponent();
        }
        private void Setup()
        {
            CreateDocumentEx();
        }

        //private RichTextBoxEx myRichTextBoxEx = new RichTextBoxEx();
        private void CreateDocumentEx()
        {
            double mySollBestand = MyCashClosePrintItem.StartSum + MyCashClosePrintItem.SoldSum  - MyCashClosePrintItem.PayedSum;
            double myDiffBestand = MyCashClosePrintItem.IstSum - mySollBestand;
            myRichTextBoxEx.Font = new Font("Arial", 16f, FontStyle.Regular);
            myRichTextBoxEx.BackColor = System.Drawing.Color.White;

            //Header setzen
            string header = "Kassenabschluss  " + DateTime.Today.ToShortDateString() + "\n\n";
            myRichTextBoxEx.Font = new Font("Arial", 16f, FontStyle.Bold);
            myRichTextBoxEx.SelectionAlignment = HorizontalAlignment.Center;
            myRichTextBoxEx.AppendText(header);

            //Mittigen Strich erzeugen
            Byte[] By = { 33 };
            By[0] = 196;
            string underline = Store.ASCII8ToString(By);
            for (int i = 0; i < 62; i++)
            {
                underline += Store.ASCII8ToString(By);
            }

            int[] tabs = {200 };
            myRichTextBoxEx.SelectionTabs = tabs;
            myRichTextBoxEx.SelectionAlignment = HorizontalAlignment.Left;
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = "Anfangskassenbestand: ";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            myRichTextBoxEx.SelectedText = "\t" + Store.SetStringLengthToTen( String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", MyCashClosePrintItem.StartSum)) + "\n\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = "Tatsächlicher Kassenbestand:  ";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            myRichTextBoxEx.SelectedText = "\t" + Store.SetStringLengthToTen(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", MyCashClosePrintItem.IstSum)) + "\n\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = "Heutige Einnahmen: " ;
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            myRichTextBoxEx.SelectedText = "\t" + Store.SetStringLengthToTen(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", MyCashClosePrintItem.SoldSum)) + "\n\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = "Heutige Auszahlungen:  ";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            myRichTextBoxEx.SelectedText = "\t" + Store.SetStringLengthToTen(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", MyCashClosePrintItem.PayedSum)) + "\n\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = "Soll Kassenbestand: ";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            myRichTextBoxEx.SelectedText = "\t" + Store.SetStringLengthToTen(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", mySollBestand)) + "\n\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = "Differenz:  ";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
            myRichTextBoxEx.SelectedText = "\t" + Store.SetStringLengthToTen(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", myDiffBestand)) + "\n\n";

            //Tabellenüberschrift Verkäufe
            int[] tabs1 = {66, 124, 160, 250, 360, 450};

            myRichTextBoxEx.SelectionTabs = tabs1;
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = "Liste der Verkäufe:  ";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = underline + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = "VertrNr" + "\t" + "KDNr" + "\t" + "Name" + "\t" + "Artikel" + "\t" + "Menge \t"  + "   G-Preis" + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = underline + "\n";
            int[] tabs2 = { 66, 124, 160, 250, 370, 440};

            myRichTextBoxEx.SelectionTabs = tabs2;
            foreach (var item in MySoldItemsList)
            {
                string mySalesSumPrice = Store.SetStringLengthToTen(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", item.SalesPrice));
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
                myRichTextBoxEx.SelectedText = item.ContractID + "\t" + item.AccountID + "\t" + item.FullName + "\t" + item.ItemDescription + "\t" + item.PosCount + "\t" + mySalesSumPrice + "\n";
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            }

            //Tabellenüberschrift Auszahlungen
            myRichTextBoxEx.SelectionTabs = tabs1;
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = "\n\nListe der Auszahlungen:  ";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = underline + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = "VertrNr" + "\t" + "KDNr" + "\t" + "Name" + "\t\t" + "Auszahlung" + "\n";
            myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            myRichTextBoxEx.SelectedText = underline + "\n";
            myRichTextBoxEx.SelectionTabs = tabs2;
            foreach (var item in MyPayedItemsList)
            {
                string myPayedSumPrice = Store.SetStringLengthToTen(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", item.CostPrice));
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
                myRichTextBoxEx.SelectedText = item.ContractID + "\t" + item.AccountID + "\t" + item.FullName + "\t" + "\t" + myPayedSumPrice + "\n";
                myRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
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
                myPrint.PrintRTContents();
            }
            this.Close();
        }

        private void DocumentCashClose_Shown(object sender, EventArgs e)
        {
            Setup();
        }
    }
}
