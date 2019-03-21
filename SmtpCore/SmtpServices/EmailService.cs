using SmtpServices.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmtpServices
{
    public class EmailService : IEmailService
    {
        public EmailService()
        {

        }
        async Task<bool> IEmailService.SendAdminEmails()
        {
            return await new Task<bool>(() => true);
        }

        async Task<bool> IEmailService.SendUserEmails()
        {
            return await new Task<bool>(() => true);
        }
    }
}
