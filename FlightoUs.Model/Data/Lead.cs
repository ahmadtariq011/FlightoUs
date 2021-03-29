using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightoUs.Model.Data
{
    [Table("Lead")]
    public partial class Lead
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(500)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Telephone { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime AssignDate { get; set; }

        [ForeignKey("User")]
        public int AssignToUser { get; set; }
        [Required]
        [StringLength(100)]
        public string CNIC { get; set; }

        public int LeadType { get; set; }
        public int LeadTypeDemand { get; set; }
        public int LeadStatus { get; set; }



        public virtual User User { get; set; }
        public virtual ICollection<Remarks> Remarks { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual Hotel Hotels { get; set; }




    }
}
