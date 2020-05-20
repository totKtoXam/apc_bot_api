using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apc_bot_api.Helpers;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Sendler;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace apc_bot_api.Repositories
{
    public interface ISendlerRepository
    {
        SendlerResponse GetStudentReceivers(SendlerPostForm sendlerForm);
    }
    public class SendlerRepository : ISendlerRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public SendlerRepository(
            AppDbContext dbContext,
            IMapper mapper
         //// HELPERS
         )
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        private List<StudentReceiverViewModel> StudentReceiverModelList => _dbContext.Students
                                                    .Include(x => x.ClientBot)
                                                    .ThenInclude(x => x.User)
                                                    .Where(x => x.ClientBot.TeleChatId != null || x.ClientBot.VkChatId != null || x.ClientBot.WhatsAppChatId != null)
                                                    .Select(x => _mapper.Map<StudentReceiverViewModel>(x))
                                                    .ToList();

        public SendlerResponse GetStudentReceivers(SendlerPostForm sendlerForm)
        {
            if (!string.IsNullOrEmpty(sendlerForm.Text))
            {
                var hashtags = SendlerHelper.GetHashtagTextFromPost(sendlerForm.Text);
                hashtags = FunctionsHelper.PrimitiveCleaning(hashtags);

                var receivers = GetReceiversList(hashtags);
                if (receivers == null)
                    return null;

                var attachments = sendlerForm.Attachments.Distinct().ToList();

                if (attachments == null || attachments.Count == 0)
                    return null;

                SendlerResponse response = new SendlerResponse()
                {
                    StudentList = receivers,
                    Text = sendlerForm.Text,
                    SendingFileList = sendlerForm.Attachments
                };

                return response;
            }
            else
                return null;
        }

        private List<StudentReceiverViewModel> GetReceiversList(List<string> hashtags)
        {
            var receivers = this.StudentReceiverModelList
                                                   .Where(x =>
                                                       !string.IsNullOrEmpty(x.Group)
                                                       &&
                                                       hashtags.Contains(
                                                           FunctionsHelper.PrimitiveCleaning(x.Group.ToUpper())
                                                       )
                                                   )
                                                   .ToList();

            if (receivers == null || receivers.Count == 0)
                return null;
            return receivers;
        }
    }
}