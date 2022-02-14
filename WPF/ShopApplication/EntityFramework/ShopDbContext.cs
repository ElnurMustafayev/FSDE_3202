using Microsoft.EntityFrameworkCore;
using ShopApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.EntityFramework
{
    public class ShopDbContext : DbContext
    {
        private const string ConnectionString = @"Server=STHQ0126-01;Database=ShopWpf;User Id=admin;Password=admin;";

        public DbSet<Product> Products { get; set; }

        // before connect
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
