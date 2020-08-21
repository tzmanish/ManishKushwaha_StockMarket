using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Data;
using UserAPI.Models;

namespace UserAPI.Repositories {
    public class UserRepository : IUserRepository {
        private UserAPIContext context;
        public UserRepository(UserAPIContext context) {
            this.context = context;
        }
        public List<Company> GetAllCompanies() {
            return context.Companies.ToList();
        }

        public List<Company> SearchCompanies(string query) {
            List<Company> companies = context.Companies.Where(c =>
                c.CompanyCode.ToLower().StartsWith(query.ToLower()) ||
                c.CompanyName.ToLower().StartsWith(query.ToLower())
            ).ToList();

            if (companies.Any()) return companies;

            return context.Companies.Where(c =>
                c.CompanyCode.ToLower().Contains(query.ToLower()) ||
                c.CompanyName.ToLower().Contains(query.ToLower())
            ).ToList();
        }
    }
}
