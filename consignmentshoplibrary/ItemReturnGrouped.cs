using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class ItemReturnGrouped
    {
        public string PosNumber { get; set; }
        public string ItemDescription { get; set; }
        public string SalesPrice { get; set; }
        public int SoldItemsCount { get; set; }
        public int TotalItemsCount { get; set; }
    }
}
