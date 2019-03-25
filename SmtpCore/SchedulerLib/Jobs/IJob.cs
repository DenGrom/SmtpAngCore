using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SchedulerLib
{
    public enum JobExecutionStatus
    {
        CREATED,
        INPROGRESS,
        DONE,
        EXCEPTION
    }

    public interface IJob
    {
        int Id { get; set; }
        JobExecutionStatus Status { get; set; }
        int ScheduleId { get; set; }
        void Execute();
    }
}
