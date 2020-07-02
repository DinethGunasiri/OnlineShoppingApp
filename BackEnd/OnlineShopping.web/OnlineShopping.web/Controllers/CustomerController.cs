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
        private CustomerManage cManage = new CustomerManage();

        [Authorize]
        [Route("all")]
        [HttpGet]
        public async Task<List<CustomerViewModel>> GetCustomers()
        {
            List<CustomerViewModel> customerList = new List<CustomerViewModel>();
            var customers = await cManage.GetCustomers();

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
        [Route("email/{email}")]
        [HttpGet]
        public async Task<Customer> GetCustomer(string email)
        {
            return await cManage.GetCustomer(email);
        }

       
        [Route("new")]
        [HttpPost]
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            return await cManage.CreateCustomer(customer);
            
        }

        [Authorize]
        [Route("edit/{email}")]
        [HttpPut]
        public async Task<Customer> EditCustomer(string email, Customer customer)
        {
            return await cManage.EditCustomer(email, customer);
        }

        [Authorize]
        [Route("delete/{email}")]
        [HttpDelete]
        public async Task<Customer> DeleteCustomer(string email)
        {
            return await cManage.DeleteCustomer(email);
        }

    }
}
