﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public User Validate(string uname, string pass) {
            return repo.Validate(uname, pass);
        }
    }
}
