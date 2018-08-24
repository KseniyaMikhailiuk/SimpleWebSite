using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MemoryGame.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }

        [Display(Name ="Remember me")]
        public bool RememberMe { get; set; }
    }
}