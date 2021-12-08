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
        public float price_ht { get; set; } 
        public Address Address { get; set; }
        public HistoryOrder HistoryOrder { get; set; }
        public Invoice Invoice { get; set; }

    }
}
