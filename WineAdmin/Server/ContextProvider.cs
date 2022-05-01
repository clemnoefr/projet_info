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

        public static AddressService AddressService { get; private set; }
        public static CategoryService CategoryService { get; private set; }
        public static CustomerService CustomerService { get; private set; }
        public static EmployeeService EmployeeService { get; private set; }
        public static InvoiceService InvoiceService { get; private set; }
        public static OrderService OrderService { get; private set; }
        public static ProductService ProductService { get; private set; }
        public static SupplierService SupplierService { get; private set; }

        public static void Initialize()
        {
            Console.WriteLine("[*] Connecting to database...");
            DbContextOptionsBuilder<MyDataContext> builder = new DbContextOptionsBuilder<MyDataContext>();
            builder.UseSqlServer(@"Data Source=tcp:wine-server.database.windows.net,1433;Initial Catalog=Wine_Club_BDD;User Id=WineClub@wine-server;Password=CubesTECALM33");
            DataContext = new MyDataContext(builder.Options);
            Console.WriteLine("[+] Connected to database !");
            AddressService = new AddressService(DataContext);
            CategoryService = new CategoryService(DataContext);
            CustomerService = new CustomerService(DataContext);
            EmployeeService = new EmployeeService(DataContext);
            InvoiceService = new InvoiceService(DataContext);
            OrderService = new OrderService(DataContext);
            ProductService = new ProductService(DataContext);
            SupplierService = new SupplierService(DataContext);
        }
    }
}