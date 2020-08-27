using ExcelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcelAPI.Data {
    public class ExcelAPIContext:DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; } 
        public DbSet<IPODetails> IPODetails { get; set; } 
        public DbSet<StockPrice> StockPrices { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StockMarketDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique(true);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique(true);
        }
    }
}
