using System;
using System.Collections.Generic;
using System.Linq;
using AdminAPI.Models;
using AdminAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class AdminController : ControllerBase{
        private IAdminService service;
        public AdminController(IAdminService service) {
            this.service = service;
        }

        [HttpGet]
        [Route("Companies/All")]
        public IActionResult GetAllCompanies() {
            try {
                List<Company> companies = service.GetCompanies();
                if (companies.Any())
                    return Ok(companies);
                return NotFound("No companies in record.");
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("Companies/{id}")]
        public IActionResult GetCompany(string id) {
            try {
                Company company = service.GetCompany(id);
                if (company != null)
                    return Ok(company);
                return NotFound(id + " not found.");
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("Companies/Update")]
        public IActionResult UpdateCompany(Company company){
            try {
                return Ok(service.PutCompany(company));
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("Companies/Add")]
        public IActionResult AddCompany(Company company)
        {
            try {
                return Ok(service.AddCompany(company));
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/admin/Companies/AIR
        [HttpDelete]
        [Route("Companies/{id}")]
        public IActionResult DeleteCompany(string id)
        {
            try {
                return Ok(service.DeleteCompany(id));
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("IPO/Add")]
        public IActionResult AddIPO(IPODetails iPODetails) {
            try {
                return Ok(service.AddIPO(iPODetails));
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("IPO/Update")]
        public IActionResult UpdateIPO(IPODetails iPODetails) {
            try {
                return Ok(service.UpdateIPO(iPODetails));
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("StockPrices/Missing/{companyCode}/{startDate}/{endDate}")]
        public IActionResult GetMissingStockPriceDates(string companyCode, DateTime startDate, DateTime endDate) {
            try {
                List<DateTime> missingDates = service.GetMissingStockPriceDates(companyCode, startDate, endDate);
                if (missingDates.Any()) return Ok(missingDates); 
                return NotFound($"no missing dates found between {startDate} and {endDate}.");
            }catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("Companies/Activate/{companyCode}")]
        public IActionResult ActivateCompany(string companyCode) {
            try {
                return Ok(service.ActivateCompany(companyCode));
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("Companies/Deactivate/{companyCode}")]
        public IActionResult DeactivateCompany(string companyCode) {
            try {
                return Ok(service.DeactivateCompany(companyCode));
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
