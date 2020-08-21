using System.Collections.Generic;
using AdminAPI.Models;

namespace AdminAPI.Repositories {
    public interface IAdminRepository {
        public List<Company> GetAllCompanies();
        public Company GetCompanyById(string id);
        public void UpdateCompany(Company company);
        public void AddCompany(Company company);
        public void DeleteCompany(string id);
    }
}
