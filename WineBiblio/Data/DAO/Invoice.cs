using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Data.DAO
{
    public class Invoice
    {
        [Key] public int id_invoice { get; set; }
        public double TVA { get; set; }
        public double price_TTC { get; set; }
        public int id_order { get; set; }
        public int id_address { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime update_date { get; set; }
    }
}
