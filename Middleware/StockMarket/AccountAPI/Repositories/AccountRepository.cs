using System.Collections.Generic;
using System.Linq;
using AccountAPI.Data;
using AccountAPI.Models;

namespace AccountAPI.Repositories {
    public class AccountRepository : IAccountRepository {
        private AccountAPIContext context;
        public AccountRepository(AccountAPIContext context) {
            this.context = context;
        }
        public User AddUser(User user) {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public void ConfirmEmail(long id) {
            context.Users.Find(id).Confirmed = true;
            context.SaveChanges();
        }

        public User DeleteUser(long id) {
            User user = GetUserById(id);
            context.Users.Remove(user);
            context.SaveChanges();
            return user;
        }

        public List<User> GetAllUsers() {
            return context.Users.ToList();
        }

        public User GetUserById(long id) {
            return context.Users.Find(id);
        }

        public bool isUsernameExist(string username) {
            return context.Users.Where(U => U.Username == username).Any();
        }

        public User UpdateUser(User user) {
            context.Users.Update(user);
            context.SaveChanges();
            return user;
        }

        public User Validate(string uname, string pass) {
            User user = context.Users.SingleOrDefault(i => i.Username == uname && i.Password == pass);
            return user;
        }
    }
}
