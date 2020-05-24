using System.Collections.Generic;
using apc_bot_api.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace apc_bot_api.Models.Types
{
    public class StepType : BaseProperties
    {
        public StepType() { }
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
        public StepType(string _name, string _code, string _condition, string _description)
        {
            this.Name = _name;
            this.Code = _code.ToUpper();
            this.Condition = _condition;
            this.Description = _description;
        }
        public string Description { get; set; }
    }
}