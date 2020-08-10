using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.data.Models
{
    public class Customer
    {
        [Key]
        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string fName { get; set; }

        [Required]
        [StringLength(255)]
        public string lName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(500)]
        public string StreetName { get; set; }

        [Required]
        [StringLength(255)]
        public string City { get; set; }

        [Required]
        [StringLength(255)]
        public string State { get; set; }

        [Required]
        [StringLength(6)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(15)]
        public string Telephone { get; set; }

        [StringLength(500)]
        public string Password { get; set; }
    }
}
