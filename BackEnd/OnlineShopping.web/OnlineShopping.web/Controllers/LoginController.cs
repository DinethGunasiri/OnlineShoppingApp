using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineShopping.business.CustomerLogic;
using OnlineShopping.data.Entities;
using OnlineShopping.web.Models;

namespace OnlineShopping.web.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private CustomerManage cManage = new CustomerManage();

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginModel UserLogin)
        {
            Customer login = new Customer();

            byte[] data = System.Text.Encoding.ASCII.GetBytes(UserLogin.Password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);

            var encriptPassword = hash;

            login.Email = UserLogin.Email;
            login.Password = hash;
            IActionResult responce = Unauthorized();

            Customer user = await AuthenticateUser(login);

            if(user != null)
            {
                var tokenStr = GenerateJSONWebToken(user);
                responce = Ok(new { token = tokenStr });
            }

            return responce;

        }
        
        public async Task<Customer> AuthenticateUser(Customer login)
        {
            Customer customer = new Customer();

            if (login.Email != null && login.Password != null)
            {

                Customer customer2 = await cManage.GetCustomer(login.Email);

                if (customer2.Password != null)
                {
                    if (login.Email == customer2.Email && login.Password == customer2.Password)
                    {
                        System.Diagnostics.Debug.WriteLine(login.Email);
                        customer = new Customer { Email = customer2.Email, Password = customer2.Password, FullName = customer2.FullName, BirthDate = customer2.BirthDate, Gender = customer2.Gender, Address = customer2.Address, ZipCode = customer2.ZipCode, Telephone = customer2.Telephone };
                    }
                }

                return customer;
            }

            return customer;
        }



        private async Task<String> GenerateJSONWebToken(Customer customerInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, customerInfo.FullName),
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
