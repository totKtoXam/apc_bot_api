using System;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Bots;
using Microsoft.AspNetCore.Mvc;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace apc_bot_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VkBotCallbackController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IVkApi _vkApi;

        public VkBotCallbackController (
                    AppDbContext dbContext,
                    IVkApi vkApi
                )
        {
            _dbContext = dbContext;
            _vkApi = vkApi;
        }

        [HttpPost]
        public IActionResult Callback([FromBody] EventUpdate eventUpdate)
        {
            switch (eventUpdate.Type)
            {
                case "confirmation":
                    return Ok(VkBot.BotApiParams.ServerConfirmationKey);
                case "message_new":{
                        // Десериализация
                        var msg = Message.FromJson(new VkResponse(eventUpdate.Object));

                            // Отправим в ответ полученный от пользователя текст
                        _vkApi.Messages.Send(new MessagesSendParams{ 
                                RandomId = new DateTime().Millisecond,
                                // уникальный (в привязке к API_ID и ID отправителя) идентификатор,
                                // предназначенный для предотвращения повторной отправки одинакового сообщения.
                                // Сохраняется вместе с сообщением и доступен в истории сообщений.
                                /////// Заданный RandomId используется для проверки уникальности за всю историю сообщений,
                                /////// поэтому используйте большой диапазон(до int32).
                                
                                PeerId = msg.PeerId.Value, // идентификатор назначения

                                Message = msg.Text //текст личного сообщения. Обязательный параметр, если не задан параметр attachment.
                            });
                        break;
                    }
                default:
                    break;
            }

            return Ok();
        }
    }
}