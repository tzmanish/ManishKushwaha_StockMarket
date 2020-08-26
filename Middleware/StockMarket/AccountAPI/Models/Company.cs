using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountAPI.Models {
    [Table("Company")]
    public class Company {
        [Key]
        [Required]
        [StringLength(15)]
        public string CompanyCode { get; set; }

        [Required]
        [StringLength(30)]
        public string CompanyName { get; set; }

        public double Turnover { get; set; }

        [StringLength(30)]
        public string CEO { get; set; }

        public IEnumerable<StockPrice> StockPrices { get; set; }

        public string Brief { get; set; }

        [StringLength(30)]
        public string Sector { get; set; }

        public string BoardOfDirectors { get; set; }

        public string StockExchanges { get; set; }
        public bool isActive { get; set; }

        //1. Company Name *
        //2. Turnover *
        //3. CEO *
        //4. Board of Directors *
        //5. Listed in Stock Exchanges *
        //6. Sector *
        //7. Brief writeup, about companies Services/Product, etc… *
        //8. Stock code in each Stock Exchange *
    }
}
