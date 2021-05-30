using FlightoUs.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Model.Services
{
    public class LeadModel:Lead
    {
        public string LeadStatusName { get; set; }
        public string LeadTypeName { get; set; }
        public string TripTypeName { get; set; }
        public string ClassOfTravelName { get; set; }
        public string CustomeTypeName { get; set; }
        public string LeadGenderName { get; set; }

        public string CreatedDateStr { get; set; }
        public string TakenOnStr { get; set; }
        public int Userlog { get; set; }
        //public string LeadTypeDemandName { get; set; }
    }
}
