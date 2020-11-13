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
    public partial class CashCloseSoldListWindow : Form
    {
        public string[] MyCashCloseSoldList { get; set; }

        public CashCloseSoldListWindow()
        {
            InitializeComponent();
        }


        private void Setup()
        {
            SoldItemsListBox.Items.AddRange(MyCashCloseSoldList);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CashCloseSoldListWindow_Shown(object sender, EventArgs e)
        {
            Setup();
        }
    }
}
