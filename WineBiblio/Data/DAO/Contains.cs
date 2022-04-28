using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Data.DAO
{
    public class Contains
    {
        [Key] public int id_contains { get; set; }
        public int id_order { get; set; }
        [ForeignKey("id_order")]
        public int id_product { get; set; }
        [ForeignKey("id_product")]
        public int quantity { get; set; }

    }
}
