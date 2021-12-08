using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Data.DAO
{
    public class Address
    {
        public int id_address { get; set; }
        public int address_type { get; set; }
        public string address { get; set; }
        public int id_customer { get; set; }
        [ForeignKey("id_customer")]

        public DateTime creation_date { get; set; }
        public DateTime update_date { get; set; }
    }
}
