using System;
using System.Collections.Generic;
using System.Linq;
using AdminAPI.Data;
using AdminAPI.Models;

namespace AdminAPI.Repositories {
    public class AdminRepository:IAdminRepository {
        private readonly AdminAPIContext context;

        public AdminRepository(AdminAPIContext context) {
            this.context = context;
        }

        public List<Company> GetAllCompanies() {
            return context.Companies.ToList();
        }

        public Company GetCompanyById(string id) {
            return context.Companies.Find(id); ;
        }

        public Company UpdateCompany(Company company) {
            context.Companies.Update(company);
            context.SaveChanges();
            return company;
        }

        public Company AddCompany(Company company) {
            context.Companies.Add(company);
            context.SaveChanges();
            return company;
        }

        public Company DeleteCompany(string id) {
            var company = context.Companies.Find(id);
            context.Companies.Remove(company);
            context.SaveChanges();
            return company;
        }

        public IPODetails AddIPO(IPODetails iPO) {
            context.IPODetails.Add(iPO);
            context.SaveChanges();
            return iPO;
        }

        public IPODetails UpdateIPO(IPODetails iPO) {
            context.IPODetails.Update(iPO);
            context.SaveChanges();
            return iPO;
        }
        public bool isStockPrice(string companyCode, DateTime date) {
            return context.StockPrices
                .Where(sp =>
                    sp.CompanyCode == companyCode &&
                    sp.Date == date
                ).Any();
        }

        public Company ActivateCompany(string companyCode) {
            Company company = context.Companies.Find(companyCode);
            company.isActive = true;
            context.SaveChanges();
            return company;
        }

        public Company DeactivateCompany(string companyCode) {
            Company company = context.Companies.Find(companyCode);
            company.isActive = false;
            context.SaveChanges();
            return company;
        }
    }
}
