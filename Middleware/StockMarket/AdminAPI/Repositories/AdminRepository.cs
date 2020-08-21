using System.Collections.Generic;
using System.Linq;
using AdminAPI.Data;
using AdminAPI.Models;

namespace AdminAPI.Repositories {
    public class AdminRepository:IAdminRepository {
        private readonly AdminAPIContext context;

        public AdminRepository(AdminAPIContext context) {
            this.context = context;
        }

        public List<Company> GetAllCompanies() {
            return context.Companies.ToList();
        }

        public Company GetCompanyById(string id) {
            return context.Companies.Find(id); ;
        }

        public void UpdateCompany(Company company) {
            context.Companies.Update(company);
            context.SaveChanges();
        }

        public void AddCompany(Company company) {
            context.Companies.Add(company);
            context.SaveChanges();
        }

        public void DeleteCompany(string id) {
            var company = context.Companies.Find(id);
            context.Companies.Remove(company);
            context.SaveChanges();
        }
    }
}
