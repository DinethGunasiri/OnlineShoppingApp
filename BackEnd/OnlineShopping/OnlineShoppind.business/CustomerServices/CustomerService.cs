using OnlineShoppind.business.Customer;
using OnlineShoppind.business.DTOs;
using OnlineShopping.data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace OnlineShoppind.business
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._config = config;
        }

        // Get customer details by email
        public CustomerDto GetCustmerByEmail(string Email)
        {
            var customerDetails = unitOfWork.Customer.GetCustmerByEmail(Email);

            if (customerDetails != null)
            {
                CustomerDto customer = new CustomerDto
                {
                    Address = customerDetails.Address,
                    BirthDate = customerDetails.BirthDate,
                    City = customerDetails.City,
                    Email = customerDetails.Email,
                    fName = customerDetails.fName,
                    Gender = customerDetails.Gender,
                    lName = customerDetails.lName,
                    Password = customerDetails.Password,
                    State = customerDetails.State,
                    StreetName = customerDetails.StreetName,
                    Telephone = customerDetails.Telephone,
                    ZipCode = customerDetails.ZipCode
                };
                return customer;
            }
            else
            {
                return null;
            }
            
        }

        // Get all customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            List<CustomerDto> customersList = new List<CustomerDto>();
            var customers =  unitOfWork.Customer.GetCustomers().ToList();
            
            foreach (var customer in customers)
            {
                CustomerDto customerDto = new CustomerDto
                {
                    BirthDate = customer.BirthDate,
                    Email = customer.Email,
                    fName = customer.fName,
                    lName = customer.lName,
                    Gender = customer.Gender,
                    Password = customer.Password,
                    Telephone = customer.Telephone,
                    Address = customer.Address,
                    StreetName = customer.StreetName,
                    City = customer.City,
                    State = customer.State,
                    ZipCode = customer.ZipCode
                };
                customersList.Add(customerDto);
            }
            return customersList;
        }

        // Insert customer to database
        public CustomerDto InsertCustomer(CustomerDto customers)
        {

            if (customers != null)
            {
                var password = customers.Password;
                byte[] data = Encoding.ASCII.GetBytes(password);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                String hash = Encoding.ASCII.GetString(data);

                System.Diagnostics.Debug.WriteLine(hash);

                customers.Password = hash;
            }

            var customer = _mapper.Map<OnlineShopping.data.Models.Customer>(customers);

            unitOfWork.Customer.InsertCustomer(customer);
            unitOfWork.SaveChanges();

            return customers;
        }

        // Delete customer from database
        public void RemoveCustomer(string Email)
        {
            unitOfWork.Customer.GetCustmerByEmail(Email);

            unitOfWork.Customer.RemoveCustomer(Email);
            unitOfWork.SaveChanges();
        }

        // Edit customer using email
        public CustomerDto UpdateCustomer(string Email, CustomerDto newCustomer)
        {
            if (Email == null || newCustomer == null)
            {
                throw new ArgumentNullException($"{Email} null", $"{newCustomer} null");
            }

            var customerDetails = unitOfWork.Customer.GetCustmerByEmail(Email);

             
                var password = newCustomer.Password;

                byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                String hash = System.Text.Encoding.ASCII.GetString(data);

                System.Diagnostics.Debug.WriteLine(hash);

             //   newCustomer.Password = hash;

            customerDetails.BirthDate = newCustomer.BirthDate;
            customerDetails.Email = newCustomer.Email;
            customerDetails.fName = newCustomer.fName;
            customerDetails.Gender = newCustomer.Gender;
            customerDetails.Password = hash;
            customerDetails.Telephone = newCustomer.Telephone;
            customerDetails.Address = newCustomer.Address;
            customerDetails.StreetName = newCustomer.StreetName;
            customerDetails.City = newCustomer.City;
            customerDetails.State = newCustomer.State;
            customerDetails.ZipCode = newCustomer.ZipCode;

            unitOfWork.Customer.Update(customerDetails);
            unitOfWork.SaveChanges();

            return newCustomer;

        }

        // Login customer logic
        public CustomerDto Login(string Email, string password)
        {
            CustomerDto login = new CustomerDto
            {
                Email = Email,
                Password = password
            };
            var user = AuthenticateUser(login);

            return user;

        }

        // User authentication
        public CustomerDto AuthenticateUser(CustomerDto login)
        {
            if (login == null)
            {
                throw new ArgumentNullException($"{login} is null");
            }

            CustomerDto customer = new CustomerDto();

            if (login.Email != null && login.Password != null)
            {
                var customer2 = unitOfWork.Customer.GetCustmerByEmail(login.Email);

                if (customer2 == null)
                {
                    customer = null;
                }
                else
                {
                    if (customer2.Password != null)
                    {
                        if (login.Email == customer2.Email && login.Password == customer2.Password)
                        {
                            System.Diagnostics.Debug.WriteLine(login.Email);
                            customer = new CustomerDto { Email = customer2.Email, Password = customer2.Password, fName = customer2.fName, lName = customer2.lName, BirthDate = customer2.BirthDate, Gender = customer2.Gender, Address = customer2.Address, StreetName = customer2.StreetName, City = customer2.City, State = customer2.State, ZipCode = customer2.ZipCode, Telephone = customer2.Telephone };
                        }
                        else
                        {
                            customer = null;
                        }
                    }

                }
                return customer;
              
            }

            return customer;
        }

        // Genarate JSON Web Token 
        public string GenerateJSONWebToken(CustomerDto customerInfo)
        {
            if (customerInfo == null)
            {
                throw new ArgumentException($"{customerInfo} is null");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, customerInfo.fName),
                new Claim(JwtRegisteredClaimNames.Sub, customerInfo.lName),
                new Claim(JwtRegisteredClaimNames.Email, customerInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
    }
}
