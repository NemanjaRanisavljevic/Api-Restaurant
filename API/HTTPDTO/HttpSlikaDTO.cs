using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.HTTPDTO
{
    public class HttpSlikaDTO
    {
        [Required(ErrorMessage ="Name of food is required")]
        [MaxLength(30,ErrorMessage ="Max lenght for name food is 30")]
        [MinLength(5,ErrorMessage = "min lenght for name food is 5")]
        public string NameFood { get; set; }
        [Required(ErrorMessage = "Ingradiant of food is required")]
        [MinLength(5, ErrorMessage = "Min lenght for Ingradiant is 5")]
        public string Ingradiant { get; set; }
        [Required(ErrorMessage = "Price of food is required")]
        
        public string Price { get; set; }
        [Required(ErrorMessage = "Meal of food is required")]
        public int MealId { get; set; }

        public IFormFile Image { get; set; }
    }
}
