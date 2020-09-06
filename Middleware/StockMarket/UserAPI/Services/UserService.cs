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

        public Company GetCompanyByCompanyCode(string compantCode) {
            return repo.GetCompanyById(compantCode);
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

        public CompanyDetail GetCompanyDetails(
            string companyCode, 
            DateTime startDate, 
            DateTime endDate
        ) {
            List<StockPrice> stockPrices = repo.GetStockPrices(
                companyCode, 
                startDate, 
                endDate
            );

            CompanyDetail companyDetail = new CompanyDetail(GetCompanyByCompanyCode(companyCode));

            int i = 0;
            for (
                DateTime date = startDate.Date; 
                date.Date <= endDate.Date; 
                date = date.AddDays(1)
            ) {
                if (
                    i < stockPrices.Count &&
                    stockPrices[i].Date.Date == date.Date
                ) {
                    companyDetail.stockPrices.Add(stockPrices[i]);
                    while (++i < stockPrices.Count && stockPrices[i].Date.Date == date.Date);  //taking only one stock price per day
                } else
                    companyDetail.stockPrices.Add(null);
            }

            return companyDetail;
        }

        public bool IsActive(string companyCode) {
            return repo.IsActive(companyCode);
        }

        public List<IPODetails> GetIPODetails(int itemsPerPage, int pageNumber, bool all) {
            return repo.GetIPODetails(itemsPerPage, pageNumber, all);
        }
    }
}
