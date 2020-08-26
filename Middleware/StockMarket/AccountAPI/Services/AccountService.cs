using System.Collections.Generic;
using AccountAPI.Models;
using AccountAPI.Repositories;

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
    }
}
