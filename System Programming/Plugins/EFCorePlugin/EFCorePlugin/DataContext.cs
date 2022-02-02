using BaseProject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePlugin
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DataContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=STHQ0126-01;Database=UserDb;User Id=admin;Password=admin;";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
