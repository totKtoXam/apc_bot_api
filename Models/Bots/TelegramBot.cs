using System.Collections.Generic;
using System.Threading.Tasks;
using apc_bot_api.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Microsoft.Extensions.Configuration;

namespace apc_bot_api.Models.Bots
{
    public class TelegramBot
    {
        private static readonly TelegramBotHelper _telegramBotHelper = new TelegramBotHelper(); //// Initialization of TelegramBotHelper

        public static class BotApiParams    //// Параметры для телеграм-бот API
        {
            // public const string Url         = "https://4296b6d6.ngrok.io/";                     //// Ссылка на расположение сервиса
            public const string Url = "https://apc-bot-rest-api.azurewebsites.net/";             //// Ссылка на расположение сервиса
            public const string Name = "AstPolytechCollege_bot";                         //// Имя телеграм-бота (UserName/userId)
            public const string AccessToken = "1025190340:AAFb51xmnvdHmSCnaFd2Zx-G5m--cHUROQ0"; //// Токен доступа для подключения к боту
        }

        public static class BotInitialization   //// Модель инициализации бота
        {
            private static TelegramBotClient _telegramBotclient;                                //// телеграм бот клиент
            private static List<Command> commandsList;                                          //// Список команд
            public static IReadOnlyList<Command> commands { get => commandsList.AsReadOnly(); } //// Список команд только для чтения

            public static async Task<TelegramBotClient> GetAsync()  //// метод для получения бот клиента
            {
                if (_telegramBotclient != null) //// если телеграм бот клиента нет, то вернуть его
                {
                    return _telegramBotclient;  //// Возвращение телеграм-бот клиента
                }

                commandsList = new List<Command>();                 //// инициализация инстанса списка комманд
                commandsList.Add(new BotCommands.HelloCommand());
                //TODO: Add more commands

                _telegramBotclient = new TelegramBotClient(BotApiParams.AccessToken);   //// иначе инициализировать инстанс Телеграм-бот клиента
                var hookUrl = string.Format(BotApiParams.Url, "api/TelegramBot/update");   //// формирования url для webhook
                await _telegramBotclient.SetWebhookAsync(hookUrl);

                return _telegramBotclient;
            }
        }

        public abstract class Command   //// асбстрактный класс Команды
        {
            public abstract string Name { get; }                                        //// Название команды (сама команда)
            public abstract void Execute(Message message, TelegramBotClient client);    //// Методя для выполнения команты
            public bool Contains(string command)                                        //// Метод для проверки команды в тексте
            {
                return command.Contains(this.Name) && command.Contains(BotApiParams.Name);
            }
        }

        public class BotCommands                //// Команды и их действия (функциональность)
        {
            //TODO: перенести функции команд в репозиторий TelegramBotRepository и вызывать оттуда
            public class HelloCommand : Command
            {
                public override string Name => "hello";

                public override async void Execute(Message message, TelegramBotClient client)
                {
                    var chatId = message.Chat.Id;
                    var messageId = message.MessageId;
                    var recipientName = _telegramBotHelper.GetRecipientName(message);

                    //TODO: Bot Command Logic is here

                    await client.SendTextMessageAsync(chatId, "Hello!", replyToMessageId: messageId);
                }
            }

            // public class 
        }
    }
}