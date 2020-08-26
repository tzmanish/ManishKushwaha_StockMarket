using System;
using System.Collections.Generic;
using UserAPI.Models;

namespace UserAPI.Repositories {
    public interface IUserRepository {
        public List<Company> GetAllCompanies();
        public Company GetCompanyById(string id);
        public List<Company> SearchCompanies(string query);
        public List<IPODetails> GetIPODetails(string companyCode);
        public List<StockPrice> GetStockPrices(string companyCode, DateTime start, DateTime end);
        public bool IsActive(string companyCode);
    }
}
