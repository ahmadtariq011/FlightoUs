using FlightoUs.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Dal
{
    public class DalAirportCodes
    {
        public int Insert(AirpotCodes airpotCodes)
        {
            using (var entities = new ApplicationDbContext())
            {
                entities.AirpotCodes.Add(airpotCodes);
                entities.SaveChanges();
                return airpotCodes.Id;
            }
        }
    }
}
