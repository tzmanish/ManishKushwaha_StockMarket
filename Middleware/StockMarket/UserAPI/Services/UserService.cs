using System;
using System.Collections.Generic;
using UserAPI.Models;
using UserAPI.Repositories;

namespace UserAPI.Services {
    public class UserService:IUserService {
        IUserRepository repo;
        public UserService(IUserRepository repo) {
            this.repo = repo;
        }

        public Company GetCompany(string id) {
            return repo.GetCompanyById(id);
        }

        public List<Company> GetCompanies() {
            return repo.GetAllCompanies();
        }

        public List<Company> GetCompanies(string query) {
            return repo.SearchCompanies(query);
        }

        public List<IPODetails> GetIPODetails(string CompanyCode) {
            return repo.GetIPODetails(CompanyCode);
        }

        public List<StockPrice> GetStockPrices(string companyCode, DateTime startDate, DateTime endDate) {
            return repo.GetStockPrices(companyCode, startDate, endDate);
        }

        public bool IsActive(string companyCode) {
            return repo.IsActive(companyCode);
        }

        public List<IPODetails> GetIPODetails(int itemsPerPage, int pageNumber) {
            return repo.GetIPODetails(itemsPerPage, pageNumber);
        }
    }
}
