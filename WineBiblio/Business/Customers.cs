using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Business
{
    public class Customers
    {
        public int id_customer { get; set; }
        public string mail { get; set; }
        public string address { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string password { get; set; }
        public int phone { get; set; }

    }
}
