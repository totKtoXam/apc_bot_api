namespace apc_bot_api.Constants
{
    public static class BotConstants
    {
        public static class Actions
        {
            public const string ROLE_IS_STUDENT = "ROLE_IS_STUDENT";
            public const string ROLE_IS_TEACHER = "ROLE_IS_TEACHER";
            public const string ROLE_IS_ENROLLEE = "ROLE_IS_ENROLLEE";
            // public static readonly string ROLE_IS_STUDENT = "ROLE_IS_STUDENT";
            // public static readonly string ROLE_IS_STUDENT = "ROLE_IS_STUDENT";
        }

        public static class Channels
        {
            public const string General = "GENERAL";
            public const string VKontakte = "V_KONTAKTE";
            public const string Telegram = "TELEGRAM";
            public const string WhatsApp = "WHATS_APP";
        }

        public enum FoundParams
        {
            ByTicket, ByEmail, ByChatId, ByUserId
        }
    }
}