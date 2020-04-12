using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;

namespace apc_bot_api.Models.TelegramBot
{
    public class TeleBot
    {
        private static TelegramBotClient botClient;
        private static List<Command> commandsList = new List<Command>();

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }

            commandsList = new List<Command>();
            commandsList.Add(new StartCommand());
            //TODO: Add more commands

            botClient = new TelegramBotClient(TeleBotSettings.AccessToken);
            string hook = string.Format(TeleBotSettings.Url, "api/TelegramBot/update");
            await botClient.SetWebhookAsync(hook);
            return botClient;
        }
    }
}