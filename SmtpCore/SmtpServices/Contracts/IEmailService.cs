using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SmtpModels;

namespace SmtpServices.Contracts
{
    public interface IEmailService
    {
        Task<bool> SendAdminEmails();
        Task<bool> SendUserEmails();
        List<Group> GetAllGroups();
    }
}
