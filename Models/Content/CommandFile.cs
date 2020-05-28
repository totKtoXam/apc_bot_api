using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apc_bot_api.Models.Content
{
    public class CommandFile
    {
        public CommandFile() { }
        public CommandFile(Command _command, UploadedFile _file)
        {
            Command = _command;
            File = _file;
        }
        [Required]
        public virtual Command Command { get; set; }
        [Required]
        public virtual UploadedFile File { get; set; }

        // [Required]
        [Key]
        [ForeignKey("Command")]
        public Guid CommandId { get; set; }
        [Key]
        [ForeignKey("UploadedFile")]
        public Guid UploadedFileId { get; set; }
    }
}