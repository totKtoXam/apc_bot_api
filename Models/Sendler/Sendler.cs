using System.Collections.Generic;

namespace apc_bot_api.Models.Sendler
{
    public class CheckSendler
    {
        public string Text { get; set; }
    }

    public class StudentReceiverViewModel
    {
        public int ClientId { get; set; }
        public string UserId { get; set; }
        public string Group { get; set; }
        public string Email { get; set; }
        public string TeleChatId { get; set; }
        public string VkChatId { get; set; }
        public string WhatsAppChatId { get; set; }
    }

    public class SendlerResponse
    {
        // public string ReceiverUsersRole { get; set; } //// teacher, enrollee, student
        public List<StudentReceiverViewModel> StudentList { get; set; } //// Список студентов, которые получат рассылку
        public List<PostAttachment> SendingFileList { get; set; } //// Список отправляемых файлов
    }

    public class Sendler
    {

    }

    public class SendlerPostForm
    {
        public string BotChannel { get; set; }
        public string Text { get; set; }
        public List<PostAttachment> Attachments { get; set; } = new List<PostAttachment>();
    }

    public class PostAttachment
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Ext { get; set; }
        public string AccessKey { get; set; }
    }
    //     public File File { get; set; }
    // }

    // public class File
    // {
    //     public int Id { get; set; }
    //     public int OwnerId { get; set; }
    //     public string Url { get; set; }
    //     public string Title { get; set; }
    //     public string Text { get; set; }
    //     public string Ext { get; set; }
    //     public string AccessKey { get; set; }
    // }
}