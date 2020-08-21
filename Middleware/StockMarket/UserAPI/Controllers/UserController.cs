using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserAPIContext _context;

        public UserController(UserAPIContext context)
        {
            _context = context;
        }

        // GET: api/user/companies
        [HttpGet]
        [Route("companies")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        // GET: api/user/companies/AIR
        [HttpGet]
        [Route("companies/{query}")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies(string query)
        {
            List<Company> companies = await _context.Companies.Where(c =>
                c.CompanyCode.ToLower().StartsWith(query.ToLower()) ||
                c.CompanyName.ToLower().StartsWith(query.ToLower())
            ).ToListAsync();

            if (companies.Any()) return companies;

            return await _context.Companies.Where(c=>
                c.CompanyCode.ToLower().Contains(query.ToLower()) ||
                c.CompanyName.ToLower().Contains(query.ToLower())
            ).ToListAsync();
        }
    }
}
