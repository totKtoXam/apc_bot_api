using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Bots;
using apc_bot_api.Models.Types;

namespace apc_bot_api.Models.Content
{
    public class Step : BaseProperties
    {
        public string PrevStepCode { get; set; }
        public string NextStepCode { get; set; }
        public StepType Type { get; set; }
        public string Description { get; set; } //// будет выводиться клиенту //// описание
        public string Message { get; set; } //// будет выводиться клиенту //// Сообщение
        // public List<Information> InformationsList { get; set; }

        public ICollection<StepFile> StepFiles { get; set; }
        public ICollection<StepRole> StepRoles { get; set; }
    }

    public class StepViewModel
    {
        public string StepId { get; set; }
        public string StepName { get; set; }
        public string StepCode { get; set; }
        public string StepCondition { get; set; }
        public List<BotActionViewModel> ActionList { get; set; }
    }
}