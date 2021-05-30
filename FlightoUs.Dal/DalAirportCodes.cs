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
        public AirpotCodes GetByPK(int Id)
        {
            using (var entities = new ApplicationDbContext())
            {
                return entities.AirpotCodes.FirstOrDefault(p => p.Id == Id);
            }
        }

        public int Insert(AirpotCodes airpotCodes)
        {
            using (var entities = new ApplicationDbContext())
            {
                entities.AirpotCodes.Add(airpotCodes);
                entities.SaveChanges();
                return airpotCodes.Id;
            }
        }

        public List<AirpotCodes> GetAllCodes()
        {
            using (var entities = new ApplicationDbContext())
            {

                return entities.AirpotCodes.ToList();
            }
        }

    }
}
