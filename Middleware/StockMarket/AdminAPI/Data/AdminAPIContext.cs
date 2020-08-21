﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminAPI.Data {
    public class AdminAPIContext:DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<StockPrice> StockPrices { get; set; }
        public DbSet<IPODetails> IPODetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StockMarketDB;Integrated Security=True");
        }
    }
}