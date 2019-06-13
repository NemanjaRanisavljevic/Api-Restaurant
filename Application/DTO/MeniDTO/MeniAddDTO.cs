using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.MeniDTO
{
    public class MeniAddDTO
    {
        public int Id { get; set; }
        public string NameFood { get; set; }
        public string Ingradiant { get; set; }
        public string Price { get; set; }
        public string FileName { get; set; }

        public int MealId { get; set; }

    }
}
