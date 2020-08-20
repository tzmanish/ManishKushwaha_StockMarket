using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountAPI.Models;

namespace AccountAPI.Services {
    public interface IAccountService {
        void AddUser(User user);
        User Validate(string uname, string pass);
    }
}
