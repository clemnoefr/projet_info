using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Business
{
    public class Invoices
    {
        public int id_invoice { get; set; }
        public int reference { get; set; }
        public int status { get; set; }
        public int id_order { get; set; }
    }
}
