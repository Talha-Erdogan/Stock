using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext():base("name=StockConnectionString") 
        {

        }
        public DbSet<Authority> Authority { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<User> User { get; set; }

    }
}
