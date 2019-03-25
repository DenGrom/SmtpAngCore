using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace SchedulerLib
{
    public class ApplicationContext : DbContext
    {
        public DbSet<JobModel> Jobs { get; set; }
        public DbSet<ScheduleModel> Schedules { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=schedulerdb;Trusted_Connection=True;");
            }
        }
    }
}
