using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Business
{
    public class Families
    {
        public int id_family { get; set; }
        public string family_name { get; set; }
        public List<Orders> orderList { get; set; }
    }
}
