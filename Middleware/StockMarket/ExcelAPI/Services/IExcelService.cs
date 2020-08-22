using System.Collections.Generic;
using ExcelAPI.Models;

namespace ExcelAPI.Services {
    public interface IExcelService {
        public List<StockPrice> ImportSpreadsheet(string filePath, string worksheetName);
    }
}
