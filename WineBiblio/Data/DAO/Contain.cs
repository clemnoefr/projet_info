using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Data.DAO
{
    public class Contain
    {
        public int id_contain { get; set; }
        public int id_order { get; set; }
        [ForeignKey("id_order")]
        public int id_product { get; set; }
        [ForeignKey("id_product")]
        public int quantity_sell { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime update_date { get; set; }
    }
}
