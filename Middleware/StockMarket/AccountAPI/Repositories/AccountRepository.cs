using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountAPI.Data;
using AccountAPI.Models;

namespace AccountAPI.Repositories {
    public class AccountRepository : IAccountRepository {
        private AccountAPIContext context;
        public AccountRepository(AccountAPIContext context) {
            this.context = context;
        }
        public void AddUser(User user) {
            context.Add(user);
            context.SaveChanges();
        }

        public User Validate(string uname, string pass) {
            User user = context.User.SingleOrDefault(i => i.Username == uname && i.Password == pass);
            return user;
        }
    }
}
