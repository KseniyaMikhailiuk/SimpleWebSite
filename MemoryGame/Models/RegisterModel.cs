using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MemoryGame.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage ="length: 6-20 symbols", MinimumLength =6)]
        [Display(Name ="Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }
    }
}