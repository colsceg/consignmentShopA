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
    public partial class DocumentMonthlyVolumes : Form
    {
        private Store Store = new Store();

        public List<CashVolumeMonthly> CashVolumeList { get; set; }

        public DocumentMonthlyVolumes()
        {
            InitializeComponent();
        }
        private void DocumentMonthlyVolumes_Load(object sender, EventArgs e)
        {

        }

        private void DocumentMonthlyVolumes_Shown(object sender, EventArgs e)
        {
            Setup();
        }

        private void Setup()
        {
            CreateDocument();
        }

        private void CreateDocument()
        {
            MyRichTextBoxEx.Font = new Font("Arial", 12f, FontStyle.Regular);
            MyRichTextBoxEx.BackColor = System.Drawing.Color.White;
            string header = "";
            //Header setzen

            header = "Monatliche Umsätze und Auszahlungen\n";
            MyRichTextBoxEx.Font = new Font("Arial", 14f, FontStyle.Bold);
            MyRichTextBoxEx.SelectionAlignment = HorizontalAlignment.Center;
            MyRichTextBoxEx.AppendText(header);

            MyRichTextBoxEx.SelectionAlignment = HorizontalAlignment.Left;

            //Mittigen Strich erzeugen
            Byte[] By = { 33 };
            By[0] = 196;
            string underline = Store.ASCII8ToString(By);
            string underlineShort = Store.ASCII8ToString(By);
            for (int i = 0; i < 40; i++)
            {
                underline += Store.ASCII8ToString(By);
            }

            //Tabellenüberschrift
            int[] tabs1 = { 20, 80, 200 };
            MyRichTextBoxEx.SelectionTabs = tabs1;

            MyRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            MyRichTextBoxEx.SelectedText = underline + "\n";
            MyRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            MyRichTextBoxEx.SelectedText = "Jahr" + "\t" + "Monat" + "\t" + "Umsatz" + "\t" + "Auszahlung" + "\n";
            MyRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            MyRichTextBoxEx.SelectedText = underline + "\n";

            int[] tabs2 = { 15, 90, 180, 200 };
            MyRichTextBoxEx.SelectionTabs = tabs2;
            foreach (var item in CashVolumeList)
            {
                string myYear = item.Year;
                string myMonth = item.Monthname;
                string mySalesSum = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", item.SalesSum);
                mySalesSum= Store.SetStringLengthToTen(mySalesSum);
                string myCostSum = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", item.CostSum);
                myCostSum  = Store.SetStringLengthToTen(myCostSum);

                //Prices als String mit Leerzeichen auf eine Länge von 9 bringen
                string myOutString = myYear + "\t" + myMonth + "\t" + mySalesSum + "\t" + myCostSum + "\t" + "" + "\n";
                MyRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
                MyRichTextBoxEx.SelectedText = myOutString;
            }
        }


        private void PrintBtn_Click(object sender, EventArgs e)
        {
            //Print Document
            //zur Abfrage Drucken Speichern Abbrechen
            //MessageBox.Show("not implemented yet");

            PrintRichTextContents myPrint = new PrintRichTextContents();
            myPrint.MyPrintDialog = printDialog1;
            myPrint.MyRichTextBoxEx = MyRichTextBoxEx;
            myPrint.PageNumberEnabled = true;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                myPrint.PrintRTContents();
            }
            Close();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
