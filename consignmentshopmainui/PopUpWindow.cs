using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConsignmentShopMainUI
{
    public partial class PopUpWindow : Form
    {
        public PopUpWindow()
        {
            InitializeComponent();

            RichTextBox1.Text = "\n\n\n\n\t\tKeine Artikel für diesen Kunden";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
