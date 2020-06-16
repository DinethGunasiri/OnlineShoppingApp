using ShoppingApp.common;
using ShoppingApp.dataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.business
{
    public class CustomerManage
    {
        private ICustomer _customer = new dataAccess.Functions.CustomerFunctions();

        // ADD CUSTOMER
        public async Task<Boolean> CreateCustomer(string email, string fname, string lname, DateTime birthDate, string gender, string address, byte zipCode, string telephone)
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
            catch (Exception error)
            {
                return false;
            }
        }

        //  GET ALL CUSTOMERS
        public async Task<List<Customer>> GetCustomers()
        {
            List<Customer> customers = await _customer.GetCustomers();
            return customers;
        }
    }
}
