using FlightoUs.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Model.Services
{
    public class SalePostModel:SalePost
    {
        public string TripTypename { get; set; }
        public string SaleTypename { get; set; }
        public string CreatedDateStr { get; set; }
        public string CreatedByStr { get; set; }
        public string ClientTypeStr { get; set; }
        public string HotelCategoryStr { get; set; }

    }
}
