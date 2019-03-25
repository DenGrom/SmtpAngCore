using Quartz;
using Quartz.Impl;
using SchedulerLib;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace SmtpCore.Common
{
    public class QuartzStartup
    {
        private IScheduler _scheduler; // after Start, and until shutdown completes, references the scheduler object

        // starts the scheduler, defines the jobs and the triggers
        public Action Start(int emailId)
        {

            //ScheduleManager.CreateNewSchedule(DateTime.Now, ScheduleExecutionType.REPEATABLE, new TimeSpan(0, 0, 3), typeof(SendUserEmailsJob).ToString());
            //ScheduleManager.Run();
            return new Action(() => { });
            //if (_scheduler != null)
            //{
            //    throw new InvalidOperationException("Already started.");
            //}

            //var properties = new NameValueCollection
            //{
            //    // json serialization is the one supported under .NET Core (binary isn't)
            //    ["quartz.serializer.type"] = "json",

            //    //the following setup of job store is just for example and it didn't change from v2
            //   ["quartz.scheduler.instanceName"] = "DotnetCoreScheduler",

            //   ["quartz.scheduler.instanceId"] = "instance_one",

            //   ["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz",
            //    ["quartz.threadPool.threadCount"] = "1000000000",
            //   ["quartz.jobStore.misfireThreshold"] = "60000",
            //    ["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz",
            //    ["quartz.jobStore.useProperties"] = "false",
            //    ["quartz.jobStore.dataSource"] = "default",
            //    ["quartz.jobStore.tablePrefix"] = "QRTZ_",
            //    ["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz",
            //    ["quartz.dataSource.default.provider"] = "SqlServer", // SqlServer-41 is the new provider for .NET Core
            //    ["quartz.dataSource.default.connectionString"] = @"Server=.\sql2016;Database=SmtpAngCore;Integrated Security=true"
            //};

            //var schedulerFactory = new StdSchedulerFactory(properties);
            ////var schedulerFactory = new StdSchedulerFactory();
            //_scheduler = schedulerFactory.GetScheduler().Result;
            //_scheduler.Start().Wait();

            //var userEmailsJob = JobBuilder.Create<SendUserEmailsJob>()
            //    .WithIdentity("SendUserEmails", "group1")
            //    .Build();
            //var userEmailsTrigger = TriggerBuilder.Create()
            //    .WithIdentity("UserEmailsCron", "group1")
            //    .StartNow()
            //    .WithCronSchedule("0/3 0 0 ? * * *")
            //        //            .WithSimpleSchedule(x => x
            //        //.WithIntervalInSeconds(2)
            //        //.RepeatForever())
            //    .Build();
            //if (!_scheduler.CheckExists(userEmailsJob.Key).Result)
            //{
            //    _scheduler.ScheduleJob(userEmailsJob, userEmailsTrigger).Wait();
            //}






            //NameValueCollection props = new NameValueCollection
            //{
            //    { "quartz.serializer.type", "binary" }
            //};
            //StdSchedulerFactory factory = new StdSchedulerFactory(props);

            //// get a scheduler
            //IScheduler sched = await factory.GetScheduler();
            //await sched.Start();

            //// define the job and tie it to our HelloJob class
            //IJobDetail job = JobBuilder.Create<SendUserEmailsJob>()
            //    .WithIdentity("myJob", "group1")
            //    .Build();

            //// Trigger the job to run now, and then every 40 seconds
            //ITrigger trigger = TriggerBuilder.Create()
            //    .WithIdentity("myTrigger", "group1")
            //    .StartNow()
            //    .WithSimpleSchedule(x => x
            //        .WithIntervalInSeconds(2)
            //        .RepeatForever())

            //.Build();

            //await sched.ScheduleJob(job, trigger);
        }

        // initiates shutdown of the scheduler, and waits until jobs exit gracefully (within allotted timeout)
        //public void Stop()
        //{
        //    if (_scheduler == null)
        //    {
        //        return;
        //    }

        //    // give running jobs 30 sec (for example) to stop gracefully
        //    if (_scheduler.Shutdown(waitForJobsToComplete: true).Wait(30000))
        //    {
        //        _scheduler = null;
        //    }
        //    else
        //    {
        //        // jobs didn't exit in timely fashion - log a warning...
        //    }
        //}
    }
}
