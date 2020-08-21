using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AccountAPI.Models;

namespace AccountAPI.Data
{
    public class AccountAPIContext : DbContext
    {
        public AccountAPIContext (DbContextOptions<AccountAPIContext> options): base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<StockPrice> StockPrice { get; set; }
        public DbSet<IPODetails> IPODetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StockMarketDB;Integrated Security=True");
        }
    }
}
