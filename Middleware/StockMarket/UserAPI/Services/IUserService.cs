using System;
using System.Collections.Generic;
using UserAPI.Models;

namespace UserAPI.Services {
    public interface IUserService {
        public Company GetCompanyByCompanyCode(string id);
        public List<Company> GetCompanies();
        public List<Company> GetCompanies(string query);
        public List<IPODetails> GetIPODetails(string CompanyCode);
        public CompanyDetail GetCompanyDetails(string companyCode, DateTime start, DateTime end);
        public bool IsActive(string companyCode);
        public List<IPODetails> GetIPODetails(int itemsPerPage, int pageNumber, bool all);
    }
}
