using System;
using System.Collections.Generic;
using System.Linq;
using AdminAPI.Models;
using AdminAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase{
        private IAdminService service;
        public AdminController(IAdminService service) {
            this.service = service;
        }
        // GET: api/admin/companies
        [HttpGet]
        [Route("companies")]
        public IActionResult GetCompanies()
        {
            try {
                List<Company> companies = service.GetCompanies();
                if(companies.Any())
                    return Ok(companies);
                return Content("Currenty there is no company in record.");
            } catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/admin/companies/AIR
        [HttpGet]
        [Route("companies/{id}")]
        public IActionResult GetCompany(string id)
        {
            try {
                Company company = service.GetCompany(id);
                if (company!=null)
                    return Ok(company);
                return NotFound();
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/admin/Companies/AIR
        [HttpPut]
        [Route("companies/{id}")]
        public IActionResult PutCompany(string id, Company company)
        {
            if (id != company.CompanyCode){
                return BadRequest();
            }

            try {
                service.PutCompany(company);
                return StatusCode(200);
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/admin/Companies
        [HttpPost]
        [Route("companies")]
        public IActionResult PostCompany(Company company)
        {
            try {
                service.PostCompany(company);
                return StatusCode(200);
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/admin/Companies/AIR
        [HttpDelete]
        [Route("companies/{id}")]
        public IActionResult DeleteCompany(string id)
        {
            try {
                service.DeleteCompany(id);
                return StatusCode(200);
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
