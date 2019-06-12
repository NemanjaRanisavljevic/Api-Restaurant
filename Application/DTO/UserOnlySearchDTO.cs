using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class UserOnlySearchDTO
    {
        public int Id { get; set; }
        [MaxLength(30, ErrorMessage = "Too many charachters for  name, 30 is max!")]
        [MinLength(3, ErrorMessage = "Too less charachters for  name, 3 is min!")]
        public string Name { get; set; }
        [MaxLength(30, ErrorMessage = "Too many charachters for Surname, 30 is max!")]
        [MinLength(3, ErrorMessage = "Too less charachters for Surname, 3 is min!")]
        public string Surname { get; set; }
        public string Email { get; set; }

        public string RoleName { get; set; }
        public bool IsDelete { get; set; }
    }
}
