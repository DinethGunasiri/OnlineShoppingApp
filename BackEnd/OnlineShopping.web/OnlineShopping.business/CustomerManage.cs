using OnlineShopping.data.DataContext;
using OnlineShopping.data.Entities;
using OnlineShopping.data.Interfacses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;

namespace OnlineShopping.business.CustomerLogic
{
    public class CustomerManage
    {
        readonly ICustomer _custDataAccess;

        public CustomerManage()
        {
            _custDataAccess = CustomerAccessFactory.GetCustomerDataAccessObj();
        }

        // Get all Customer
        public async Task<List<Customer>> GetCustomers()
        {
            List<Customer> customers = await _custDataAccess.GetCustomers().ConfigureAwait(false);

            return customers;
                   
        }

        // Get Customer by email
        public async Task<Customer> GetCustomer(string Email)
        {
            
            var customer = await _custDataAccess.GetCustomer(Email).ConfigureAwait(false);

            return customer;
                 
        }

        // Create Customer
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            if (customer != null)
            {
                var password = customer.Password;
                byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                String hash = System.Text.Encoding.ASCII.GetString(data);

                System.Diagnostics.Debug.WriteLine(hash);

                customer.Password = hash;
            }



            var result = await _custDataAccess.AddCustomer(customer).ConfigureAwait(false);

            return result;
                       
        }

        // Edit Customer
        public async Task<Customer> EditCustomer(string email, Customer customer)
        {

          
            var customerDetails = await _custDataAccess.EditCustomer(email, customer).ConfigureAwait(false);

            return customerDetails;
        }

        // Delete Customer

        public async Task<Customer> DeleteCustomer(string email)
        {
           
            var customer = await _custDataAccess.DeleteCustomer(email).ConfigureAwait(false);

            return customer;
        }

        // Check Customer

        public async Task<Customer> CheckCustomer(string email)
        {
            var customer = await _custDataAccess.CheckCustomer(email);

            return customer;
        }


    }
}
