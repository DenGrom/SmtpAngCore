using Microsoft.EntityFrameworkCore;
using SmtpEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmtpEntities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupEmail> GroupEmails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
    }
}
