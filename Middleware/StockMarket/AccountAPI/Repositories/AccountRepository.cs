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
        public void AddUser(User user) {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void DeleteUser(long id) {
            context.Users.Remove(GetUserById(id));
            context.SaveChanges();
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

        public void UpdateUser(User user) {
            context.Users.Update(user);
            context.SaveChanges();
        }

        public User Validate(string uname, string pass) {
            User user = context.Users.SingleOrDefault(i => i.Username == uname && i.Password == pass);
            return user;
        }
    }
}
