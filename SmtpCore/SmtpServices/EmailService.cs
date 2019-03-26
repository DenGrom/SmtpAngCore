using SmtpEntities;
using SmtpEntities.Repositories;
using SmtpModels;
using SmtpServices.Common;
using SmtpServices.Contracts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmtpServices
{
    public class EmailService : IEmailService
    {
        private UserRepository _userRepository;
        private EmailRepository _emailRepository;
        private GroupEmailRepository _groupEmailRepository;
        private GroupRepository _groupRepository;
        private SmtpGmail _smtpGmail;
        public EmailService(ApplicationContext applicationContext)
        {
            _userRepository = new UserRepository(applicationContext);
            _emailRepository = new EmailRepository(applicationContext);
            _groupEmailRepository = new GroupEmailRepository(applicationContext);
            _smtpGmail = new SmtpGmail();
            _groupRepository = new GroupRepository(applicationContext);
        }
        public async Task<bool> SendAdminEmails()
        {
            return await new Task<bool>(() => true);
        }

        public async Task<bool> SendUserEmails()
        {
            var allUsers = _userRepository.GetAllUsers().Result;
            
            foreach (var user in allUsers)
            {

                //_smtpGmail.Send(to: user.Email, subject: user. "test", string body = "testbody");
            }
            return true;
        }

        public void CreateEmail(CreateEmailModel createEmailModel)
        {
            var email = createEmailModel.Email;
            var emailEntity = new SmtpEntities.Entities.Email
            {
                EmailStatus = email.EmailStatus,
                Id = email.Id,
                IsActive = email.IsActive,
                Text = email.Text,
                Title = email.Title
            };
            var emailId = _emailRepository.CreateEmail(emailEntity);
            _groupEmailRepository.CreateGroupeEmailByEmailId(emailId);
        }

        public List<Group> GetAllGroups()
        {
            var groupsEntity = _groupRepository.GetAllGroups();
            var newGroups = new List<Group>();
            foreach(var groupEntity in groupsEntity)
            {
                var newGroup = new Group{
                    AddressGroup = groupEntity.AddressGroup,
                    Id= groupEntity.Id,
                    IsActive = groupEntity.IsActive,
                    Name = groupEntity.Name
                };
                newGroups.Add(newGroup);
            }
            return newGroups;
        }
    }
}
