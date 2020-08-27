using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "user")]
    public class UserController : ControllerBase
    {
        private IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        // GET: api/user/companies
        [HttpGet]
        [Route("Companies/All")]
        public IActionResult GetCompanies()
        {
            try {
                List<Company> companies = service.GetCompanies();
                if (companies.Any()) return Ok(companies);
                return NotFound("No active company found in record.");
            } catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/user/companies/AIR
        [HttpGet]
        [Route("Companies/{id}")]
        public IActionResult GetCompany(string id) {
            try {
                Company company = service.GetCompany(id);
                if (company != null) return Ok(company);
                return NotFound(id + " not found.");
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/user/companies/AIR
        [HttpGet]
        [Route("Companies/Search/{query}")]
        public IActionResult GetCompanies(string query)
        {
            try {
                List<Company> companies = service.GetCompanies(query);
                if(companies.Any()) return Ok(companies);
                return NotFound("No active company found matching "+query);
            }catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("IPO/company/{companyCode}")]
        public IActionResult GetIPODetails(string companyCode) {
            try {
                if (!service.IsActive(companyCode)) return NotFound("No active company identified by "+companyCode);
                List<IPODetails> details = service.GetIPODetails(companyCode);
                if(details.Any()) return Ok(details);
                return NotFound("No IPO Detail found for " + companyCode);
            } catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("IPO/{pageNumber:int=1}/{itemsPerPage:int=10}")]
        public IActionResult GetIPODetails(int pageNumber, int itemsPerPage) {
            try {
                if (itemsPerPage <= 0 || pageNumber <= 0) 
                    return BadRequest("'Items Per Page' and 'Page Number' shold be positive integers.");
                List <IPODetails> details = service.GetIPODetails(itemsPerPage, pageNumber);
                if (details.Any()) return Ok(details);
                return NotFound("That's all, Come back later for more.");
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("StockPrices/{companyCode}/{startDate}/{endDate}")]
        public IActionResult GetStockPrices(string companyCode, DateTime startDate, DateTime endDate) {
            try {
                if (!service.IsActive(companyCode)) return NotFound("No active company identified by " + companyCode);
                List<StockPrice> stockPrices = service.GetStockPrices(companyCode, startDate, endDate);
                if (stockPrices.Any()) return Ok(stockPrices);
                return NotFound($"No stock-price details for {companyCode} between {startDate} and {endDate}.");
            }catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
