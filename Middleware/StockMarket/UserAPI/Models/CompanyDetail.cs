using System.Collections.Generic;

namespace UserAPI.Models {
    public class CompanyDetail {
        public CompanyDetail(Company company) {
            Company = company;
            stockPrices = new List<StockPrice>();
        }
        public Company Company { get; set; }
        public List<StockPrice> stockPrices { get; set; }
    }
}
