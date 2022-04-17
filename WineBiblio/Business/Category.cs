using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Business
{
    public class Category
    {
        public int id_category { get; set; }
        public string category_name { get; set; }
        public List<Product> ProductList { get; set; }
    }
}
