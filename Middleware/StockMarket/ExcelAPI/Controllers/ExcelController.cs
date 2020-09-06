using System;
using System.Collections.Generic;
using System.IO;
using ExcelAPI.Models;
using ExcelAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExcelAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExcelController : ControllerBase {
        private IExcelService service;
        public ExcelController(IExcelService service) {
            this.service = service;
        }

        [HttpPost]
        [Authorize(Roles ="admin")]
        [Route("Upload")]
        public IActionResult UploadExcel() {
            try {
                var postedFile = Request.Form.Files["ExcelFile"];
                string worksheet = Request.Form["Worksheet"][0];

                string filePath = Path.Combine("Uploads", postedFile.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                    postedFile.CopyTo(fileStream);

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
