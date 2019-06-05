using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name of drink is required")]
        [MinLength(3, ErrorMessage = "Name of drink can not be short than 3")]
        [MaxLength(15, ErrorMessage = "Name of drink can not be loger than 20")]
        public string RoleName { get; set; }
        public bool IsDelete { get; set; }
    }
}
