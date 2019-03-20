using System;
using System.Collections.Generic;
using System.Text;

namespace SmtpEntities.Entities.Enums
{
    public enum EmailStatus
    {
        None,
        New,
        Processing,
        Pause,
        Processed,
        Disable
    }
}
