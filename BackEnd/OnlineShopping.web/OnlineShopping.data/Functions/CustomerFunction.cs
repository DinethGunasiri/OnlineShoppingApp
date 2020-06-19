using Microsoft.EntityFrameworkCore;
using OnlineShopping.data.DataContext;
using OnlineShopping.data.Entities;
using OnlineShopping.data.Interfacses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.data.Functions
{
    public class CustomerFunction : ICustomer
    {
        // Get all Customer
        public async Task<List<Customer>> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (var context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                customers = await context.Customers.ToListAsync();
            }

            return customers;
        }

        // Get Customer details
        public async Task<Customer> GetCustomer(string email)
        {
            var customer = new Customer();

            using (var context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                customer = await context.Customers.SingleOrDefaultAsync(c => c.Email == email);
            }
            return customer; 
        }

        // Add Customer
        public async Task<Customer> AddCustomer(Customer customer)
        {
            using(var context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                await context.Customers.AddAsync(customer);
                await context.SaveChangesAsync();
            }

            return customer;
        }

        // Edit Customer
        public async Task<Customer> EditCustomer(string email, Customer customer)
        {
            var customerDetails = customer;


            using (var context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                customerDetails = await context.Customers.SingleOrDefaultAsync(c => c.Email == email);

                if(customerDetails != null)
                {
                    customerDetails.FullName = customer.FullName;
                    customerDetails.Gender = customer.Gender;
                    customerDetails.Address = customer.Address;
                    customerDetails.ZipCode = customer.ZipCode;
                    customerDetails.Telephone = customer.Telephone;

                    await context.SaveChangesAsync();
                }

                
                

               // System.Diagnostics.Debug.WriteLine(customerDetails);

            }

            return customerDetails;

        }

        // Delete Customer
        public async Task<Customer> DeleteCustomer(string email)
        {
            var customer = new Customer();

            using (var context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                customer = await context.Customers.SingleOrDefaultAsync(c => c.Email == email);
               
                context.Customers.Remove(customer);
                await context.SaveChangesAsync();


            }

            return customer;
        }
    }
}
