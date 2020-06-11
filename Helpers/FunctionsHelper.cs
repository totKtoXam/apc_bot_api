using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using apc_bot_api.Constants;
using apc_bot_api.Models.Bots;

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



        public static bool CheckChatIdByChannel(ClientBot data, string channel, string chatId)
        {
            if (channel == BotConstants.Channels.Telegram)
                return (data.TeleChatId == chatId);
            if (channel == BotConstants.Channels.VKontakte)
                return (data.VkChatId == chatId);
            if (channel == BotConstants.Channels.WhatsApp)
                return (data.WhatsAppChatId == chatId);
            return false;
        }
    }
}