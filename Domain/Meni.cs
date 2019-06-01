using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Meni:Model
    {
        public string NameFood { get; set; }
        public string Ingrediant { get; set; }
        public string Price { get; set; }

        public ICollection<MeniMeal> MeniMeals { get; set; }
    }
}
