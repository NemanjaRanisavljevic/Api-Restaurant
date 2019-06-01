using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public abstract class Model
    {
        public int Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifieAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
