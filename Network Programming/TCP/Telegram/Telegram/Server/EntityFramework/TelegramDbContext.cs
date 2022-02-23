using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.EntityFramework
{
    public class TelegramDbContext : DbContext
    {
        private const string ConnectionString = @"Server=STHQ0126-01;Database=Telegram;User Id=admin;Password=admin;";

        public DbSet<Message> Messages { get; set; }

        // before connect
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
