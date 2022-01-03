using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Business
{
    public class HistoryOrder
    {
        public int id_history_order { get; set; }
        public string order_file { get; set; }
        public int id_order { get; set; }
    }
}
