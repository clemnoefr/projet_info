using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Business
{
    public class Order
    {
        public int id_order { get; set; }
        public double price_ht { get; set; } 
        public int id_address { get; set; }
    }
}
