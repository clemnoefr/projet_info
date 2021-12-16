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
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        /*     TEST CONSOLE CO BDD RECUPERATION DONNEES
         *     
         *     public static void Main(string[] args)
                {
                    try
                    {
                        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                           builder.DataSource = "wine-server.database.windows.net";
                           builder.UserID = "WineClub";
                           builder.Password = "CubesTECALM33";
                           builder.InitialCatalog = "Wine_Club_BDD";

                        *//* builder.ConnectionString = "Server=tcp:wine-server.database.windows.net,1433;Initial Catalog=Wine_Club_BDD;Persist Security Info=False;User ID=WineClub;Password={CubesTECALM33};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";*//*

                        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                        {
                            Console.WriteLine("\nQuery data example:");
                            Console.WriteLine("=========================================\n");

                            String sql = "SELECT * FROM category;";

                            using (SqlCommand command = new SqlCommand(sql, connection))
                            {
                                connection.Open();
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        Console.WriteLine("{0} {1}", reader.GetValue(0), reader.GetString(1));
                                    }
                                }
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    Console.ReadLine();

            }*/
    }
}
