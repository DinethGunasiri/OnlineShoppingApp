using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Data.IRepositories
{
    public interface IMailer
    {
        Task SendEmailAsync(string email, string subject, string body);
    }
}
