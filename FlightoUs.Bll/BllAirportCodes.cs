using FlightoUs.Dal;
using FlightoUs.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Bll
{
    public class BllAirportCodes
    {
        private DalAirportCodes dalAirportCodes = new DalAirportCodes();

        public AirpotCodes GetByPK(int Id)
        {
            return dalAirportCodes.GetByPK(Id);
        }
            public int Insert(AirpotCodes airpotCodes)
        {
            return dalAirportCodes.Insert(airpotCodes);
        }

        public List<AirpotCodes> GetAllCodes()
        {
            return dalAirportCodes.GetAllCodes();
        }
    }
}
