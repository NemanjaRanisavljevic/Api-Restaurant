using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Meal:Model
    {
        public string Name { get; set; }
        public string Start { get; set; }
        public string Finish { get; set; }

        public ICollection<Meni> Menis { get; set; }
    }
}
