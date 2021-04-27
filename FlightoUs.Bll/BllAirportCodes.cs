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

        public int Insert(AirpotCodes airpotCodes)
        {
            return dalAirportCodes.Insert(airpotCodes);
        }


    }
}
