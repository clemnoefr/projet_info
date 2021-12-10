using WineBiblio.Data.DAO;
using Microsoft.EntityFrameworkCore;

namespace WineBiblio.Core.Data
{
    public class MyDataContext : DbContext
    {
        public MyDataContext(DbContextOptions<MyDataContext> options) : base(options)
        {
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<AddressSupplier> AddressSupplier { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Contain> Contain { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<HistoryInvoice> HistoryInvoice { get; set; }
        public DbSet<HistoryOrder> HistoryOrder { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Supplier> Supplier { get; set; }

    }
}
