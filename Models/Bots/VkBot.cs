using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace apc_bot_api.Models.Bots
{
    public class VkBot
    {
        public static class BotApiParams
        {
            /// <summary>
            /// Токен для доступа к API
            /// </summary>
            public const string AccessToken             = "2883d3e6044379e143a0da13e8354e833e813f620f92b01fe0eada72625dab65252da9335e6d7e6d59f5c";
            
            /// <summary>
            /// Ключ для подтверждения сервера
            /// </summary>
            public const string ServerConfirmationKey   = "49cb270d";

            /// <summary>
            /// Секретный ключ сервера вк, который удостоверяет, что запрос был отправлен от них сервера
            /// </summary>
            public const string SecretKey               = "Uagcf4K4RRchIyHQlNjHWlIZdb35gsLe";
            
        }

        [Serializable]
        public class EventUpdate
        {
            /// <summary>
            /// Тип события
            /// </summary>
            [JsonProperty("type")]
            public string   Type        { get; set; }

            /// <summary>
            /// Объект, инициировавший событие
            /// Структура объекта зависит от типа уведомления
            /// </summary>
            [JsonProperty("object")]
            public JObject  Object      { get; set; }

            /// <summary>
            /// ID сообщества, в котором произошло событие
            /// </summary>
            [JsonProperty("group_id")]
            public long     GroupId     { get; set; }

            /// <summary>
            /// Секретный ключ сервера вк, который удостоверяет, что запрос был отправлен от них сервера
            /// </summary>
            public string   Secret      { get; set; }
        }
    }
}