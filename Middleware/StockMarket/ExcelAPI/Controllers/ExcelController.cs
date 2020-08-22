using System;
using ExcelAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExcelAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase {
        private IExcelService service;
        public ExcelController(IExcelService service) {
            this.service = service;
        }

        [HttpGet]
        [Route("Upload/{worksheet}/{*filePath}")]
        public IActionResult UploadExcel(string worksheet, string filePath) {
            try {
                return Ok(service.ImportSpreadsheet(filePath, worksheet));
            } catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
