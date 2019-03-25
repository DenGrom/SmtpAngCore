using Microsoft.AspNetCore.SignalR;
using SchedulerLib;
//using Quartz;
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
        public int Id { get; set; }
        public JobExecutionStatus Status { get; set; }
        public int ScheduleId { get; set; }

        //private IHubContext<ChartHub> _hub;

        //public SendUserEmailsJob(IHubContext<ChartHub> hub)
        //{
        //    _hub = hub;
        //}

        //public async Task Execute(IJobExecutionContext context)
        //{
        //    IEmailService emailService = new EmailService();
        //    var isSent = await emailService.SendUserEmails();
        //    await Task.CompletedTask;
        //}

        public void Execute()
        {
            //IEmailService emailService = new EmailService();
            //var isSent = emailService.SendUserEmails();
        }
    }
}
