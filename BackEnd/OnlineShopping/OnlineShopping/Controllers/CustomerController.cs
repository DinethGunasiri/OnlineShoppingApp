using System;
using System.Collections.Generic;
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
            _logger = logger;
        }

        // Get customers
        [Authorize]
        [HttpGet]
        public IEnumerable<CustomerDto> GetCustomers()
        {       
            IEnumerable<CustomerDto> customer = new List<CustomerDto>();

           
                _logger.LogInformation($"Start: Getting customer details {customer}");

                customer = customerLogic.GetCustomers();

            if (customer == null)
            {
                _logger.LogError($"Cannot get Customers {customer}");

                throw new ArgumentException($"Cannot get all customers from database. {customer} is null");
            }

                _logger.LogInformation($"Complete: Customers {customer}");

                return customer;

                
            
        }

        // Get customer by email
        [HttpGet]
        [Route("{email}")]
        public IActionResult GetCustomer(string email)
        {
               

            
           _logger.LogInformation($"Start: Getting customer details by email {email}");

           CustomerDto customer = customerLogic.GetCustmerByEmail(email);
               
           if(customer == null)
           {
              _logger.LogError($"Somthing went wrong in GetCustomer by email: {email}");
                throw new ArgumentException($"Cannot get customer details by email {email}", nameof(email));
              
           }

            _logger.LogInformation($"Complete: Customer {email}, {customer}");

            return Ok(customer);

        }
        
        // Create new customer
        [HttpPost]
        public IActionResult CreateCustomer(CustomerDto customer)
        {
            _logger.LogInformation($"Start: Create customer {customer}");

            CustomerDto customerDto = customerLogic.InsertCustomer(customer);

            if (customerDto == null)
            {
                _logger.LogInformation($"Somthing went wrong in CreateCustomer {customer}");
                throw new ArgumentException($"Cannot save Customer details {customer}");
            }

            _logger.LogInformation($"Complete: Create customer {customerDto}");

            return Ok(customerDto);
        }

        // Edit customer
        [Authorize]
        [HttpPut]
        [Route("{email}")]
        public IActionResult EditCustomer(string email, CustomerDto customer)
        {
            _logger.LogInformation($"Start: Editing customer details {email}");
            CustomerDto customerDto = customerLogic.UpdateCustomer(email, customer);

            if (customerDto == null)
            {
                _logger.LogInformation($"Somthing went wrong in EditCustomer {email}, {customer}");
                throw new ArgumentException($"Error in Customre edit {email}, {customer}", nameof(customer));
            }

            _logger.LogInformation($"Complete: Edit customer details {email}, {customer}");
            return Ok(customerDto);
        }

        // Delete customer
        [Authorize]
        [HttpDelete]
        [Route("{email}")]
        public void DeleteCustomer(string email)
        {
            _logger.LogInformation($"Start: Deleteing customer details {email}");
            customerLogic.RemoveCustomer(email);

            _logger.LogInformation($"Complete: Delete customer details {email}");
        }
    }
}
