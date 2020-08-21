using System.Collections.Generic;
using AdminAPI.Models;
using AdminAPI.Repositories;

namespace AdminAPI.Services {
    public class AdminService : IAdminService {
        private IAdminRepository repo;
        public AdminService(IAdminRepository repo) {
            this.repo = repo;
        }
        public void DeleteCompany(string id) {
            repo.DeleteCompany(id);
        }

        public List<Company> GetCompanies() {
            return repo.GetAllCompanies();
        }

        public Company GetCompany(string id) {
            return repo.GetCompanyById(id);
        }

        public void PostCompany(Company company) {
            repo.AddCompany(company);
        }

        public void PutCompany(Company company) {
            repo.UpdateCompany(company);
        }
    }
}
