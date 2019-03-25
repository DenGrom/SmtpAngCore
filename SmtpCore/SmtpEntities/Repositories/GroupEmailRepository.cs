using SmtpEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmtpEntities.Repositories
{
    public class GroupEmailRepository
    {
        private ApplicationContext _context;

        public GroupEmailRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void CreateGroupeEmail(Email model)
        {
            throw new NotImplementedException();
        }

        public void CreateGroupeEmailByEmailId(int emailId)
        {
            throw new NotImplementedException();
        }
    }
}
