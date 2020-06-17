using Microsoft.EntityFrameworkCore;
using OnlineShopping.data.DataContext;
using OnlineShopping.data.Entities;
using OnlineShopping.data.Interfacses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.data.Functions
{
    public class CustomerFunction : ICustomer
    {
        public  async Task<Customer> AddCustomer(string email, string fname, string lname, DateTime birthDate, string gender, string address, byte zipCode, string telephone)
        {
            Customer newCustomer = new Customer
            {
                Email = email,
                fName = fname,
                lName = lname,
                BirthDate = birthDate,
                Gender = gender,
                Address = address,
                zipCode = zipCode,
                Telephone = telephone
            };

            using (var context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                await context.Customers.AddAsync(newCustomer);
                await context.SaveChangesAsync();
            }

            return newCustomer;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (var context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                customers = await context.Customers.ToListAsync();
            }

            return customers;
        }
    }
}
