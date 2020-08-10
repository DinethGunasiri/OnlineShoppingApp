using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineShoppind.business;
using OnlineShoppind.business.DTOs;
using OnlineShopping.data.Models;
using OnlineShopping.data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class CustomerTest
    {
        private  CustomerService _customerService;
        private  Mock<IUnitOfWork> unitOfWork;
        private  Mock<IMapper> _mapper;
        private  Mock<IConfiguration> _config;

        [TestInitialize]
        public  void Setup()
        {
            _mapper = new Mock<IMapper>();
            unitOfWork = new Mock<IUnitOfWork>();
            _config = new Mock<IConfiguration>();

            _customerService = new CustomerService(unitOfWork.Object, _mapper.Object, _config.Object);
        }



        [TestMethod]
        public void GetCustomersLengthShouldGreaterThanZero()
        {
            // Arrange

            var returnList = GetCustomerList();
            unitOfWork.Setup(x => x.Customer.GetCustomers()).Returns(returnList);

            // Act

            var result = _customerService.GetCustomers();

            // Assert

            Assert.AreEqual(3, result.Count());

        }

        [TestMethod]
        public void GetCustomersReturnTypeShouldCustomerDto()
        {
            // Arrange 

            var returnList = GetCustomerList();

            unitOfWork.Setup(x => x.Customer.GetCustomers()).Returns(returnList);

            // Act

            var result = _customerService.GetCustomers();

            // Assert

            Assert.AreEqual(typeof(List<CustomerDto>), result.GetType());

        }

        [TestMethod]
        public void GetCustomersByEmailShouldReturnCustomerDetails()
        {
            // Arrange 

            var returnList = GetCustomerList();

            unitOfWork.Setup(x => x.Customer.GetCustmerByEmail("dineth@gmail.com")).Returns(returnList.Find(e => e.Email == "dineth@gmail.com"));

            // Act

            var result = _customerService.GetCustmerByEmail("dineth@gmail.com");

            // Assert
            Assert.AreEqual("dineth@gmail.com", result.Email);
            Assert.AreEqual("54/2A, Mihindu Mawatha, Malwaththa", result.Address);
            Assert.AreEqual(DateTime.Today, result.BirthDate);
            Assert.AreEqual("Dineth", result.fName);
            Assert.AreEqual("Gunasiri", result.lName);
            Assert.AreEqual("Male", result.Gender);
            Assert.AreEqual("1234", result.Password);
            Assert.AreEqual("0719954674", result.Telephone);
            Assert.AreEqual("11554", result.ZipCode);
        }

        [TestMethod]
        public void InsertCustomerShouldReturnCustomerDetails()
        {
            // Arrange

            var returnList = GetCustomerList();

            Customer customer = new Customer
            {
                Email = "mike@gmail.com",
                Address = "New York, Ammerica",
                BirthDate = DateTime.Today,
                fName = "Mike",
                lName = "Stain",
                Gender = "Male",
                Password = "4321",
                Telephone = "0112569524",
                ZipCode = "11547"
            };

            CustomerDto customerDto = new CustomerDto
            {
                Email = "mike@gmail.com",
                Address = "New York, Ammerica",
                BirthDate = DateTime.Today,
                fName = "Mike",
                lName= "Stain",
                Gender = "Male",
                Password = "4321",
                Telephone = "0112569524",
                ZipCode = "11547"
            };

            // Act

            unitOfWork.Setup(x => x.Customer.InsertCustomer(customer)).Returns(customer);
            var result = _customerService.InsertCustomer(customerDto);

            // Assert
            Assert.AreEqual("mike@gmail.com", result.Email);
            Assert.AreEqual("New York, Ammerica", result.Address);
            Assert.AreEqual(DateTime.Today, result.BirthDate);
            Assert.AreEqual("Mike", result.fName);
            Assert.AreEqual("Stain", result.lName);
            Assert.AreEqual("Male", result.Gender);
            Assert.AreEqual("0112569524", result.Telephone);
            Assert.AreEqual("11547", result.ZipCode);

        }

        [TestMethod]
        public void UpdateCustomerShouldReturnUpdatedData()
        {

            // Arrange 

            Customer customer = new Customer
            {
                Email = "dineth@gmail.com",
                Address = "54/2A, Mihindu Mawatha, Malwaththa",
                BirthDate = DateTime.Today,
                fName = "Dineth Lahiru",
                lName = "Gunasiri",
                Gender = "Male",
                Password = "1234",
                Telephone = "0332293310",
                ZipCode = "11554"
            };

            CustomerDto customerDto = new CustomerDto
            {
                Email = "dineth@gmail.com",
                Address = "54/2A, Mihindu Mawatha, Malwaththa",
                BirthDate = DateTime.Today,
                fName = "Dineth Lahiru",
                lName = "Gunasiri",
                Gender = "Male",
                Password = "1234",
                Telephone = "0332293310",
                ZipCode = "11554"
            };


            var returnList = GetCustomerList();


            unitOfWork.Setup(c => c.Customer.UpdateCustomer(customer));
            unitOfWork.Setup(c => c.Customer.GetCustmerByEmail(customer.Email)).Returns(returnList.Find(c => c.Email == customer.Email));

            // Act

            var result = _customerService.UpdateCustomer(customerDto.Email, customerDto);

            // Assert

            Assert.AreEqual("Dineth Lahiru", result.fName);
            Assert.AreEqual("Gunasiri", result.lName);
            Assert.AreEqual("0332293310", result.Telephone);
        }


        [TestMethod]
        public void DeleteCustomerShouldSuccess()
        {

            // Arrange

            Customer customer = new Customer
            {
                Email = "dineth@gmail.com",
                Address = "54/2A, Mihindu Mawatha, Malwaththa",
                BirthDate = DateTime.Today,
                fName = "Dineth Lahiru",
                lName = "Gunasiri",
                Gender = "Male",
                Password = "1234",
                Telephone = "0332293310",
                ZipCode = "11554"
            };

            CustomerDto customerDto = new CustomerDto
            {
                Email = "dineth@gmail.com",
                Address = "54/2A, Mihindu Mawatha, Malwaththa",
                BirthDate = DateTime.Today,
                fName = "Dineth Lahiru",
                lName = "Gunasiri",
                Gender = "Male",
                Password = "1234",
                Telephone = "0332293310",
                ZipCode = "11554"
            };

            // Act

            var returnList = GetCustomerList();

            unitOfWork.Setup(c => c.Customer.RemoveCustomer(customer.Email)).Verifiable();

            _customerService.RemoveCustomer(customerDto.Email);
            
            // Assert

            Assert.IsTrue(true);
        }


        private List<Customer> GetCustomerList()
        {
            var returnList = new List<Customer>()
            {
                new Customer
                {
                    Email = "dineth@gmail.com",
                    Address = "54/2A, Mihindu Mawatha, Malwaththa",
                    BirthDate = DateTime.Today,
                    fName = "Dineth",
                    lName = "Gunasiri",
                    Gender = "Male",
                    Password = "1234",
                    Telephone = "0719954674",
                    ZipCode = "11554"
                },
                new Customer
                {
                    Email = "hirun@gmail.com",
                    Address = "54/2A, Mihindu Mawatha, Malwaththa",
                    BirthDate = DateTime.Today,
                    fName = "Hirun",
                    lName = "Prabodhya",
                    Gender = "Male",
                    Password = "1234",
                    Telephone = "03322933104",
                    ZipCode = "11554"
                },
                new Customer
                {
                    Email = "sam@gmail.com",
                    Address = "Ohayo, USA",
                    BirthDate = DateTime.Today,
                    fName = "Sam",
                    lName = "Vice",
                    Gender = "Male",
                    Password = "4321",
                    Telephone = "0775265214",
                    ZipCode = "15220"
                }
            };

            return returnList;
        }

    }
}
