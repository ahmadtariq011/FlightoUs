using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Model.Data
{
    [Table("Recipt")]
    public class Recipt
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string ReciptNo { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ReciptStatus { get; set; }

        [ForeignKey("Lead")]
        public int Lead_Id { get; set; }

        [ForeignKey("User")]
        public int CreatedBy { get; set; }
        public virtual User User { get; set; }

        public virtual Lead Lead { get; set; }
    }
}
