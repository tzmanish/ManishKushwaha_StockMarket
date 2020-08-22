using System.Collections.Generic;
using AccountAPI.Models;
using AccountAPI.Repositories;

namespace AccountAPI.Services {
    public class AccountService : IAccountService {
        private IAccountRepository repo;
        public AccountService(IAccountRepository repo) {
            this.repo = repo;
        }
        public void AddUser(User user) {
            repo.AddUser(user);
        }

        public void DeleteUser(long id) {
            repo.DeleteUser(id);
        }

        public User GetUser(long id) {
            return repo.GetUserById(id);
        }

        public void UpdateUser(User user) {
            repo.UpdateUser(user);
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
