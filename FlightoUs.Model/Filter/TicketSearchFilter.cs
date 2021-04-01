using FlightoUs.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Model.Filter
{
    class TicketSearchFilter :BaseFilter
    {
        public string From { get; set; }

        
        public string To { get; set; }
    }
}
