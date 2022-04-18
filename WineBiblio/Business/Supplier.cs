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
        public string name { get; set; }
        public int phone { get; set; }
        public string supplier_code { get; set; }
        public int id_address { get; set; }
    }
}
