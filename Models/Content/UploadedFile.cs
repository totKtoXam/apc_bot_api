using System;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Types;

namespace apc_bot_api.Models.Content
{
    public class UploadedFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public AppUser UploadedBy { get; set; }
        public DateTime UploadedDate { get; set; } = DateTime.Now;
        public FileType File { get; set; }
    }
}