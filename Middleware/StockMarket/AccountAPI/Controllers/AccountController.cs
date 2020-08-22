using System;
using AccountAPI.Models;
using AccountAPI.Services;
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
                if (user == null) {
                    return Content("Invalid User");
                }
                return Ok(user);
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("isTaken/{username}")]
        public IActionResult isTaken(string username) {
            try {
                return Ok(service.isTaken(username));
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddUser(User user) {
            try {
                service.AddUser(user);
                return Ok();
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(long id) {
            try {
                service.DeleteUser(id);
                return StatusCode(200);
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetUser(long id) {
            try {
                User user = service.GetUser(id);
                return Ok(user);
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("All")]
        public IActionResult GetAllUsers() {
            try {
                return Ok(service.GetAllUsers());
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser(long id, User user) {
            if (id != user.Id) {
                return BadRequest();
            }
            try {
                service.UpdateUser(user);
                return StatusCode(200);
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
