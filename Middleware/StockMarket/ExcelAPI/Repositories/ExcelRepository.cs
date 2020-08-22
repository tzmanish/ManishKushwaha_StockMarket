using System.Collections.Generic;
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
    }
}
