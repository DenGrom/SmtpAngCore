using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SchedulerLib
{
    public static class DbManager
    {
        public static List<Schedule> LoadActiveSchedules()
        {
            using (ApplicationContext dbContext = new ApplicationContext())
            {
                List<Schedule> schedules = new List<Schedule>();
                foreach (ScheduleModel model in dbContext.Schedules)
                {
                    if (model.Active)
                        schedules.Add(new Schedule(model.Id, model.Active, model.RunDate, model.Type, model.Delay, model.JobType));
                }
                return schedules;
            }
        }

        public static ScheduleModel SaveSchedule(Schedule schedule)
        {
            using (ApplicationContext dbContext = new ApplicationContext())
            {
                var scheduleModel = new ScheduleModel(schedule.ExecutionType, schedule.Delay, schedule.RunDate, schedule.JobFullName);
                dbContext.Schedules.Add(scheduleModel);
                dbContext.SaveChanges();
                return scheduleModel;
            }
        }

        public static JobModel SaveJob(IJob job)
        {
            using (ApplicationContext dbContext = new ApplicationContext())
            {
                var jobModel = new JobModel(job.Status, DateTime.Now, job.ScheduleId);
                dbContext.Jobs.Add(jobModel);
                dbContext.SaveChanges();
                return jobModel;
            }
        }

        public static void UpdateJob(IJob job)
        {
            using (ApplicationContext dbContext = new ApplicationContext())
            {
                var model = dbContext.Jobs.Find(job.Id);
                model.ScheduleId = job.ScheduleId;
                model.Status = job.Status;
                model.StatusChangedDate = DateTime.Now;
                dbContext.SaveChanges();
            }
        }

        public static void UpdateSchedule(Schedule schedule)
        {
            using (ApplicationContext dbContext = new ApplicationContext())
            {
                var model = dbContext.Schedules.Find(schedule.Id);
                model.Active = schedule.Active;
                model.RunDate = schedule.RunDate;
                dbContext.SaveChanges();
            }
        }

    }
}
