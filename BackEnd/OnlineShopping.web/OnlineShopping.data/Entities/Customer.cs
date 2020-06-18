using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShopping.data.Entities
{
    public class Customer
    {
        [Key]
        [Required]
        [StringLength(255)]
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
        [StringLength(2000)]
        public string Address { get; set; }

        [Required]
        public int zipCode { get; set; }

        [Required]
        [StringLength(15)]
        public string Telephone { get; set; }

        [StringLength(20)]
        public string Password { get; set; }
    }
}
