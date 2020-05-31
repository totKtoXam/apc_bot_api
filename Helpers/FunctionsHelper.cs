using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace apc_bot_api.Helpers
{
    public static class FunctionsHelper
    {
        public static List<string> PrimitiveCleaning(List<string> strValueList)
        {
            Regex regex = new Regex(@"\W");
            for (int i = 0; i < strValueList.Count; i++)
                strValueList[i] = regex.Replace(strValueList[i], "");
            // strValueList
            //     .ForEach(x =>
            //         x = regex.Replace(x, " ")
            //     );

            return strValueList;
        }
        public static string PrimitiveCleaning(string strValue)
        {
            strValue = new Regex(@"\W").Replace(strValue, "");
            return strValue;
        }

        public static bool StringsIsNull(params string[] args)
        {
            List<string> list = new List<string>();
            list.AddRange(args);
            return list.Any(x => string.IsNullOrEmpty(x));
        }
    }
}