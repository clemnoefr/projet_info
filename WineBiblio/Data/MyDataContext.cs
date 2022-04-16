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
        public DbSet<Address> Address { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Contains> Contain { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Type> Type { get; set; }

    }
}
