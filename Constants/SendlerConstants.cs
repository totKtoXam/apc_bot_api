namespace apc_bot_api.Constants
{
    public static class SendlerHashtagConstants
    {
        public static readonly string[] PlanChanges = new string[]
            {
                "замена", "замен", "замены", "згамен", "изменения", "изменение"
            };

        public static readonly string[] NewPlans = new string[]
            {
                "расписание", "распиания", "расписания", "расписание"
            };

        public static readonly string[] News = new string[]
            {
                "новости", "новость", "news", "new"
            };
    }

    public static class AttachTypeConstants
    {
        public const string Doc = "doc";    //// документ
        public const string Photo = "photo"; //// фотография
        public const string Video = "video"; //// видеозапись
        public const string Audio = "audio"; //// аудиозапись
        public const string Wall = "wall"; //// запись на стене
        public const string Market = "market"; //// товар
        public const string Poll = "poll"; //// опрос

    }
}