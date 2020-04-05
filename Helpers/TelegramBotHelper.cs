using Telegram.Bot;
using Telegram.Bot.Types;

namespace apc_bot_api.Helpers
{
    public class TelegramBotHelper
    {
        public string GetRecipientName (Message message)    //// Returns the name of the recipient
        {
            if (string.IsNullOrEmpty(message.Chat.FirstName))
            {
                return message.Chat.Username;
            }
            else
            {
                return (string.IsNullOrEmpty(message.Chat.LastName) ? "" : message.Chat.LastName + " ") + message.Chat.FirstName;
            }
        }
    }
}