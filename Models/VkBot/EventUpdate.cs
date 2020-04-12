using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace apc_bot_api.Models.VkBot
{
    [Serializable]
    public class EventUpdate
    {
        /// <summary>
        /// Тип события
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Объект, инициировавший событие
        /// Структура объекта зависит от типа уведомления
        /// </summary>
        [JsonProperty("object")]
        public JObject Object { get; set; }

        /// <summary>
        /// ID сообщества, в котором произошло событие
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        /// Секретный ключ сервера вк, который удостоверяет, что запрос был отправлен от них сервера
        /// </summary>
        public string Secret { get; set; }
    }
}