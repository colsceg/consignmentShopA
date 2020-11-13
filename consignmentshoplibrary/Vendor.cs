using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class Vendor :IComparable
    {
        public string AccountID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Annex1 { get; set; }
        public string Annex2 { get; set; }
        public string Street { get; set; }
        public string Plz { get; set; }
        public string Town { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string EmailAccount { get; set; }
        public int Margin { get; set; }
        public int Period { get; set; }

        public string FullInfo => $"{ LastName } ; { FirstName } ; { AccountID }";
        public string FullName => $"{ LastName } { FirstName }";


        public int CompareTo(Object o)
        {
            Vendor e = o as Vendor;
            if (e == null)
                throw new ArgumentException("o is not an Vendor object.");

            return FullName.CompareTo(e.FullName);
        }

    }
}
