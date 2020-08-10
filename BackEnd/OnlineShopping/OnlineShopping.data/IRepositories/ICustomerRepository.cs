using OnlineShopping.data.Models;
using System.Collections.Generic;

namespace OnlineShopping.data.IRepositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustmerByEmail(string Email);
        Customer InsertCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        void RemoveCustomer(string Email);
        void Save();
        
    }
}
