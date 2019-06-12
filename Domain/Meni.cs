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
        public int ImageId { get; set; }

        public Image Image { get; set; }

        public int MealId { get; set; }

        public Meal Meal { get; set; }
    }
}
