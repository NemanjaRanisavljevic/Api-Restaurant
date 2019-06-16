using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO.MeniDTO
{
    public class EditMeniDTO
    {
        public int Id { get; set; }
        [MaxLength(30, ErrorMessage = "Max lenght for name food is 30")]
        [MinLength(5, ErrorMessage = "min lenght for name food is 5")]
        public string NameFood { get; set; }

        [MinLength(5, ErrorMessage = "Min lenght for Ingradiant is 5")]
        public string Ingradiant { get; set; }


        public string Price { get; set; }
        [Required(ErrorMessage = "Meal of food is required")]
        public int MealId { get; set; }

        public IFormFile Image { get; set; }
    }
}
