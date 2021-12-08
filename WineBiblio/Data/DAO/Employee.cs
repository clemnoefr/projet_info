﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineBiblio.Data.DAO
{
    public class Employee
    {
        public int id_employee { get; set; }
        public int rank { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string password { get; set; }
        public int phone { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime update_date { get; set; }
    }
}
