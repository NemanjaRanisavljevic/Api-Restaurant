using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class ImpressionEditDTO
    {
        public int Id { get; set; }
        [MinLength(5, ErrorMessage = "Content can not be short than 3")]
        [MaxLength(100, ErrorMessage = "Max character for Content is 100")]
        [Required(ErrorMessage = "Contetn is required")]
        public string Content { get; set; }
    }
}
