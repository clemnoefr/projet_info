using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Data.DAO
{
    public class Addresses
    {
        [Key] public int id_address { get; set; }
        public string address { get; set; }
        public int id_customer { get; set; }
        [ForeignKey("id_customer")]
        public int id_type { get; set; }
        [ForeignKey("id_type")]
        public int id_supplier { get; set; }
        [ForeignKey("id_supplier")]
        public DateTime creation_date { get; set; }
        public DateTime update_date { get; set; }
    }
}
