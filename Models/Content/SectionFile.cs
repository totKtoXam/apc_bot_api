using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apc_bot_api.Models.Content
{
    public class SectionFile
    {
        public SectionFile() { }
        public SectionFile(Section section, UploadedFile file)
        {
            Section = section;
            File = file;
        }
        [Required]
        public virtual Section Section { get; set; }
        [Required]
        public virtual UploadedFile File { get; set; }

        // [Required]
        [Key]
        [ForeignKey("Section")]
        public Guid SectionId { get; set; }
        [Key]
        [ForeignKey("UploadedFile")]
        public Guid UploadedFileId { get; set; }
    }
}