using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchedulerLib
{
    public static class ScheduleManager
    {
        public static List<Schedule> Schedules { get; set; }

        static ScheduleManager()
        {
            Schedules = new List<Schedule>();
            Schedules = DbManager.LoadActiveSchedules();
        }

        public static void CreateNewSchedule(DateTime runDate, ScheduleExecutionType type, string jobFullName)
        {
            var schedule = new Schedule(runDate, type, jobFullName);
            schedule.Id = DbManager.SaveSchedule(schedule).Id;
            Schedules.Add(schedule);
        }

        public static void CreateNewSchedule(DateTime runDate, ScheduleExecutionType type, TimeSpan delay, string jobFullName)
        {
            var schedule = new Schedule(runDate, type, delay, jobFullName);
            schedule.Id = DbManager.SaveSchedule(schedule).Id;
            Schedules.Add(schedule);
        }

        public static void StopSchedule(int id)
        {
            foreach (Schedule schedule in Schedules)
            {
                if (schedule.Id == id)
                {
                    schedule.Active = false;
                    DbManager.UpdateSchedule(schedule);
                }
            }
        }

        public static async void Run()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    foreach (Schedule schedule in Schedules)
                    {
                        if (schedule.Active && schedule.RunDate < DateTime.Now)
                        {
                            await Task.Run(() =>
                            {
                                var executed = schedule.ExecuteJob();
                                if (executed && schedule.ExecutionType == ScheduleExecutionType.REPEATABLE)
                                {
                                    schedule.RunDate = schedule.RunDate.Add(schedule.Delay);
                                    Console.WriteLine(schedule.RunDate.ToString());
                                    schedule.Active = true;
                                }
                                DbManager.UpdateSchedule(schedule);
                            });
                        }
                    }
                    Schedules.RemoveAll(schedule => !schedule.Active);
                    await Task.Delay(1000);
                }
            });
        }

    }
}
