using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class UserSearch
    {
        
        public string Name { get; set; }
        public string SurName { get; set; }
        public bool? IsDeleted { get; set; }

        public int PerPage { get; set; } = 4;
        public int PageNumber { get; set; } = 1;
    }
}
