using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.Xml;
using ExcelAPI.Models;
using ExcelAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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

                string filePath = Path.Combine("ExcelFiles\\Uploads", postedFile.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                    postedFile.CopyTo(fileStream);

                return Ok(service.ImportSpreadsheet(filePath, worksheet));
            } catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("Sample")]
        public IActionResult DownloadSample() {
            string filepath = Path.Combine("ExcelFiles\\Downloads", "Sample.xlsx");
            var file = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            return Ok(file);
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        [Route("Download")]
        public IActionResult DownloadExcel(TempObj tempObj) {
            try {
                var file = service.ExportData(
                    tempObj.companyCodes, 
                    tempObj.startDate, 
                    tempObj.endDate
                );
                return Ok(file);
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        public class TempObj {
            public List<string> companyCodes { get; set; }
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }
        }
    }
}
