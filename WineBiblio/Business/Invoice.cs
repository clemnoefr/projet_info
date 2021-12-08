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
        
        public Order Order { get; set; }
        public HistoryInvoice HistoryInvoice { get; set; }
        public Address Address { get; set; }
    }
}
