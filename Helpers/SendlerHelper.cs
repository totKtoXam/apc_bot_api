using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using apc_bot_api.Models.Base;

namespace apc_bot_api.Helpers
{
    public static class SendlerHelper
    {
        public static List<string> GetHashtagTextFromPost(string postText)
        {
            Regex regex = new Regex(@"#(\S+)*");
            List<string> groups = new List<string>();
            MatchCollection matches = regex.Matches(postText);
            foreach (Match match in matches)
            {
                groups.Add(match.Value.Remove(0, 1).ToUpper());
            }
            return groups;
        }
    }
}