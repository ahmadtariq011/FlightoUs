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
        [StringLength(100)]
        public string ReciptNo { get; set; }

        public DateTime CreatedDate { get; set; }
        public int ReciptStatus { get; set; }
        public int FormOfPayment { get; set; }
        public string FirstServiceTitle { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FirstServicePrice { get; set; }
        public string SecondServiceTitle { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SecondServicePrice { get; set; }
        public string ThirdServiceTitle { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ThirdServicePrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AmountPaid { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; set; }
        public int ItemNo { get; set; }
        public string Remarks { get; set; }
        [ForeignKey("Lead")]
        public int Lead_Id { get; set; }

        [ForeignKey("User")]
        public int CreatedBy { get; set; }
        public virtual User User { get; set; }

        public virtual Lead Lead { get; set; }
    }
}
