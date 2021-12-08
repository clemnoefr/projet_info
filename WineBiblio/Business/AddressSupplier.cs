using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Business
{
    public class AddressSupplier
    {
        public int id_address_supplier { get; set; }
        public int address_type { get; set; }
        public string address { get; set; }
        public Supplier Supplier { get; set; }

    }
}
