﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Data.DAO
{
    public class Customers
    {
        [Key] public int id_customer { get; set; }
        public string mail { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string password { get; set; }
        public int phone { get; set; }
        public string address { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime update_date { get; set; }
        public string login_cookie { get; set; }
    }
}
