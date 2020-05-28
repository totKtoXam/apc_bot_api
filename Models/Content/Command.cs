using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Bots;
using apc_bot_api.Models.Types;

namespace apc_bot_api.Models.Content
{
    public class Command : BaseProperties
    {
        public string PrevCommandCode { get; set; }
        public string NextCommandCode { get; set; }
        public CommandType Type { get; set; }
        public string Description { get; set; } //// будет выводиться клиенту //// описание
        public string Message { get; set; } //// будет выводиться клиенту //// Сообщение
        // public List<Information> InformationsList { get; set; }

        public ICollection<BotAction> BotActions { get; set; }
        // public ICollection<CommandFile> CommandFiles { get; set; }
        // public ICollection<CommandRole> CommandRoles { get; set; }
    }

    public class CommandViewModel : BaseProperties
    {
        public string Description { get; set; }
        public string Message { get; set; }
        public string TypeId { get; set; }
        public string TypeCode { get; set; }
        public string TypeCondition { get; set; }
        public string TypeDesc { get; set; }
        public List<BotActionViewModel> ActionList { get; set; }
    }

    public class CommandExecForm
    {
        public string Command { get; set; }
        public object Content { get; set; }
    }
}