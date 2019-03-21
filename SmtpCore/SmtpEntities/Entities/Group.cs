using System;
using System.Collections.Generic;
using System.Text;

namespace SmtpEntities.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressGroup { get; set; }
        public bool IsActive { get; set; }
    }
}
