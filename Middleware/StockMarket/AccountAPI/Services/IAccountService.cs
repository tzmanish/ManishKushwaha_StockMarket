﻿using System.Collections.Generic;
using AccountAPI.Models;

namespace AccountAPI.Services {
    public interface IAccountService {
        void AddUser(User user);
        User Validate(string uname, string pass);
        bool isTaken(string username);
        void DeleteUser(long id);
        User GetUser(long id);
        List<User> GetAllUsers();
        void UpdateUser(User user);
    }
}
