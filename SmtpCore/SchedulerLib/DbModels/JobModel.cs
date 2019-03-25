using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulerLib
{
    public class JobModel
    {
        public int Id { get; set; }
        public JobExecutionStatus Status { get; set; }
        public DateTime StatusChangedDate { get; set; }
        public int ScheduleId { get; set; }

        public JobModel(JobExecutionStatus status, DateTime statusChangedDate, int scheduleId)
        {
            Status = status;
            StatusChangedDate = statusChangedDate;
            ScheduleId = scheduleId;
        }
    }
}
