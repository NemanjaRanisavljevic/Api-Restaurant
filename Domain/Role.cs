using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class Role:Model
    {
        public string NameRole { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
