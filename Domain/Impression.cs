using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Impression:Model
    {
        public string Content { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
