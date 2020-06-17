using System.Collections.Generic;
using apc_bot_api.Models.Types;

namespace apc_bot_api.Constants
{
    public class CommandConstants
    {
        public static class Commands
        {
            public const string Start = "start";
            public const string Help = "help";
            public const string AboutUs = "aboutUs";
            public const string Specs = "specs";
            public const string SendAppeal = "sendappeal";
            public const string NewTask = "newtask";
            public const string ActiveTasks = "activetasks";
        }

        public static class Types
        {
            public const string Action = "ACTION";
            public const string Information = "INFORMATION";
            public const string ActionSelector = "ACTION_SELECTOR";
            // public const string Action = "ACTION";
            // public const string Action = "ACTION";
        }
    }
}