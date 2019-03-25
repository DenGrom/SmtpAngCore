using Microsoft.EntityFrameworkCore;
using SmtpEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmtpEntities.Repositories
{
    public class EmailRepository
    {
        private ApplicationContext _context;
        public EmailRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Email>> GetEmailByGroups()
        {
            var emails = await _context.Emails.ToListAsync();
            return emails;
        }

        public int CreateEmail(Email emailEntity)
        {
            _context.Emails.Add(emailEntity);
            _context.SaveChanges();
            return emailEntity.Id;
        }
    }
}
