using System;
using System.Collections.Generic;
using System.Linq;
using ExcelAPI.Data;
using ExcelAPI.Models;

namespace ExcelAPI.Repositories {
    public class ExcelRepository:IExcelRepositiory {
        private ExcelAPIContext context;
        public ExcelRepository(ExcelAPIContext context) {
            this.context = context;
        }

        public void AddStockPrices(List<StockPrice> stockPrices) {
            context.StockPrices.AddRange(stockPrices);
            context.SaveChanges();
        }

        public List<StockPrice> GetStockPrices(string companyCode, DateTime startDate, DateTime endDate) {
            return context.StockPrices
                .Where(sp =>
                    sp.CompanyCode == companyCode &&
                    sp.Date >= startDate &&
                    sp.Date <= endDate
                ).OrderBy(sp => sp.Date).ToList();
        }

        public bool isCompany(string companyCode) {
            return context.Companies.Where(c => c.CompanyCode == companyCode).Any();
        }
    }
}
