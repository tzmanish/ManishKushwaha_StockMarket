using System;
using System.Collections.Generic;
using AdminAPI.Models;

namespace AdminAPI.Repositories {
    public interface IAdminRepository {
        public List<Company> GetAllCompanies();
        public Company GetCompanyById(string id);
        public Company UpdateCompany(Company company);
        public Company AddCompany(Company company);
        public Company DeleteCompany(string id);
        public IPODetails AddIPO(IPODetails iPO);
        public IPODetails UpdateIPO(IPODetails iPO);
        public bool isStockPrice(string companyCode, DateTime date);
        public Company ActivateCompany(string companyCode);
        public Company DeactivateCompany(string companyCode);
        object isCompanyCodeExist(string companyCode);
    }
}
