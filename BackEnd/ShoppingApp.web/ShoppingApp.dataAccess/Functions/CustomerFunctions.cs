using Microsoft.EntityFrameworkCore;
using ShoppingApp.common;
using ShoppingApp.dataAccess.DataContext;
using ShoppingApp.dataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.dataAccess.Functions
{
    public class CustomerFunctions : ICustomer
    {
        // ADD A NEW CUSTOMER
        public async Task<Customer> AddCustomer(string email, string fname, string lname, DateTime birthDate, string gender, string address, byte zipCode, string telephone)
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

        // GET ALL CUSTOMERS
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
