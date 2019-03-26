using SmtpEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Group> GetAllGroups()
        {
            return _context.Groups.AsEnumerable();
        }
    }
}
