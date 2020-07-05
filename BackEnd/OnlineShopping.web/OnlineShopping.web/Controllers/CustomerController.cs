using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.business.CustomerLogic;
using OnlineShopping.data.Entities;
using OnlineShopping.web.Models;

namespace OnlineShopping.web.Controllers
{
    
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerManage _customerManage; // = new CustomerManage();

        public CustomerController()
        {
            _customerManage = new CustomerManage();
        }

        [Authorize]
        [HttpGet]
        public async Task<List<CustomerViewModel>> GetCustomers()
        {
            List<CustomerViewModel> customerList = new List<CustomerViewModel>();
            var customers = await _customerManage.GetCustomers().ConfigureAwait(false);

            if(customers.Count > 0)
            {
                foreach(var customer in customers)
                {
                    CustomerViewModel currentCustomer = new CustomerViewModel
                    {
                        Email = customer.Email,
                        FullName = customer.FullName,
                        BirthDate = customer.BirthDate,
                        Gender = customer.Gender,
                        Address = customer.Address,
                        ZipCode = customer.ZipCode,
                        Telephone = customer.Telephone
                      //  Password = customer.Password
                    };
                    customerList.Add(currentCustomer);
                }
            }

            return customerList;

        }

        [Authorize]
        [Route("{email}")]
        [HttpGet]
        public async Task<Customer> GetCustomer(string email)
        {
            return await _customerManage.GetCustomer(email).ConfigureAwait(false);
        }

       
        [HttpPost]
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            return await _customerManage.CreateCustomer(customer).ConfigureAwait(false);
            
        }

        [Authorize]
        [Route("{email}")]
        [HttpPut]
        public async Task<Customer> EditCustomer(string email, Customer customer)
        {
            return await _customerManage.EditCustomer(email, customer).ConfigureAwait(false);
        }

        [Authorize]
        [Route("{email}")]
        [HttpDelete]
        public async Task<Customer> DeleteCustomer(string email)
        {
            return await _customerManage.DeleteCustomer(email).ConfigureAwait(false);
        }

        [Route("check/{email}")]
        [HttpGet]
        public async Task<Customer> CheckCustomer(string email)
        {
            var customer = await _customerManage.CheckCustomer(email).ConfigureAwait(false);

            if (customer != null)
            {
                return customer;
            }
            else
            {
                return null;
            }
        }

    }
}
