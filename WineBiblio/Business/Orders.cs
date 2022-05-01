using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Business
{
    public class Orders
    {
        public int id_order { get; set; }
        public int status { get; set; }
        public double total_ht { get; set; }
        public double total_ttc { get; set; }
        public double TVA { get; set;}
        public int id_customer { get; set; }
    }
}
