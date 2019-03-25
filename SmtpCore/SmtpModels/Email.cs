using SmtpEntities.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmtpModels
{
    public class Email
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public EmailStatus EmailStatus { get; set; }
        public bool IsActive { get; set; }
    }
}
