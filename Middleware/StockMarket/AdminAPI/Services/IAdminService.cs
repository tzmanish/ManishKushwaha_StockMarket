using System.Collections.Generic;
using AdminAPI.Models;

namespace AdminAPI.Services {
    public interface IAdminService {
        public List<Company> GetCompanies();

        public Company GetCompany(string id);

        public void PutCompany(Company company);

        public void PostCompany(Company company);

        public void DeleteCompany(string id);
    }
}
