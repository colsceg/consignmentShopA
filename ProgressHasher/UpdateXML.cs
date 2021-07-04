using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;

namespace ProgressHasher
{
    public class UpdateXML
    {
        public UpdateXML(string location, string appID, Version version)
        {

            string url = "", filename = "", md5 = "", description = "", launchArgs = "";
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

                // Write changes to file
                xmlNode["md5"].InnerText = md5;
                xmlNode["description"].InnerText =description;
                xmlNode["filename"].InnerText = filename;
                xmlNode["version"].InnerText =  version.ToString();

                //return new SharpUpdateXml(version, new Uri(url), filename, md5, description, launchArgs);

            }
            catch (Exception ee)
            {
                Debug.Fail(ee.Message);
            }
        }
    }
}
