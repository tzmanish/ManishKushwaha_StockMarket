using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAPI.Models {
    public class IPODetails {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Company")]
        [Required]
        [StringLength(15)]
        public string CompanyCode { get; set; }

        [Required]
        [StringLength(30)]
        public string StockExchange { get; set; }

        [Required]
        public double PricePerShare { get; set; }

        [Required]
        public long TotalShares { get; set; }

        public DateTime DateTime { get; set; }

        public Company Company { get; set; }

        public string Remrks { get; set; }

        //1. id
        //2. Company Name
        //3. Stock Exchange
        //4. Price per share
        //5. Total number of Shares
        //6. Open Date Time
        //7. Remarks
    }
}
