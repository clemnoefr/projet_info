using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Data.DAO
{
    public class Suppliers
    {
        [Key] public int id_supplier { get; set; }
        public string name { get; set; }
        public int phone { get; set; }
        public string supplier_code { get; set; }
        public int id_address { get; set; }
        [ForeignKey("id_address")]
        public DateTime creation_date { get; set; }
        public DateTime update_date { get; set; }
    }
}
