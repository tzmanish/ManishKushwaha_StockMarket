using System.Collections.Generic;
using AccountAPI.Models;

namespace AccountAPI.Repositories {
    public interface IAccountRepository {
        User AddUser(User user);
        User Validate(string uname, string pass);
        User DeleteUser(long id);
        bool isUsernameExist(string username);
        List<User> GetAllUsers();
        User UpdateUser(User user);
        User GetUserById(long id);
        void ConfirmEmail(long id);
    }
}
