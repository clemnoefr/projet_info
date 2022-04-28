using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Data.DAO
{
    public class Families
    {
        [Key] public int id_family { get; set; }
        public string family_name { get; set; }

    }
}
