using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apc_bot_api.Models.Content
{
    public class InfoFile
    {
        public InfoFile() { }
        public InfoFile(Information _info, UploadedFile _file)
        {
            this.Info = _info;
            this.File = _file;
        }

        [Required]
        public virtual Information Info { get; set; }
        [Required]
        public virtual UploadedFile File { get; set; }

        // [Required]
        [Key]
        [ForeignKey("Information")]
        public Guid InfoId { get; set; }
        [Key]
        [ForeignKey("UploadedFile")]
        public int FileId { get; set; }
    }
}