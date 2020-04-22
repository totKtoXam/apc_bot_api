using System.Collections.Generic;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Bots;

namespace apc_bot_api.Models.Content
{
    public class Step : BaseProperties
    {
    }

    public class StepWithActionsViewModel
    {
        public string StepId { get; set; }
        public string StepName { get; set; }
        public string StepCode { get; set; }
        public string StepCondition { get; set; }
        public List<BotActionViewModel> ActionList { get; set; }
    }
}