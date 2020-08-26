using System;
using System.Net;
using System.Net.Mail;
using AccountAPI.Models;
using AccountAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace AccountAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {
        private IAccountService service;
        public AccountController(IAccountService service) {
            this.service = service;
        }

        [HttpPost]
        [Route("Validate")]
        public IActionResult Validate(User credentials) {
            try {
                User user = service.Validate(credentials.Username, credentials.Password);
                if (user == null) {
                    return StatusCode(401, "Invalid Credentials");
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
        [Route("Add")]
        public IActionResult AddUser(User user) {
            try {
                return Ok(service.AddUser(user));
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(long id) {
            try {
                return Ok(service.DeleteUser(id));
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpGet("{id}")]
        public IActionResult GetUser(long id) {
            try {
                return Ok(service.GetUser(id));
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
        
        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateUser(User user) {
            try {
                return Ok(service.UpdateUser(user));
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("Email/Send")]
        public IActionResult SendConfirmationEmail(User user) {
            try { 
                var callbackUrl = Url.Action("ConfirmEmail", "Account", user, protocol: HttpContext.Request.Scheme);
                service.SendConfirmationEmail(callbackUrl, user.Email);
                return Ok("Confirmation mail sent to " + user.Email);
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("Email/Confirm")]
        public IActionResult ConfirmEmail(User user) {
            try {
                service.ConfirmEmail(user.Id);
                return Ok("email confirmed.");
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
