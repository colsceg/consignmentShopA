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
    public partial class DocumentRefundList : Form
    {
        public List<Item> RefundItemsList { get; set; }
        public Vendor VendorInfo { get; set; }
        private Store Store = new Store();

        public DocumentRefundList()
        {
            InitializeComponent();
        }



        private void CloseBtn_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void PrintBtn_MouseClick(object sender, MouseEventArgs e)
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

        private void CreateDocument()
        {
            MyRichTextBoxEx.Font = new Font("Arial", 12f, FontStyle.Regular);
            MyRichTextBoxEx.BackColor = System.Drawing.Color.White;
            string header = "";
            //Header setzen

            header = $"Liste der aussortierten Stücke zur Rückgabe für {VendorInfo.FullName} \n";
            MyRichTextBoxEx.Font = new Font("Arial", 14f, FontStyle.Bold);
            MyRichTextBoxEx.SelectionAlignment = HorizontalAlignment.Center;
            MyRichTextBoxEx.AppendText(header);

            MyRichTextBoxEx.SelectionAlignment = HorizontalAlignment.Left;

            //Mittigen Strich erzeugen
            Byte[] By = { 33 };
            By[0] = 196;
            string underline = Store.ASCII8ToString(By);
            string underlineShort = Store.ASCII8ToString(By);
            for (int i = 0; i < 80; i++)
            {
                underline += Store.ASCII8ToString(By);
            }

            //Tabellenüberschrift
            int[] tabs1 = { 150, 350, 500 };
            MyRichTextBoxEx.SelectionTabs = tabs1;

            MyRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            MyRichTextBoxEx.SelectedText = underline + "\n";
            MyRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            MyRichTextBoxEx.SelectedText = $" Beschreibung \t Annahme \t Aussortiert \n";
            MyRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Bold);
            MyRichTextBoxEx.SelectedText = underline + "\n";

            int[] tabs2 = { 150, 190, 200 };
            MyRichTextBoxEx.SelectionTabs = tabs1;
            foreach (var item in RefundItemsList)
            {
                string myName = VendorInfo.FullName;
                string myDescription = item.ItemDescription;
                string myInDate = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", item.BeginDate);
                string myOutDate = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", item.DeleteDate);

                //Prices als String mit Leerzeichen auf eine Länge von 9 bringen
                string myOutString = $"  {myDescription}  \t {myInDate}  \t   {myOutDate} \n";
                MyRichTextBoxEx.SelectionFont = new Font("Arial", 10f, FontStyle.Regular);
                MyRichTextBoxEx.SelectedText = myOutString;
            }
        }

        private void DocumentRefundList_Load(object sender, EventArgs e)
        {
            CreateDocument();
        }
    }
}
