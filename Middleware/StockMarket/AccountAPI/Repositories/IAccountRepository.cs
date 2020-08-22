using System.Collections.Generic;
using AccountAPI.Models;

namespace AccountAPI.Repositories {
    public interface IAccountRepository {
        void AddUser(User user);
        User Validate(string uname, string pass);
        void DeleteUser(long id);
        bool isUsernameExist(string username);
        List<User> GetAllUsers();
        void UpdateUser(User user);
        User GetUserById(long id);
    }
}
