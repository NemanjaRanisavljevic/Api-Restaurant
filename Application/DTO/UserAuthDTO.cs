using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
   public class UserAuthDTO
    {
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }
        [MinLength(6, ErrorMessage = "Too less charachters for password, 6 is min!")]
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
    }
}
