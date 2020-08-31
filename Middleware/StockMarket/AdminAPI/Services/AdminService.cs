using System;
using System.Collections.Generic;
using AdminAPI.Models;
using AdminAPI.Repositories;

namespace AdminAPI.Services {
    public class AdminService : IAdminService {
        private IAdminRepository repo;
        public AdminService(IAdminRepository repo) {
            this.repo = repo;
        }

        public Company DeleteCompany(string id) {
            return repo.DeleteCompany(id);
        }

        public List<Company> GetCompanies() {
            return repo.GetAllCompanies();
        }

        public Company GetCompany(string id) {
            return repo.GetCompanyById(id);
        }

        public Company AddCompany(Company company) {
            return repo.AddCompany(company);
        }

        public Company PutCompany(Company company) {
            return repo.UpdateCompany(company);
        }

        public IPODetails AddIPO(IPODetails iPO) {
            return repo.AddIPO(iPO);
        }

        public IPODetails UpdateIPO(IPODetails iPO) {
            return repo.UpdateIPO(iPO);
        }

        public List<DateTime> GetMissingStockPriceDates(string companyCode, DateTime startDate, DateTime endDate) {
            List<DateTime> missingDates = new List<DateTime>();
            for (DateTime date = startDate; date.Date <= endDate.Date; date = date.AddDays(1)) {
                if (!repo.isStockPrice(companyCode, date)) missingDates.Add(date);
            }
            return missingDates;
        }

        public Company ActivateCompany(string companyCode) {
            return repo.ActivateCompany(companyCode);
        }

        public Company DeactivateCompany(string companyCode) {
            return repo.DeactivateCompany(companyCode);
        }

        public bool isTaken(string companyCode) {
            return repo.isCompanyCodeExist(companyCode);
        }

        public List<IPODetails> GetIPOs() {
            return repo.GetIPOs();
        }
    }
}
