using System;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Content;

namespace apc_bot_api.Models.Bots
{
    public class BotAction : BaseProperties
    {
        public Command PrevCommand { get; set; }
        public Command CurrentCommand { get; set; }
        public Command NextCommand { get; set; }
        public bool IsEdit { get; set; }
    }

    public class BotActionViewModel : BaseProperties
    {
        public string PrevCmdId { get; set; }
        public string PrevCmdCode { get; set; }
        public string CurrentCmdId { get; set; }
        public string CurrentCmdCode { get; set; }
        public string CurrentCmdCond { get; set; }
        public string CurrentCmdDesc { get; set; }
        public string NextCmdId { get; set; }
        public string NextCmdCode { get; set; }
        public bool IsEdit { get; set; }
    }
}