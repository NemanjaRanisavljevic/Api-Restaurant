using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        [MaxLength(30, ErrorMessage = "Too many charachters for  name, 30 is max!")]
        [MinLength(3, ErrorMessage = "Too less charachters for  name, 3 is min!")]
        [Required(ErrorMessage ="Name is required!")]
        public string Name { get; set; }
        [MaxLength(30, ErrorMessage = "Too many charachters for Surname, 30 is max!")]
        [MinLength(3, ErrorMessage = "Too less charachters for Surname, 3 is min!")]
        [Required(ErrorMessage = "Surname is required!")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }
        
        [MinLength(6, ErrorMessage = "Too less charachters for password, 6 is min!")]
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
        

        public int RoleId { get; set; }
        
        public bool IsDelete { get; set; }
    }
}
