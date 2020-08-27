using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;
using AccountAPI.Models;
using AccountAPI.Repositories;
using Microsoft.AspNetCore.Http;

namespace AccountAPI.Services {
    public class AccountService : IAccountService {
        private IAccountRepository repo;
        public AccountService(IAccountRepository repo) {
            this.repo = repo;
        }
        public User AddUser(User user) {
            return repo.AddUser(user);
        }

        public User DeleteUser(long id) {
            return repo.DeleteUser(id);
        }

        public User GetUser(long id) {
            return repo.GetUserById(id);
        }

        public User UpdateUser(User user) {
            return repo.UpdateUser(user);
        }

        public User Validate(string uname, string pass) {
            return repo.Validate(uname, pass);
        }

        public List<User> GetAllUsers() {
            return repo.GetAllUsers();
        }

        public bool isTaken(string username) {
            return repo.isUsernameExist(username);
        }

        public void ConfirmEmail(string username) {
            repo.ConfirmEmail(username);
        }

        public void SendConfirmationEmail(string callbackUrl, string userEmail) {
            string from = "";   //email here
            string password = "";   //password here
            string to = userEmail;
            string subject = "Account confirmation email.";
            string body = $"Please click <a href = \"{callbackUrl}\">here</a> to confirm your email.";

            MailMessage mailMessage = new MailMessage(from, to, subject, body);
            mailMessage.IsBodyHtml = true;

            NetworkCredential networkCredential = new NetworkCredential(from, password);

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = networkCredential;
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }
    }
}
