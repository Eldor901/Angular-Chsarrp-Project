using Microsoft.EntityFrameworkCore;
using TempWeb.Models;

namespace TempWeb.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ProductCart> ProductCarts { get; set;}
        public DbSet<Cuisine> Cuisines { get; set; }

        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) { }
    }
}