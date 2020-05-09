namespace apc_bot_api.Constants
{
    public static class SectionTitles
    {
        public static readonly string hiTitle = "Здравствуйте! Выберите Вашу роль:";
        // public static readonly string selectContactData = "Выберите способ регистрации:";
        public static readonly string emailSelected = "Введите Вашу эл-ю почту:";
        public static readonly string phoneSelected = "Введит Ваш сотовый номер (в формате: 707 885 89 89):";
        // public static readonly string 
        public static readonly string regTitle = "Регистрация";
    }

    public static class StepConstants
    {
        public static readonly string _START_ = "start";
        public static readonly string _EMAIL_ENTER_ = "EMAIL_ENTER"; 
    }

    public class ActionConstants
    {
        public const string ROLE_IS_STUDENT = "ROLE_IS_STUDENT";
        public const string ROLE_IS_TEACHER = "ROLE_IS_TEACHER";
        public const string ROLE_IS_ENROLLEE = "ROLE_IS_ENROLLEE";
        // public static readonly string ROLE_IS_STUDENT = "ROLE_IS_STUDENT";
        // public static readonly string ROLE_IS_STUDENT = "ROLE_IS_STUDENT";
    }
}