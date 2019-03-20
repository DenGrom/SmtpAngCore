using System;
using System.Collections.Generic;
using System.Text;

namespace SmtpEntities.Entities
{
    public class UserGroup
    {
        public int Id { get; set; }
        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
    }
}
