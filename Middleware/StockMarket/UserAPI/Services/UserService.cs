using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;
using UserAPI.Repositories;

namespace UserAPI.Services {
    public class UserService:IUserService {
        IUserRepository repo;
        public UserService(IUserRepository repo) {
            this.repo = repo;
        }

        public List<Company> GetCompanies() {
            return repo.GetAllCompanies();
        }

        public List<Company> GetCompanies(string query) {
            return repo.SearchCompanies(query);
        }
    }
}
