﻿using FlightoUs.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Model.Filter
{
    public class LeadSearchFilter: BaseFilter
    {
        public string UserName { get; set; }
        public string Email { get; set; }

    }
}
