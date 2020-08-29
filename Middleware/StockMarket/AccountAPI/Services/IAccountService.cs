using System.Collections.Generic;
using AccountAPI.Models;

namespace AccountAPI.Services {
    public interface IAccountService {
        User AddUser(User user);
        User Validate(string uname, string pass);
        bool isUsernameTaken(string username);
        bool isEmailTaken(string email);
        User DeleteUser(long id);
        User GetUser(long id);
        List<User> GetAllUsers();
        User UpdateUser(User user);
        void ConfirmEmail(string username);
        void SendConfirmationEmail(string callbackUrl, string userEmail);
    }
}
