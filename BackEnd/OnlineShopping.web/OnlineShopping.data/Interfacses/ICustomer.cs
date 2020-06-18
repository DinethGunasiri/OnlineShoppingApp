using OnlineShopping.data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.data.Interfacses
{
    public interface ICustomer
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomer(string email);
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> EditCustomer(string email, Customer customer);
        Task<Customer> DeleteCustomer(string email);
        
    }
}
