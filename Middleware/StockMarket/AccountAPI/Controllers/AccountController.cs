using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountAPI.Models;
using AccountAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {
        private IAccountService service;
        public AccountController(IAccountService service) {
            this.service = service;
        }

        [HttpGet]
        [Route("Validate/{uname}/{pass}")]
        public IActionResult Validate(string uname, string pass) {
            try {
                User user = service.Validate(uname, pass);
                if(user == null){
                    return Content("Invalid User");
                }
                return Ok(user);
            }
            catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user) {
            try {
                service.AddUser(user);
                return Ok();
            }
            catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
