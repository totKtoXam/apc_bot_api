using System;

namespace apc_bot_api.Models.Bots
{
    public class BotButton
    {
        public Guid Id { get; set; }            //// Идентификатор
        public string Name { get; set; }        //// Название
        public string Condition { get; set; }   //// Условие
        public string Code { get; set; }        //// Код для выполнения
        public string BotChannel { get; set; }  //// Источник бота (from Constants.BotChannelConstants)
        // public string Type { get; set; }        //// Inline - под болем ввода сообщения
        //                                         //// UnderMessage - прикрепленный под сообщения (в вк такое отсутствует)
        public string PreviousAction { get; set; }
    }
}