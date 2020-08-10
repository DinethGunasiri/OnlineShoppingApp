using Microsoft.EntityFrameworkCore;
using OnlineShopping.data.IRepositories;
using OnlineShopping.data.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopping.data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
       // protected readonly ShoppingContext context;

        public CustomerRepository(ShoppingContext context) : base(context)
        {
            // this.context = context;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }

        public Customer GetCustmerByEmail(string Email)
        {
            return context.Customers.Find(Email);
        }

        public Customer InsertCustomer(Customer customer)
        {
            return context.Customers.Add(customer).Entity;
            // return customer;
        }

        public void RemoveCustomer(string Email)
        {
            Customer customer = context.Customers.Find(Email);
            context.Customers.Remove(customer);
        }

        public Customer UpdateCustomer(Customer customer)
        {
           context.Entry(customer).State = EntityState.Modified;

            return context.Entry(customer).Entity;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
