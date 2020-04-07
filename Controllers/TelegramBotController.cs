using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Bots;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Threading.Tasks;

namespace apc_bot_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelegramBotController : ControllerBase
    {
        [HttpPost("update")]    //// webhook uri part
        public async Task<IActionResult> Update([FromBody] Update update)   //// Метод выполняется при обновлении данных сообщения в телеграмБоте
        {
            var commands    = TelegramBot.BotInitialization.commands;           //// команды Телеграм Бота
            var message     = update.Message;                                   //// сообщения события Update
            var client      = await TelegramBot.BotInitialization.GetAsync();   //// Инициализация Телеграм Бота

            foreach(var command in commands)        //// Поиск команды
            {
                if (command.Contains(message.Text)) //// Если команд есть, то...
                {
                    command.Execute(message, client);   //// Выполнить функцию команды
                    break;
                }
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult GetBotName ()
        {
            return Ok(TelegramBot.BotApiParams.Name);
        }
    }
}