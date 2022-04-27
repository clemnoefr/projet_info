using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Data.DAO
{
    public class Product
    {
        [Key] public int id_product { get; set; }
        public string product_name { get; set; }
        public string description { get; set; }
        public double price_ht { get; set; }
        public string reference { get; set; }
        public int bottled_year { get; set; }
        public string picture { get; set; }
        public string origine { get; set; }
        public int stock { get; set; }
        public double supplier_price { get; set; }
        public double price_carton { get; set; }
        public int id_supplier { get; set; }
        [ForeignKey("id_supplier")]
        public int id_category { get; set; }
        [ForeignKey("id_category")]
        public int id_family { get; set; }
        [ForeignKey("id_family")]
        public DateTime creation_date { get; set; }
        public DateTime update_date { get; set; }
    }
}
