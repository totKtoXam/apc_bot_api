using System;
using apc_bot_api.Models.Base;

namespace apc_bot_api.Models.Content
{
    public class Section
    {
        public Guid Id { get; set; }
        public string NameTitle { get; set; }
        public string Content { get; set; }
        public string ParentSection { get; set; }
        // public Step Step { get; set; }
    }
}