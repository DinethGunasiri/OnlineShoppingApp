using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.web.Models
{
    public class CustomerViewModel
    {
            public string Email { get; set; }

            public string fName { get; set; }

            public string lName { get; set; }

            public DateTime BirthDate { get; set; }

            public string Gender { get; set; }

            public string Address { get; set; }

            public int zipCode { get; set; }

            public string Telephone { get; set; }
     
    }
}
