using System.Collections.Generic;
using apc_bot_api.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace apc_bot_api.Models.Bots
{
    public class ClientBot
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
        public string TeleChatId { get; set; }
        public string VkChatId { get; set; } //// user_id
        public string WhatsAppChatId { get; set; }
    }

    public class ClientBotForm
    {
        public int ClientBotId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        // ClientStudent
        public string TicketNumber { get; set; }
        public string Group { get; set; }

        // TeacherClient
        public string IIN { get; set; }

        // EnrolleeClient
        public int AfterGrade { get; set; }
        public string School { get; set; }
        public string RoleCode { get; set; }
    }

    public class ClientBotViewModel
    {
        public ClientBotViewModel() { }
        public int ClientBotId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string TeleChatId { get; set; }
        public string VkChatId { get; set; }
        public string WhatsAppChatId { get; set; }
        public string ClientRole { get; set; }

        // ClientStudent
        public string TicketNumber { get; set; }
        public string Group { get; set; }

        // TeacherClient
        public List<string> GroupList { get; set; }

        // EnrolleeClient
        public int AfterGrade { get; set; }
        public string School { get; set; }
        public int RESULT_CODE { get; set; }
        public string RESULT_NAME { get; set; }
    }
}