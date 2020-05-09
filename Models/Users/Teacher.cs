using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using apc_bot_api.Models.Bots;

namespace apc_bot_api.Models.Users
{
    public class Teacher
    {
        public Teacher() { }

        public Teacher(ClientBot _clientBot)
        {
            Id = _clientBot.Id;
            ClientBot = _clientBot;
        }

        [Key]
        [ForeignKey("ClientBot")]
        public int Id { get; set; }
        public ClientBot ClientBot { get; set; }
        public string Group { get; set; }
        public string IIN { get; set; }
    }
}