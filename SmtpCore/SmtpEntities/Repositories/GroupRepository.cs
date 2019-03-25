using System;
using System.Collections.Generic;
using System.Text;

namespace SmtpEntities.Repositories
{
    public class GroupRepository
    {
        private ApplicationContext _context;
        public GroupRepository(ApplicationContext context)
        {
            _context = context;
        }
    }
}
