﻿using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
            [HttpGet]          
            [Route("/error-local-development")]
            public IActionResult ErrorLocalDevelopment(
                [FromServices] IWebHostEnvironment webHostEnvironment)
            {

                if (webHostEnvironment == null)
                {
                  throw new ArgumentNullException($"{webHostEnvironment}");
                }

                if (webHostEnvironment.EnvironmentName != "Development")
                {
                    throw new InvalidOperationException(
                        $"This shouldn't be invoked in non-development environments. {webHostEnvironment.EnvironmentName}");
                }

                var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

                return Problem(
                    detail: context.Error.StackTrace,
                    title: context.Error.Message);
            }

            [HttpGet]
            [Route("/error")]
            public IActionResult Error() => Problem();
        
    }
}
