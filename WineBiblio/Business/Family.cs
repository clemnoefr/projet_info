using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Business
{
    public class Family
    {
        public int id_family { get; set; }
        public string family_name { get; set; }
        public List<Order> orderList { get; set; }
    }
}
