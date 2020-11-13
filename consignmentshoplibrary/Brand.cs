using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class Brand : IComparable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Premium { get; set; }

        public int CompareTo(Object o)
        {
            Brand e = o as Brand;
            if (e == null)
                throw new ArgumentException("o is not an Brand object.");

            return Name.CompareTo(e.Name);
        }
    }
}
