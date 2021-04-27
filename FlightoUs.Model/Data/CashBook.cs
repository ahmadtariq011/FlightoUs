using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Model.Data
{
    [Table("CashBook")]

    public class CashBook
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        public string Remarks { get; set; }

        public int PaymentMode { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
