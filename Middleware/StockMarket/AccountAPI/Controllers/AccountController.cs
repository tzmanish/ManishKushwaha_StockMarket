using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using AccountAPI.Auth;
using AccountAPI.Models;
using AccountAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace AccountAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase {
        private IAccountService service;
        private readonly IConfiguration configuration;
        public AccountController(IAccountService service, IConfiguration configuration) {
            this.service = service;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("Validate")]
        [AllowAnonymous]
        public IActionResult Validate(Credentials credentials) {
            try {
                User user = service.Validate(credentials.Username, credentials.Password);
                if (user == null)
                    return StatusCode(401, "Invalid Credentials.");
                if(!user.Confirmed) {
                    SendConfirmationEmail(user);
                    return StatusCode(401, "A confirmation mail has been sent to your email, please confirm your email to access your profile.");
                }
                return Ok(GenerateJwtToken(user.Username, user.Role));
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        private Token GenerateJwtToken(string username, string role) {
            List<Claim> claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim(ClaimTypes.Role, role)
            };

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            DateTime expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtExpireDays"]));
            JwtSecurityToken Token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires:expires,
                signingCredentials:credentials
            );
            Token response = new Token {
                username = username,
                token = new JwtSecurityTokenHandler().WriteToken(Token)
            };

            return response;
        }

        [HttpGet]
        [AllowAnonymous]
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
        [AllowAnonymous]
        public IActionResult AddUser(User user) {
            try {
                user.Role = Role.user;
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
        [Authorize(Roles = "admin")]
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
        [AllowAnonymous]
        public IActionResult SendConfirmationEmail(User user) {
            try {
                string token = GenerateEmailConfirmationToken(user.Username);
                string escapedToken = HttpUtility.UrlEncode(token);
                string callbackUrl = $"http://localhost:65283/Account/Email/confirm/{escapedToken}";

                service.SendConfirmationEmail(callbackUrl, user.Email);
                return Ok("Confirmation mail sent to " + user.Email);
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        private string GenerateEmailConfirmationToken(string username, int expiresIn=5) {

            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, username)
            };

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            DateTime expires = DateTime.Now.AddMinutes(expiresIn);
            JwtSecurityToken Token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(Token);
        }

        private string ValidateEmailConfirmationToken(string token) {
            var tokenHandler = new JwtSecurityTokenHandler();
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            try {
                tokenHandler.ValidateToken(token, new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = configuration["JwtIssuer"],
                    ValidAudience = configuration["JwtIssuer"],
                    IssuerSigningKey = securityKey
                }, out SecurityToken validatedToken);
            }catch {
                throw new Exception("Your token is not valid, it may have expired.");
            }


            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            var stringClaimValue = securityToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            return stringClaimValue;
        }

        [HttpGet]
        [Route("Email/Confirm/{token}")]
        [AllowAnonymous]
        public IActionResult ConfirmEmail(string encodedToken) {
            string token = HttpUtility.UrlDecode(encodedToken);
            try {
                string username = ValidateEmailConfirmationToken(token);
                service.ConfirmEmail(username);
                return Ok("email confirmed.");
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
