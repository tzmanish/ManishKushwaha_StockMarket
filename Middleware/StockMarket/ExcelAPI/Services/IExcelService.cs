using System.Collections.Generic;
using ExcelAPI.Models;

namespace ExcelAPI.Services {
    public interface IExcelService {
        public List<StockPrice> ImportSpreadsheet(string filePath, string worksheetName);
        public void ExportData(string filePath, string worksheetName, List<StockPrice> stockPrices);
    }
}
