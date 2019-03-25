using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SmtpCore.Common;
using SmtpEntities;
using SmtpModels;
using SmtpServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmtpCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private IHubContext<ChartHub> _hub;
        private QuartzStartup _quartzStartup;
        private EmailService _emailService;

        public ChartController(IHubContext<ChartHub> hub, ApplicationContext applicationContext)
        {
            _hub = hub;
            _quartzStartup = new QuartzStartup();
            _emailService = new EmailService(applicationContext);
        }

        public IActionResult Get()
        {
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData()));

            return Ok(new { Message = "Request Completed" });
        }

        //public IActionResult CreateEmail(CreateEmailModel createEmailModel)
        //{
        //    _emailService.CreateEmail(createEmailModel);
        //    return Ok(new { Message = "Request Completed" });
        //}

        //public IActionResult RunJobEmail(int emailId)
        //{
        //    _quartzStartup.Start(emailId);
        //    //var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData()));

        //    return Ok(new { Message = "RunJob" });
        //}
    }
}
