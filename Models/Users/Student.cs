using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using apc_bot_api.Models.Base;

namespace apc_bot_api.Models.Users
{
    public class StudentForm
    {
        public string TicketNumber { get; set; }
        public string Group { get; set; }
        public string VkUserId { get; set; }
        public string VkChatId { get; set; }
        public string TelegramChatId { get; set; }
    }

    public class Student : StudentForm
    {
        public Student() { }

        public Student(AppUser _user)
        {
            Id = _user.Id;
            User = _user;
        }

        public Student(StudentForm formModel, AppUser user)
        {
            Id = user.Id;
            User = user;
            TicketNumber = formModel.TicketNumber;
            Group = formModel.Group;
            VkUserId = formModel.VkUserId;
            VkChatId = formModel.VkChatId;
            TelegramChatId = formModel.TelegramChatId;
        }

        [Key]
        [ForeignKey("AppUser")]
        public string Id { get; set; }
        public AppUser User { get; set; }
    }
}