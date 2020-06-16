using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using ShoppingApp.business;
using ShoppingApp.common;
using ShoppingApp.dataAccess.DataContext;
using ShoppingApp.web.Models;

namespace ShoppingApp.web.Controllers
{
    [Route("api/customer/")]
    [ApiController]
    public class Customer_Controller : ControllerBase
    {
        private CustomerManage CManage = new CustomerManage();

        [Route("all")]
        [HttpGet]
        public async Task<List<CustomerViewModel>> GetAllCustomers()
        {
            List<CustomerViewModel> customersList = new List<CustomerViewModel>();
            var customers = await CManage.GetCustomers();

            if(customers.Count > 0 )
            {
                foreach (var customer in customers)
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
                    customersList.Add(currentCustomer);
                }
            }

            return customersList;
        }
    }
}
