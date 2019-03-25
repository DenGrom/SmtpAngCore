using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulerLib
{
    public class ScheduleModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public ScheduleExecutionType Type { get; set; }
        public TimeSpan Delay { get; set; }
        public DateTime RunDate { get; set; }
        public string JobType { get; set; }

        public ScheduleModel(ScheduleExecutionType type, TimeSpan delay, DateTime runDate, string jobType)
        {
            Active = true;
            Type = type;
            Delay = delay;
            RunDate = runDate;
            JobType = jobType;
        }
    }
}
