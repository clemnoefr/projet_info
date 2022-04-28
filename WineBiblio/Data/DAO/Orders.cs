using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Data.DAO
{
    public class Orders
    {
        [Key] public int id_order { get; set; }
        public int status { get; set; }
        public double total_ht { get; set; }
        public double total_ttc { get; set; }
        public double TVA { get; set; }
        public int id_address { get; set; }
        [ForeignKey("id_address")]
        public DateTime creation_date { get; set; }
        public DateTime update_date { get; set; }
    }
}
