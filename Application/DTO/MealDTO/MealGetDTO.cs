using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.MealDTO
{
    public class MealGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Start { get; set; }
       
        public string Finish { get; set; }

        public bool IsDeleted { get; set; }
    }
}
