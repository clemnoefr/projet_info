using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Business
{
    public class Contain
    {
        public int id_contain { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int quantity_sell { get; set; }

    }
}
