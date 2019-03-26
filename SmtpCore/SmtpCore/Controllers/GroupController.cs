using Microsoft.AspNetCore.Mvc;
using SmtpEntities;
using SmtpModels;
using SmtpServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmtpCore.Controllers
{
    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        private IEmailService _emailServicel;

        public GroupController(ApplicationContext applicationContext, IEmailService emailService)
        {
            _emailServicel = emailService;
        }

        [HttpGet]
        public IEnumerable<Group> GetAllGroups()
        {
            return _emailServicel.GetAllGroups();
        }

    }
}
