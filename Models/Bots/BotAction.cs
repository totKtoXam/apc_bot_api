using System;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Content;

namespace apc_bot_api.Models.Bots
{
    public class BotAction : BaseProperties
    {
        public Step PrevStep { get; set; }
        public Step NextStep { get; set; }
        public bool IsEdit { get; set; }
    }

    public class BotActionViewModel : BaseProperties
    {
        public bool IsEdit { get; set; }
        public string PrevStepId { get; set; }
        public string PrevStepCode { get; set; }
        public string NextStepId { get; set; }
        public string NextStepCode { get; set; }
    }
}