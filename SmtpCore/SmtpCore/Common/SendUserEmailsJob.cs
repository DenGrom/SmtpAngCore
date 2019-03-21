using Microsoft.AspNetCore.SignalR;
using Quartz;
using SmtpModels;
using SmtpServices;
using SmtpServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmtpCore.Common
{
    public class SendUserEmailsJob : IJob
    {
        //private IHubContext<ChartHub> _hub;

        //public SendUserEmailsJob(IHubContext<ChartHub> hub)
        //{
        //    _hub = hub;
        //}

        public async Task Execute(IJobExecutionContext context)
        {
            IEmailService emailService = new EmailService();
            var isSent = await emailService.SendUserEmails();
            await Task.CompletedTask;
        }
    }
}
