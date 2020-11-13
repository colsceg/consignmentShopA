using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConsignmentShopMainUI
{
    public partial class CashVolumeMonthlyWindow : Form
    {
        private Store Store = new Store();

        List<CashVolumeMonthly> CashVolumeList = new List<CashVolumeMonthly>();
        List<CashVolumeMonthly> itemsSoldList = new List<CashVolumeMonthly>();
        DataAccessItems DBItems = new DataAccessItems();

        public CashVolumeMonthlyWindow()
        {
            InitializeComponent();
        }


        private void Setup()
        {
            for (int i = 0; i < 4; i++)
                VolumeDataGridView.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;


            //Alle verkauften Artikel in Liste

            itemsSoldList = DBItems.GetMonthlySums();
            //Gruppieren nach Jahr und Monat summe soldPrice und Summe costPrice bilden
            VolumeDataGridView.DataSource = itemsSoldList;
        }

        private void CashVolumeMonthlyWindow_Shown(object sender, EventArgs e)
        {
            Setup();
        }

        private void DiagButton_Click(object sender, EventArgs e)
        {
            //Fenster mit Diagramm öffnen
            CashGraphicWindowMonthly CashGraphicWin = new CashGraphicWindowMonthly();
            CashGraphicWin.TotalCashList = itemsSoldList;
            CashGraphicWin.Show();

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            ExportBtn.UseWaitCursor = true;
            //Stopwatch watch = new Stopwatch();
            //MessageBox.Show("Not implemented yet");
            //Build the CSV file data as a Comma separated string.
            StringBuilder csv = new StringBuilder();
            StringBuilder myCsvLine = new StringBuilder();
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            //Add the Header row for CSV file.
            foreach (DataGridViewColumn column in VolumeDataGridView.Columns)
                csv.Append(column.HeaderText + ';');

            //Add new line.
            csv.Append("\r\n");
            char[] myStr = { ' ' };
            //Adding the Rows
            //watch.Start();
            foreach (DataGridViewRow row in VolumeDataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    //Add the Data rows.

                    string myCell = (cell.Value != null) ? cell.Value.ToString().Replace("€", "") + ';' : "" + ';';
                    csv.Append(myCell);
                }
                //Add new line.               
                csv.Append("\r\n");
            }
            //watch.Stop();
            //MessageBox.Show("verbrauchte Zeit{0}", watch.ElapsedMilliseconds.ToString());
            saveFile1.DefaultExt = "*.csv";
            saveFile1.Filter = "CSV Files|*.csv";
            ExportBtn.UseWaitCursor = false;
            //Exporting to CSV.
            string folderPath = Store.GetPersonalFolder() + "\\2ndHandWare";

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                File.WriteAllText(saveFile1.FileName, csv.ToString());
            }

        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            DocumentMonthlyVolumes SalesVolumeWin = new DocumentMonthlyVolumes();
            SalesVolumeWin.CashVolumeList = itemsSoldList;
            SalesVolumeWin.Show();
        }
    }
}
