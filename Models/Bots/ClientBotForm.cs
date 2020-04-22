using System.Collections.Generic;

namespace apc_bot_api.Models.Bots
{
    public class ClientBotForm
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ClientBotId { get; set; }
        public string ChatId { get; set; }
        public string BotChannel { get; set; }
    }

    public class ClientStudent : ClientBotForm
    {
        public string TicketNumber { get; set; }
        public string Group { get; set; }
    }

    public class TeacherClient : ClientBotForm
    {
        public List<string> GroupList { get; set; }
    }

    public class EnrolleeClient : ClientBotForm
    {
        public int AfterGrade { get; set; }
        public string School { get; set; }
    }
}