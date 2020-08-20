using OnlineShopping.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
    public class Mailer : IMailer
    {
        public async Task SendEmailAsync(string email, string subject, string body)
        {
            await Task.CompletedTask.ConfigureAwait(false);
        }
    }
}
