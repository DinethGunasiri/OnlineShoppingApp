using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
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
                        fName = customer.fName,
                        lName = customer.lName,
                        BirthDate = customer.BirthDate,
                        Gender = customer.Gender,
                        Address = customer.Address,
                        zipCode = customer.zipCode,
                        Telephone = customer.Telephone
                    };
                    customerList.Add(currentCustomer);
                }
            }

            return customerList;

        }

      /*  [HttpPost]
        public async Task<Boolean> AddUser(string email, string fname, string lname, DateTime birthDate, string gender, string address, byte zipCode, string telephone)
        {
            bool result = await cManage.CreateNewCustomer(email, fname, lname, birthDate, gender, address, zipCode, telephone);
            return result;
        } */


        [HttpPost]
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            return await cManage.CreateCustomer(customer);
            
        }

    }
}
