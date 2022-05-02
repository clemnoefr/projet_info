using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Data.DAO
{
    public class Categories
    {
        [Key] public int id_category { get; set; }
        public string category_name { get; set;}
        public DateTime creation_date { get; set; }
        public DateTime update_date { get; set; }
    }
}
