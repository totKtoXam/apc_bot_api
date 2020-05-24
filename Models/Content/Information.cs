using System.Collections.Generic;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Types;

namespace apc_bot_api.Models.Content
{
    public class Information : BaseProperties
    {
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public InfoType Type { get; set; }
        public Step Step { get; set; }
        public ICollection<InfoFile> InfoFiles { get; set; }
    }
}