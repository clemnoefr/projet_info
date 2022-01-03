using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using System.Text;

namespace WineAPI
{
    // application startup code

    public class Program
    {

        public static void Main(string[] args)
        {
            // for create and configurate the generic host 
            // without running the appli because using Entity Framework Core
            CreateHostBuilder(args).Build().Run();
           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        /* Load the application configuration from:
        - appsettings.json.
        - appsettings. {Environment} .json
        */
            Host.CreateDefaultBuilder(args) 
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
