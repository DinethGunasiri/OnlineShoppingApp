using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.web.Models
{
    public class CustomerViewModel
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string Telephone { get; set; }

       // public string Password { get; set; }
    }
}
