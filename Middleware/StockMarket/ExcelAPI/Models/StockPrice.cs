using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelAPI.Models {
    [Table("StockPrice")]
    public class StockPrice {
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
        public double CurrentPrice { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        public string Time { get; set; }

        public Company Company { get; set; }
    }
}