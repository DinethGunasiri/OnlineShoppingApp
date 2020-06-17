using OnlineShopping.data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.data.Interfacses
{
    public interface ICustomer
    {
        Task<Customer> AddCustomer(string email, string fname, string lname, DateTime birthDate, string gender, string address, byte zipCode, string telephone);
        Task<List<Customer>> GetCustomers();
    }
}
