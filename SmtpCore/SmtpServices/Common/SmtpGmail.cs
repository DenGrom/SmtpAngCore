using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SmtpServices.Common
{
    public class SmtpGmail
    {
        private const int _smtpPort = 587;
        private const string _smtpName = "smtp.gmail.com";
        private const bool _enableSsl = true;
        private const string _smtpEmail = "smtpdentest1@gmail.com";
        private const string _smtpPassword = "smtpdentest1@gmail.com";

        public bool Send(string to = "smtpdentest1@gmail.com", string subject = "test", string body = "testbody")
        {
            var client = new SmtpClient(_smtpName, _smtpPort)
            {
                Credentials = new NetworkCredential(_smtpEmail, _smtpPassword),
                EnableSsl = _enableSsl
            };
            try
            {
                client.Send(_smtpEmail, to, subject, body);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
