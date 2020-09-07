using System;
using System.Collections.Generic;
using System.IO;
using ExcelAPI.Models;

namespace ExcelAPI.Services {
    public interface IExcelService {
        public List<StockPrice> ImportSpreadsheet(string filePath, string worksheetName);
        FileStream ExportData(List<string> companyCodes, DateTime startDate, DateTime endDate);
    }
}
