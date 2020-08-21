using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AccountAPI.Models {
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

        public Company Company { get; set; } //Navigation Prop

        //1. Company Code – to which Company this Stock Price Info belongs to *
        //2. Stock Exchange – the Stock Price of the Company in this Stock Exchange *
        //3. Current Price – Stock Price *
        //4. Date – Date of the Stock Price *
        //5. Time – Stock Price at this Specific time *
    }
}
