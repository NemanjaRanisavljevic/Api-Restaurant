using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.MeniDTO
{
    public class MeniGetDTO
    {
        public int Id { get; set; }
        public string NameFood { get; set; }
        public string Ingradiant { get; set; }
        public string Price { get; set; }
        public string FileName { get; set; }
        public string MealName { get; set; }
        public string Alt { get; set; }

        
    }
}
