using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Data.Models
{
    public class HttpResponseException: Exception
    {
        public int Status { get; set; } = 500;
        public object Value { get; set; }

        public HttpResponseException(string message) : base(message)
        {
        }

        public HttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public HttpResponseException()
        {
        }
    }
}
