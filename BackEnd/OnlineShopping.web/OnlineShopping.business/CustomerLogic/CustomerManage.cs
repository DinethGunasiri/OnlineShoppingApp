using OnlineShopping.data.Entities;
using OnlineShopping.data.Interfacses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineShopping.business.CustomerLogic
{
    public class CustomerManage
    {
        private ICustomer _customer =  new data.Functions.CustomerFunction();

     /*   public async Task<Boolean> CreateNewCustomer(string email, string fname, string lname, DateTime birthDate, string gender, string address, byte zipCode, string telephone)
        {
            try
            {
                var result = await _customer.AddCustomer(email, fname, lname, birthDate, gender, address, zipCode, telephone);

                if(result.Email != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
     */

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            try
            {
                var result = await _customer.AddCustomer(customer);

                if (result.Email != null)
                {
                    return customer;
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
            }
            catch(Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
        public async Task<List<Customer>> GetCustomers()
        {
            List<Customer> customers = await _customer.GetCustomers();
            return customers;
        }
    }
}
