using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Business
{
    public class Address
    {
        public int id_address { get; set; }
        public int address_type { get; set; }
        public string address { get; set; }
        public int id_customer { get; set; }
        public List<Order> orderList { get; set; }
        public List<Invoice> invoiceList { get; set; }
    }
}
