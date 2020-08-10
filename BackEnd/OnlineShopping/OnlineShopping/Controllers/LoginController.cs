using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShoppind.business.Customer;
using OnlineShoppind.business.DTOs;

namespace OnlineShopping.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger _logger;

        public LoginController(ICustomerService customerService, ILogger<LoginController> logger)
        {
            this._customerService = customerService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Login([FromBody] CustomerDto UserLogin)
        {
            _logger.LogInformation("Start: Customer login");

            CustomerDto login = new CustomerDto();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(UserLogin.Password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);

            login = _customerService.Login(UserLogin.Email, hash);

            IActionResult responce = Unauthorized();

            System.Diagnostics.Debug.WriteLine(login);

            if (login != null)
            {
                var tokenStr = _customerService.GenerateJSONWebToken(login);
                responce = Ok(new { token = tokenStr });
            }

            _logger.LogInformation("Complete: Login complete", login, responce);
            return responce;
        }
    }
}
