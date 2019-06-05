using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public abstract class BaseSearch
    {
        public int? Id { get; set; }
        public string Keyword { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
