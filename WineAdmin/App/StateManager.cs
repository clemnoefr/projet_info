using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;

namespace WineAdmin.App
{
    internal class StateManager
    {
        public static bool IsLoggined = false;
        public static Employee LogginedEmployee = null;
    }
}
