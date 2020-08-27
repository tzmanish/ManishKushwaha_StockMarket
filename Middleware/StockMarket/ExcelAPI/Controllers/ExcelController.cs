using System;
using System.Collections.Generic;
using ExcelAPI.Models;
using ExcelAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace ExcelAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExcelController : ControllerBase {
        private IExcelService service;
        public ExcelController(IExcelService service) {
            this.service = service;
        }

        [HttpGet]
        [Authorize(Roles ="admin")]
        [Route("Upload/{worksheet}/{*filePath}")]
        public IActionResult UploadExcel(string worksheet, string filePath) {
            try {
                return Ok(service.ImportSpreadsheet(filePath, worksheet));
            } catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("Update/{worksheet}/{*filePath}")]
        public IActionResult ExportExcel(string worksheet, string filePath, List<StockPrice> stockPrices) {
            try {
                if (stockPrices.Count>0) {
                    service.ExportData(filePath, worksheet, stockPrices);
                    return Ok(filePath);
                } else 
                    return BadRequest("Please provide some data to write.");
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
