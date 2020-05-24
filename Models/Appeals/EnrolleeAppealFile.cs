using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using apc_bot_api.Models.Content;

namespace apc_bot_api.Models.Appeals
{
    ///<summary>Связь между заявкой и отправленными файлами</summary>
    public class EnrolleeAppealFile
    {
        public EnrolleeAppealFile() { }
        public EnrolleeAppealFile(EnrolleeAppeal _appeal, UploadedFile _file)
        {
            this.Appeal = _appeal;
            this.File = _file;
        }

        [Required]
        public virtual EnrolleeAppeal Appeal { get; set; }
        [Required]
        public virtual UploadedFile File { get; set; }

        [Key]
        [ForeignKey("EnrolleeAppeal")]
        public Guid AppealId { get; set; }
        [Key]
        [ForeignKey("UploadedFile")]
        public int FileId { get; set; }
    }
}