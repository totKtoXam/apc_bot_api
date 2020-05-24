using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apc_bot_api.Models.Content
{
    public class StepFile
    {
        public StepFile() { }
        public StepFile(Step _step, UploadedFile _file)
        {
            Step = _step;
            File = _file;
        }
        [Required]
        public virtual Step Step { get; set; }
        [Required]
        public virtual UploadedFile File { get; set; }

        // [Required]
        [Key]
        [ForeignKey("Step")]
        public Guid StepId { get; set; }
        [Key]
        [ForeignKey("UploadedFile")]
        public Guid UploadedFileId { get; set; }
    }
}