using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmtpServices.Contracts
{
    public interface IEmailService
    {
        Task<bool> SendAdminEmails();
        Task<bool> SendUserEmails();
    }
}
