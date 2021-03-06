using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Model.Data
{
    [Table("SalePost")]
    public class SalePost
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string From { get; set; }

        [StringLength(100)]
        public string To { get; set; }

        public DateTime DepartureDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal NetValue { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalValue { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PSF { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PNR { get; set; }
        public DateTime ArrivalDate { get; set; }

        public string City { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ClientType { get; set; }
        public string Sector { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public int SalePostType { get; set; }

        [ForeignKey("Lead")]
        public int Lead_Id { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }
        public virtual User User { get; set; }
        public int TripType { get; set; }
        public virtual Lead Lead { get; set; }
        public int HotelCategory { get; set; }
    }
}
