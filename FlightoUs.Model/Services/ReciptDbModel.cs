using FlightoUs.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Model.Services
{
    public class ReciptDbModel:Recipt
    {
        public string LeadTitle { get; set; }
        public string ContactNumber { get; set; }
        public string CreatedDateStr { get; set; }
        public int Usertype { get; set; }
        public string CreatedByStr { get; set; }

    }
}
