using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO.MealDTO
{
    public class MealCreateDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(10, ErrorMessage = "Max char for Name is 10")]
        [MinLength(3, ErrorMessage = "Min char for Name is 3")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Start is required")]
        [MaxLength(2, ErrorMessage = "Max char for Start is 3")]
        [Range(6, 23, ErrorMessage = "Range for Start is 6 - 23 h")]
        public string Start { get; set; }
        [Required(ErrorMessage = "Finish is required")]
        [MaxLength(2, ErrorMessage = "Max char for Finish is 3")]
        [Range(6, 23, ErrorMessage = "Range for Finish is 6 - 23 h")]
        public string Finish { get; set; }
    }
}
