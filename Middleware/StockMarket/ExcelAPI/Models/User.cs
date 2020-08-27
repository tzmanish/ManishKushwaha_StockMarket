using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelAPI.Models {
    [Table("User")]
    public class User {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Username { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Mobile { get; set; }

        [Required]
        public bool Confirmed { get; set; }
    }
}
