using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Data.DAO
{
    public class AddressSupplier
    {
        [Key] public int id_address_supplier { get; set; }
        public int address_type { get; set; }
        public string address { get; set; }
        public int id_supplier { get; set; }
        [ForeignKey("id_supplier")]
        public DateTime creation_date { get; set; }
        public DateTime update_date { get; set; }
    }
}
