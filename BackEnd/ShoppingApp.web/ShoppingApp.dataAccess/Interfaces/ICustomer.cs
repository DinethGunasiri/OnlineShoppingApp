using ShoppingApp.common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.dataAccess.Interfaces
{
    public interface ICustomer
    {
        Task<Customer> AddCustomer(string email, string fname, string lname, DateTime birthDate, string gender, string address, byte zipCode, string telephone);
        Task<List<Customer>> GetCustomers();
    }
}
