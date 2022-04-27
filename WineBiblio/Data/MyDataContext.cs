using WineBiblio.Data.DAO;
using Microsoft.EntityFrameworkCore;

namespace WineBiblio.Core.Data
{
    /*
        Database context coordinates the functionality of the Entity Framework for our data model
        Initializes a new instance of the DataContext class by referencing the connection used by the .NET Framework
        Source of all entities mapped to our database connection
    */ 
    public class MyDataContext : DbContext
    {
        public MyDataContext(DbContextOptions<MyDataContext> options) : base(options)
        {
        }

        /*
         DbSet objects are created from a DbContext using the <DbContext.Set.> method
        For each entity in the model, we create a class that derives from DbContext
        and contains the DbSet <TEntity> properties. 

        Note that here, our DbSet <TEntity> properties have a public setter 
        = so  they are automatically initialized when the instance of the derived context is created.
        */
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Contains> Contains { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<Families> Families { get; set; }

    }
}
