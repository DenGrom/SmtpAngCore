using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq;

namespace SchedulerLib
{
    public enum ScheduleExecutionType
    {
        SINGLE,
        REPEATABLE
    }

    public class Schedule
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime RunDate { get; set; }
        public ScheduleExecutionType ExecutionType { get; set; }
        public TimeSpan Delay { get; set; }
        public string JobFullName { get; set; }

        public Schedule(int id, bool active, DateTime runDate, ScheduleExecutionType type, TimeSpan delay, string jobFullName)
        {
            Id = id;
            Active = active;
            RunDate = runDate;
            ExecutionType = type;
            Delay = delay;
            JobFullName = jobFullName;
        }

        public Schedule(DateTime runDate, ScheduleExecutionType type, string jobFullName)
        {
            Active = true;
            RunDate = runDate;
            ExecutionType = type;
            JobFullName = jobFullName;
            Delay = new TimeSpan(0);
        }

        public Schedule(DateTime runDate, ScheduleExecutionType type, TimeSpan delay, string jobFullName)
        {
            Active = true;
            RunDate = runDate;
            ExecutionType = type;
            Delay = delay;
            JobFullName = jobFullName;
        }

        public bool ExecuteJob()
        {
            var finished = false;
            Active = false;
            var myType = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).SingleOrDefault(y => y.ToString().Contains(JobFullName));
            var newJob = Activator.CreateInstance(myType) as IJob;
            newJob.Status = JobExecutionStatus.CREATED;
            newJob.ScheduleId = Id;
            newJob.Id = DbManager.SaveJob(newJob).Id;
            newJob.Status = JobExecutionStatus.INPROGRESS;
            DbManager.UpdateJob(newJob);
            try
            {
                newJob.Execute();
                newJob.Status = JobExecutionStatus.DONE;
            }
            catch
            {
                newJob.Status = JobExecutionStatus.EXCEPTION;
            }
            DbManager.UpdateJob(newJob);
            if (newJob.Status == JobExecutionStatus.DONE) finished = true;
            return finished;
        }
    }
}