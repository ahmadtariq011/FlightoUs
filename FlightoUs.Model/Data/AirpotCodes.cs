using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Model.Data
{
    [Table("AirpotCodes")]
    public class AirpotCodes
    {
        [Key]
        public int Id { get; set; }
        public string IATA { get; set; }
        public string ICAO { get; set; }
        public string Location { get; set; }
        public string Airport { get; set; }
        public string Country { get; set; }
    }
}
