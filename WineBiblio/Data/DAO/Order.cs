﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Data.DAO
{
    public class Order
    {
        [Key] public int id_order { get; set; }
        public float price_ht { get; set; }
        public int id_address { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime update_date { get; set; }
    }
}
