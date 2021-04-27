using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Model.Data
{
    [Table("Refund")]
    public class Refund
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string TicketNo { get; set; }

        [StringLength(100)]
        public string PNR { get; set; }

        public int RefundType { get; set; }
        public int lead_Id { get; set; }
        public int User_Id { get; set; }
        public int Sale_Id { get; set; }
        public int RefundStatus { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual SalePost SalePost { get; set; }

    }
}
