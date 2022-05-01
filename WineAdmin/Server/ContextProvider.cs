using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Core.Data;
using WineBiblio.Service;

namespace WineAdmin.Server
{
    internal class ContextProvider
    {
        public static MyDataContext DataContext { get; private set; }


        public static void Initialize()
        {
            Console.WriteLine("[*] Connecting to database...");
            DbContextOptionsBuilder<MyDataContext> builder = new DbContextOptionsBuilder<MyDataContext>();
            builder.UseSqlServer(@"Data Source=tcp:wine-server.database.windows.net,1433;Initial Catalog=Wine_Club_BDD;User Id=WineClub@wine-server;Password=CubesTECALM33");
            DataContext = new MyDataContext(builder.Options);
            Console.WriteLine("[+] Connected to database !");

        }
    }
}