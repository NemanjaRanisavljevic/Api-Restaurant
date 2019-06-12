using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Image
    {
        public int Id { get; set; }
        public string Putanja { get; set; }
        public string Alt { get; set; }

        public ICollection<Meni> Menis { get; set; }
    }
}
