using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Business
{
    public class Address_Supplier
    {
        public int id_address_supplier { get; set; }
        public int address_type { get; set; }
        public string address { get; set; }
        public int id_supplier { get; set; }
        public List<Product> ProductList { get; set; }

    }
}
