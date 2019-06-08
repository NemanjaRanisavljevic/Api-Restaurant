﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class DrinkSearch:BaseSearch
    {
        public string DrinkName { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }

        public int PerPage { get; set; } = 4;
        public int PageNumber { get; set; } = 1;
    }
}
