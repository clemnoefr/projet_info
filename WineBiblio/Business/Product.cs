using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Business
{
    public class Product
    {
        public int id_product { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string reference { get; set; }
        public int bottled_year { get; set; }
        public string picture { get; set; }
        public string origine { get; set; }
        public int quantity_stock { get; set; }
        public int id_address_supplier { get; set; }
        public int id_category { get; set; }

    }
}
