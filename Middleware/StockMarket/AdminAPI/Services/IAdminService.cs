using System;
using System.Collections.Generic;
using AdminAPI.Models;

namespace AdminAPI.Services {
    public interface IAdminService {
        public List<Company> GetCompanies();

        public Company GetCompany(string id);

        public Company PutCompany(Company company);

        public Company AddCompany(Company company);

        public Company DeleteCompany(string id);
        public IPODetails AddIPO(IPODetails iPO);
        public IPODetails UpdateIPO(IPODetails iPO);
        public List<DateTime> GetMissingStockPriceDates(
            string companyCode, 
            DateTime startDate, 
            DateTime endDate
        );
        public Company ActivateCompany(string companyCode);
        public Company DeactivateCompany(string companyCode);
        object isTaken(string companyCode);
    }
}
