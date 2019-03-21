using System;
using System.Collections.Generic;
using System.Text;

namespace SmtpEntities.Entities
{
    public class GroupEmail
    {
        public int Id { get; set; }
        public virtual Group Group { get; set; }
        public virtual Email User { get; set; }
    }
}
