using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.Repositories {
    public interface IUserRepository {
        public List<Company> GetAllCompanies();
        public List<Company> SearchCompanies(string query);
    }
}
