﻿using _.Models;
using Microsoft.EntityFrameworkCore;
using TempWeb.Models;

 
namespace TempWeb.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Cart> Carts { get; set;}
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<IngridientCategory> IngridientCategories  { get; set; }


        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) { }
    }
}