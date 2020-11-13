using ConsignmentShopLibrary;
using System;
using System.Windows.Forms;

namespace ConsignmentShopMainUI
{
    public partial class InfoWindow : Form
    {
        public string SerNo { get; set; }


        public InfoWindow()
        {
            InitializeComponent();
        }

        private void Setup()
        {
            VersionLabel.Text = "VersNr " + Store.AddVersionNumber() + " .NET 4.5";
            EmailLabel.Text = "EMail: info@chairfit.de";
            SerNoLabel.Text = "SerNo: " + SerNo;
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InfoWindow_Shown(object sender, EventArgs e)
        {
            Setup();
        }
    }
}
