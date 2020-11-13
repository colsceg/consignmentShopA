using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class Make : IComparable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Premium { get; set; }

        public int CompareTo(Object o)
        {
            Make e = o as Make;
            if (e == null)
                throw new ArgumentException("o is not an Make object.");

            return Name.CompareTo(e.Name);
        }
    }
}
