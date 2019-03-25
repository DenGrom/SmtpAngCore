using System;
using System.Collections.Generic;
using System.Text;

namespace SmtpModels
{
    public class CreateEmailModel
    {
        public Email Email { get; set; }
        public int GroupId { get; set; }
    }
}
