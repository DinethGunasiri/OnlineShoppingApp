using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShoppind.business.Customer;
using OnlineShoppind.business.DTOs;

namespace OnlineShopping.Controllers
{
    
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerLogic;
        private readonly ILogger _logger;

        public CustomerController(ICustomerService logic, ILogger<CustomerController> logger)
        {
            this.customerLogic = logic;
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            _logger.LogInformation("Start: Getting customer details");

            IEnumerable<CustomerDto> customer = new List<CustomerDto>();
            customer = customerLogic.GetCustomers();

            _logger.LogInformation("Complete: Customers", customer);

            return customer;
        }

        [HttpGet]
        [Route("{email}")]
        public CustomerDto GetCustomer(string email)
        {
            _logger.LogInformation("Start: Getting customer details by email");

            CustomerDto customer = customerLogic.GetCustmerByEmail(email);

            _logger.LogInformation("Complete: Customer", email, customer);

            return customer;
        }

        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customer)
        {
            _logger.LogInformation("Start: Create customer");

            CustomerDto customerDto = customerLogic.InsertCustomer(customer);

            _logger.LogInformation("Complete: Create customer", customerDto);

            return customerDto;
        }

        [Authorize]
        [HttpPut]
        [Route("{email}")]
        public CustomerDto EditCustomer(string email, CustomerDto customer)
        {
            _logger.LogInformation("Start: Editing customer details");
            CustomerDto customerDto = customerLogic.UpdateCustomer(email, customer);

            _logger.LogInformation("Complete: Edit customer details", email, customer);
            return customerDto;
        }


        [Authorize]
        [HttpDelete]
        [Route("{email}")]
        public void DeleteCustomer(string email)
        {
            _logger.LogInformation("Start: Deleteing customer details");
            customerLogic.RemoveCustomer(email);

            _logger.LogInformation("Complete: Delete customer details", email);
        }
    }
}
