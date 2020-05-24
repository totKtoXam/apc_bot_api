using System;
using System.Collections.Generic;
using apc_bot_api.Models.Base;

namespace apc_bot_api.Models.Appeals
{
    ///<summary>
    /// Заявки абитуриентов на поступления
    ///</summary>
    public class EnrolleeAppeal
    {
        /// <value>Идентификатор</value>
        public int Id { get; set; }
        /// <value>Текст сообщения абитуриент</value>
        public string Message { get; set; }
        /// <value>Дата подачи заявки</value>
        public DateTime CreatedDate { get; set; }
        /// <value>Кем подана заявка</value>
        public AppUser SentBy { get; set; }

        public ICollection<EnrolleeAppealFile> EnrolleeAppealFiles { get; set; }
    }
}