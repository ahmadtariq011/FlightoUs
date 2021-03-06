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

        [StringLength(100)]
        public string FirstName { get; set; }
        public string ContactCustomer { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        public string Address { get; set; }

        [StringLength(500)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Telephone { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime AssignDate { get; set; }
        [ForeignKey("User")]
        public int Careof { get; set; }
        public int AssignToUser { get; set; }

        [StringLength(100)]
        public string CNIC { get; set; }

        public int LeadType { get; set; }
        public int LeadTypeDemand { get; set; }
        public int LeadStatus { get; set; }

        public DateTime ReturnDate { get; set; }
        public int CustomerType { get; set; }
        public DateTime DepartureDate { get; set; }
        public int ClassOfTravel { get; set; }
        public int LeadGender { get; set; }
        public int TripTyepLead { get; set; }

        public string SecondaryPhoneNumber { get; set; }
        public int ToCode { get; set; }
        public int FromCode { get; set; }

        public string FreeText { get; set; }
        public string LeadTitle { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Remarks> Remarks { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual Hotel Hotels { get; set; }




    }
}
