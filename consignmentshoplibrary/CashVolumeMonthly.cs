using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class CashVolumeMonthly
    {
        public string Year { get; set; }
        public string Monthname { get; set; }
        public decimal SalesSum { get; set; }
        public decimal CostSum { get; set; }
        public decimal ProvisionSum { get; set; }
    }
}
