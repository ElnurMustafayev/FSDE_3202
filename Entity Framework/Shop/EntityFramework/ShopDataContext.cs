using Microsoft.EntityFrameworkCore;
using Shop.EntityFramework.Configurations;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.EntityFramework
{
    public class ShopDataContext : DbContext
    {
        private const string ConnectionString = @"Server=STHQ0126-01;Database=Shop;User Id=admin;Password=admin;";

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        // before connect
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
