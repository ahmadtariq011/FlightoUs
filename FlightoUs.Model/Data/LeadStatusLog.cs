using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Model.Data
{
    [Table("LeadStatusLog")]
    public partial class LeadStatusLog
    {
        [Key]
        public int Id { get; set; }
        public int StatusType { get; set; }

        [ForeignKey("Lead")]
        public int Lead_Id { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }
        public virtual User User { get; set; }

        public virtual Lead Lead { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
