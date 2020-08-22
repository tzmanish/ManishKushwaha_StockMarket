using System;
using System.Collections.Generic;
using System.IO;
using ExcelAPI.Models;
using ExcelAPI.Repositories;
using OfficeOpenXml;

namespace ExcelAPI.Services {
    public class ExcelService:IExcelService {
        IExcelRepositiory repo;
        public ExcelService(IExcelRepositiory repo) {
            this.repo = repo;
        }

        public List<StockPrice> ImportSpreadsheet(string filePath, string worksheetName) {
            FileInfo file = new FileInfo(filePath);
            List<StockPrice> stockPrices = new List<StockPrice>();

            using (ExcelPackage package = new ExcelPackage(file)) {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[worksheetName];
                int totalRows = worksheet.Dimension.Rows;

                for (int i = 2; i <= totalRows; i++) {
                    stockPrices.Add(new StockPrice {
                        CompanyCode = worksheet.Cells[i, 1].Value.ToString().Trim(),
                        StockExchange = worksheet.Cells[i, 2].Value.ToString().Trim(),
                        CurrentPrice = double.Parse(worksheet.Cells[i, 3].Value.ToString().Trim()),
                        Date = DateTime.Parse(worksheet.Cells[i, 4].Value.ToString().Trim()),
                        Time = worksheet.Cells[i, 5].Value.ToString(),
                    });
                }
            }

            repo.AddStockPrices(stockPrices);

            return stockPrices;
        }
    }
}
