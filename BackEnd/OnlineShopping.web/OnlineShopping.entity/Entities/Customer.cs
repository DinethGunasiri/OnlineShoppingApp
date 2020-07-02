using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShopping.data.Entities
{
    public class Customer //: IdentityUser
    {
        [Key]
        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        [Required]
        [StringLength(500)]
        public string FullName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        [StringLength(2000)]
        public string Address { get; set; }

        [Required]
        [StringLength(6)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(15)]
        public string Telephone { get; set; }

        [StringLength(20)]
        public string Password { get; set; }
    }
}
