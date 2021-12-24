using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Business
{
    public class Invoice
    {
        public int id_invoice { get; set; }
        public float TVA { get; set; }
        public float price_TTC { get; set; }
        public int id_order { get; set; }
        public int id_address { get; set; }
    }
}
