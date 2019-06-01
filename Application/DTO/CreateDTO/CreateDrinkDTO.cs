using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO.CreateDTO
{
    public class CreateDrinkDTO
    {
        [Required(ErrorMessage ="Name of drink is required")]
        [MinLength(3,ErrorMessage ="Name of drink can not be short than 3")]
        [MaxLength(20,ErrorMessage = "Name of drink can not be loger than 20")]
        public string DrinkName { get; set; }
        [Required(ErrorMessage = "Price of drink is required")]
        public double Price { get; set; }
    }
}
