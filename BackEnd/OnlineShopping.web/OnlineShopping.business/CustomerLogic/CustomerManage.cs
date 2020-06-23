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
        private ICustomer _customer =  new data.Functions.CustomerFunction();

        // Get all Customer
        public async Task<List<Customer>> GetCustomers()
        {
            try
            {
                List<Customer> customers = await _customer.GetCustomers();

                if(customers == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    return customers;
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }            
        }

        // Get Customer by email
        public async Task<Customer> GetCustomer(string Email)
        {
            try
            {
                var customer = await _customer.GetCustomer(Email);

                if (customer == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    return customer;
                }
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }          
        }

        // Create Customer
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            try
            {
                var result = await _customer.AddCustomer(customer);

                if(result == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                else
                {
                    return result;
                }

            }
            catch(Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        // Edit Customer
        public async Task<Customer> EditCustomer(string email, Customer customer)
        {

            try
            {
                var customerDetails = await _customer.EditCustomer(email, customer);

                if (customerDetails == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {

                    return customerDetails;

                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // Delete Customer

        public async Task<Customer> DeleteCustomer(string email)
        {
            try
            {
                var customer = await _customer.DeleteCustomer(email);

                if (customer == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    return customer;
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }


    }
}
