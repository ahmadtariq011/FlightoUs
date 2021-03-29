using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Model.Data
{
    [Table("Hotel")]

    public partial class Hotel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal NetValue { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalValue { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PSF { get; set; }
        public DateTime CreatedDate { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [ForeignKey("Lead")]
        public int Lead_Id { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }
        public virtual User User { get; set; }

        public virtual Lead Lead { get; set; }

    }
}
