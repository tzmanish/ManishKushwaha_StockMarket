using System;
using System.Collections.Generic;
using System.Linq;
using UserAPI.Data;
using UserAPI.Models;

namespace UserAPI.Repositories {
    public class UserRepository : IUserRepository {
        private UserAPIContext context;
        public UserRepository(UserAPIContext context) {
            this.context = context;
        }
        public List<Company> GetAllCompanies() {
            return context.Companies
                .Where(c=>c.isActive==true)
                .ToList();
        }
        public Company GetCompanyById(string id) {
            return context.Companies
                .Where(c => c.CompanyCode==id && c.isActive == true)
                .FirstOrDefault();
        }

        public List<IPODetails> GetIPODetails(string CompanyCode) {
            return context.IPODetails
                .Where(i => i.CompanyCode == CompanyCode)
                .OrderByDescending(c=>c.DateTime)
                .ToList();
        }

        public List<StockPrice> GetStockPrices(string companyCode, DateTime startDate, DateTime endDate) {
            return context.StockPrices
                .Where(sp => 
                    sp.CompanyCode == companyCode && 
                    sp.Date >= startDate && 
                    sp.Date <= endDate
                ).OrderBy(sp=>sp.Date).ToList();
        }

        public List<Company> SearchCompanies(string query) {
            List<Company> companies = context.Companies.Where(c =>
                c.isActive == true && (
                c.CompanyCode.ToLower().StartsWith(query.ToLower()) ||
                c.CompanyName.ToLower().StartsWith(query.ToLower())
            )).ToList();

            if (companies.Any()) return companies;

            return context.Companies.Where(c =>
                c.isActive == true && (
                c.CompanyCode.ToLower().Contains(query.ToLower()) ||
                c.CompanyName.ToLower().Contains(query.ToLower())
            )).ToList();
        }
        public bool IsActive(string companyCode) {
            return context.Companies
                .Where(c => 
                    c.CompanyCode == companyCode && 
                    c.isActive == true
                ).Any();
        }

        public List<IPODetails> GetIPODetails(int itemsPerPage, int pageNumber, bool all) {
            var details = context.IPODetails
                .Where(ipo=>ipo.Company.isActive);

            if (!all) details = details.Where(ipo => ipo.DateTime >= System.DateTime.Now);

            return details
                .OrderBy(ipo => ipo.DateTime)
                .Skip((pageNumber - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();
        }
    }
}
