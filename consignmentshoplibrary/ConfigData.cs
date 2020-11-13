using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class ConfigData
    {
        public string LastContractID { get; set; }
        public string LastItemNumber { get; set; }
        public string LastInvoiceID { get; set; }
        public string BackupDirectory { get; set; }
        public double KassenBestand { get; set; }
        public int Period { get; set; }
        public int Margin { get; set; }
    }
}
