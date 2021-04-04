using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightoUs.Models.Filters;

namespace FlightoUs.Model.Filter
{
    public class RemarksSearchFilter : BaseFilter
    {
        public string Details { get; set; }
        public int LeadId { get; set; }

    }
}
