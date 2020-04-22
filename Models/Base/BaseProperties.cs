using System;

namespace apc_bot_api.Models.Base
{
    public class BaseProperties
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Condition { get; set; }
    }
}