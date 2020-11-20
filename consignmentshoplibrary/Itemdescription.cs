using System;

namespace ConsignmentShopLibrary
{
    /// <summery>
    /// Itemdescription fr the Itemdescription Combobox items
    /// </summery
    public class Itemdescription : IComparable
    { 
        public int ID { get; set; }
        public string Name { get; set; }

        public int CompareTo(Object o)
        {
            Itemdescription e = o as Itemdescription;
            if (e == null)
                throw new ArgumentException("o is not an Itemdescription object.");

            return Name.CompareTo(e.Name);
        }       
    }
}



