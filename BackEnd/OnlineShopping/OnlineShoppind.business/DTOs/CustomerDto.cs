using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppind.business.DTOs
{
    public class CustomerDto
    {
        public string Email { get; set; }

        public string fName { get; set; }

        public string lName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string StreetName { get; set; }

        public string City { get; set; }

        public string State { get; set; }


        public string ZipCode { get; set; }

        public string Telephone { get; set; }

        public string Password { get; set; }

    }
}
