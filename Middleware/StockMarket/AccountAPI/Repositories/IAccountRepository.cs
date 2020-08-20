using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountAPI.Models;

namespace AccountAPI.Repositories {
    public interface IAccountRepository {
        void AddUser(User user);
        User Validate(string uname, string pass);
    }
}
