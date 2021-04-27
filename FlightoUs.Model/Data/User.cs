using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightoUs.Model.Data
{
    [Table("User")]
    public partial class User
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
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        [StringLength(500)]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Telephone { get; set; }

        public int UserType { get; set; }

        [Required]
        [StringLength(100)]
        public string CNIC { get; set; }

        public int GenderType { get; set; }
        public int UserStatus { get; set; }

        public virtual ICollection<Lead> Leads { get; set; }

    }
}
