using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Bots;

namespace apc_bot_api.Models.Users
{
    public class StudentForm
    {
        public string TicketNumber { get; set; }
        public string Group { get; set; }
    }

    public class Student : StudentForm
    {
        public Student() { }

        public Student(ClientBot _clientBot)
        {
            Id = _clientBot.Id;
            ClientBot = _clientBot;
        }

        public Student(StudentForm formModel, ClientBot clientBot)
        {
            Id = clientBot.Id;
            ClientBot = clientBot;
            TicketNumber = formModel.TicketNumber;
            Group = formModel.Group;
        }

        [Key]
        [ForeignKey("ClientBot")]
        public int Id { get; set; }
        public ClientBot ClientBot { get; set; }
    }

    public class StudentViewModel : UserViewModel
    {
        public string StudentId { get; set; }
        public string TicketNumber { get; set; }
        public string Group { get; set; }
    }
}