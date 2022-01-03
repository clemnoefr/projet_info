using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Business
{
    public class Supplier
    {
        public int id_supplier { get; set; }
        public string Name { get; set; }
        public List<AddressSupplier> AddressSuppliers { get; set; }
    }
}
