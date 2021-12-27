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
        public double TVA { get; set; }
        public double price_TTC { get; set; }
        public int id_order { get; set; }
        public int id_address { get; set; }
    }
}
