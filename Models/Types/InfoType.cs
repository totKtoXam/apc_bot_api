using apc_bot_api.Models.Base;

namespace apc_bot_api.Models.Types
{
    public class InfoType : BaseProperties
    {
        public InfoType() { }
        /// <summary>
        /// Конструктор класса 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        /// <param name="_name">Наименование типа на русском языке</param>
        /// <param name="_code">символьный код типа на латинице с заглавными буквами</param>
        /// <param name="_condition">Условия типа</param>
        /// <param name="_description">Описание типа</param>
        public InfoType(string _name, string _code, string _condition, string _description)
        {
            this.Name = _name;
            this.Code = _code.ToUpper();
            this.Condition = _condition;
            this.Description = _description;
        }
        public string Description { get; set; }
    }
}