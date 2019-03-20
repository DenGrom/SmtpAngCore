using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmtpCore.Common
{
    public class EchoHub : Hub
    {
        public EchoHub(string message)
        {
            Clients.All.SendAsync("Send", message);
        }
    }
}
