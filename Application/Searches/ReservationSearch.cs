using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Searches
{
    public class ReservationSearch
    {
        
        public string NameUser { get; set; }
        public int PerPage { get; set; } = 4;
        public int PageNumber { get; set; } = 1;
    }
}
