using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class MeniMeal
    {
        public int Id { get; set; }
        public int MeniId { get; set; }
        public int MealId { get; set; }

        public Meni Meni { get; set; }
        public Meal Meal { get; set; }
    }
}
