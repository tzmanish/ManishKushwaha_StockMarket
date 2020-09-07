using System;
using System.Collections.Generic;
using ExcelAPI.Models;

namespace ExcelAPI.Repositories {
    public interface IExcelRepositiory {
        public void AddStockPrices(List<StockPrice> stockPrices);
        public bool isCompany(string id);
        List<StockPrice> GetStockPrices(string companyCode, DateTime startDate, DateTime endDate);
    }
}
