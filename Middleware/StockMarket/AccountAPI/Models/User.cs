using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AccountAPI.Models {
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
        public bool IsAdmin { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Mobile { get; set; }

        [Required]
        public bool Confirmed { get; set; }


        //1. Id
        //2. Username
        //3. Password
        //4. UserType(if Admin or normal User)
        //5. E-mail
        //6. Mobile number
        //7. Confirmed
    }
}
