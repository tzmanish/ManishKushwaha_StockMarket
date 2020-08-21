using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;
using UserAPI.Repositories;

namespace UserAPI.Services {
    public interface IUserService {
        public List<Company> GetCompanies();
        public List<Company> GetCompanies(string query);
    }
}
