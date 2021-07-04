using SharpUpdate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProgressHasher
{
    public partial class Form1 : Form, ISharpUpdatable
    {
        #region Public Properties SharpUpdate (Zuweisung über ISharpUpateable)

        private SharpUpdater updater;

        public string ApplicationName => "ConsignmentShopApp";

        public string ApplicationID => "ConsignmentShopApp";

        public Assembly ApplicationAssembly => Assembly.GetExecutingAssembly();

        public Icon ApplicationIcon => this.Icon;

        public Uri UpdateXmlLocation => new Uri("http://www.2ndhandsoft.de/Update/update.xml");

        public Form Context => this;

        Hasher hasher;
        string location = "..//..//..//installation//update.xml";
        string filepath = "..//..//..//installation//2ndHandWareInstallation.exe";

        #endregion

        public Form1()
        {
            InitializeComponent();
            hasher = new Hasher();

        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string version = ApplicationAssembly.GetName().Version.ToString();
            // Write changes to file
            string filePath = e.Argument.ToString() + version;

            e.Result = hasher.HashFile(filePath, HashType.MD5);

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString());
            updateXML(filepath, ApplicationID, e.Result.ToString(), textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(filepath);
        }

        private void updateXML(string location, string appID, string md5, string description)
        {
            try
            {
                //Load the document
                XmlDocument doc = new XmlDocument();
                doc.Load(location);

                //Gets the appId's node with the update info
                // This alows you to store all programs update nodes in one file
                XmlNode xmlNode = doc.DocumentElement.SelectSingleNode($"//update[@appId='{appID}']");

                //If the node does not exist, there is no update
                if (xmlNode == null)
                    MessageBox.Show("there is no update");
                string version = ApplicationAssembly.GetName().Version.ToString();
                // Write changes to file
                xmlNode["md5"].InnerText = md5; // hash of installer file on server
                xmlNode["description"].InnerText = description; // text for new features
                xmlNode["filename"].InnerText = "2ndHandWareInstaller.exe"; // name for the downloaded installer
                xmlNode["version"].InnerText = version.ToString(); // new version number

                //return new SharpUpdateXml(version, new Uri(url), filename, md5, description, launchArgs);

            }
            catch (Exception ee)
            {
                Debug.Fail(ee.Message);
            }
        }
    }
}
