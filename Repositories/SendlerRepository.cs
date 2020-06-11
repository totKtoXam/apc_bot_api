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
        Result<SendlerResponse> GetStudentReceivers(SendlerPostForm sendlerForm);
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

        private List<StudentReceiverViewModel> GetReceiverViewModelList(List<string> hashtags) => this.StudentReceiverModelList
                                                   .Where(x =>
                                                       !string.IsNullOrEmpty(x.Group)
                                                       &&
                                                       hashtags.Contains(
                                                           FunctionsHelper.PrimitiveCleaning(x.Group.ToUpper())
                                                       )
                                                   )
                                                   .ToList();

        public Result<SendlerResponse> GetStudentReceivers(SendlerPostForm sendlerForm)
        {
            if (sendlerForm.Attachments == null || sendlerForm.Attachments.Count == 0)
                return
                    new Result<SendlerResponse>(
                        new SendlerResponse()
                        {
                            StudentList = new List<StudentReceiverViewModel>(),
                            Text = sendlerForm.Text,
                            SendingFileList = sendlerForm.Attachments
                        }
                    );

            var hashtags = SendlerHelper.GetHashtagTextFromPost(sendlerForm?.Text ?? "");
            hashtags = FunctionsHelper.PrimitiveCleaning(hashtags);

            var receivers = GetReceiverViewModelList(hashtags);

            var attachments = sendlerForm.Attachments.Distinct().ToList();

            SendlerResponse response = new SendlerResponse()
            {
                StudentList = receivers,
                Text = sendlerForm.Text,
                SendingFileList = sendlerForm.Attachments
            };

            return new Result<SendlerResponse>(response);
        }
    }
}