using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class ImpressSearch
    {
        public string Content { get; set; }

        public int PerPage { get; set; } = 4;
        public int PageNumber { get; set; } = 1;
    }
}
