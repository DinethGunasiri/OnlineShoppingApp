using OnlineShoppind.business.DTOs;
using OnlineShopping.data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppind.business.Customer
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetCustomers();
        CustomerDto GetCustmerByEmail(string Email);
        CustomerDto InsertCustomer(CustomerDto customer);
        CustomerDto UpdateCustomer(string email, CustomerDto customer);
        void RemoveCustomer(string Email);
        CustomerDto Login(string Email, string password);
        CustomerDto AuthenticateUser(CustomerDto login);
        String GenerateJSONWebToken(CustomerDto customer);
    }
}
