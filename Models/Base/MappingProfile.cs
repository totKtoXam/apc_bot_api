using System;
using apc_bot_api.Models.AssignedTasks;
using apc_bot_api.Models.Bots;
using apc_bot_api.Models.Content;
using apc_bot_api.Models.Sendler;
using apc_bot_api.Models.Users;
using AutoMapper;

namespace apc_bot_api.Models.Base
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateMap<DevUser, DevUser>();
            // CreateMap<Speciality, DisciplineSpecialityViewModel>()
            //     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<BotAction, BotActionViewModel>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PrevCmdId,
                    opt => opt.MapFrom(src => src.PrevCommand.Id))
                .ForMember(dest => dest.PrevCmdCode,
                    opt => opt.MapFrom(src => src.PrevCommand.Code))
                .ForMember(dest => dest.CurrentCmdId,
                    opt => opt.MapFrom(src => src.CurrentCommand.Id))
                .ForMember(dest => dest.CurrentCmdCode,
                    opt => opt.MapFrom(src => src.CurrentCommand.Code))
                .ForMember(dest => dest.CurrentCmdCond,
                    opt => opt.MapFrom(src => src.CurrentCommand.Condition))
                .ForMember(dest => dest.CurrentCmdDesc,
                    opt => opt.MapFrom(src => src.CurrentCommand.Description))
                .ForMember(dest => dest.NextCmdId,
                    opt => opt.MapFrom(src => src.NextCommand.Id))
                .ForMember(dest => dest.NextCmdCode,
                    opt => opt.MapFrom(src => src.NextCommand.Code));

            CreateMap<Command, CommandViewModel>()
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.Type.Id))
                .ForMember(dest => dest.TypeCode, opt => opt.MapFrom(src => src.Type.Code))
                .ForMember(dest => dest.TypeCondition, opt => opt.MapFrom(src => src.Type.Condition))
                .ForMember(dest => dest.TypeDesc, opt => opt.MapFrom(src => src.Type.Description))
                .ForMember(dest =>
                dest.ActionList, opt => opt.MapFrom(src =>
                src.BotActions))
                ;

            // CreateMap<CommandRole, CommandRoleViewModel>()
            //     .ForMember(dest => dest.)

            CreateMap<ClientBot, ClientBotViewModel>()
                .ForMember(dest => dest.ClientBotId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.Phone,
                    opt => opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.ClientRole,
                    opt => opt.MapFrom(src => ""));

            CreateMap<Student, StudentReceiverViewModel>()
                .ForMember(dest => dest.ClientId,
                    opt => opt.MapFrom(src => src.ClientBot.Id))
                .ForMember(dest => dest.UserId,
                    opt => opt.MapFrom(src => src.ClientBot.User.Id))
                .ForMember(dest => dest.Group,
                    opt => opt.MapFrom(src => src.Group))
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(src => src.ClientBot.User.Email))
                .ForMember(dest => dest.TeleChatId,
                    opt => opt.MapFrom(src => src.ClientBot.TeleChatId))
                .ForMember(dest => dest.VkChatId,
                    opt => opt.MapFrom(src => src.ClientBot.VkChatId))
                .ForMember(dest => dest.WhatsAppChatId,
                    opt => opt.MapFrom(src => src.ClientBot.WhatsAppChatId));

            CreateMap<Teacher, TeacherViewModel>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.ClientBot.User.Id))
                .ForMember(dest => dest.LastName,
                    opt => opt.MapFrom(src => src.ClientBot.User.LastName))
                .ForMember(dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.ClientBot.User.FirstName))
                .ForMember(dest => dest.MiddleName,
                    opt => opt.MapFrom(src => src.ClientBot.User.MiddleName))
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(src => src.ClientBot.User.Email))
                .ForMember(dest => dest.IsActive,
                    opt => opt.MapFrom(src => src.ClientBot.User.IsActive))
                .ForMember(dest => dest.CreatedDate,
                    opt => opt.MapFrom(src => src.ClientBot.User.CreatedDate.ToString()))
                .ForMember(dest => dest.VkIsActive,
                    opt => opt.MapFrom(src => string.IsNullOrEmpty(src.ClientBot.VkChatId) ? false : true))
                .ForMember(dest => dest.TeleIsActive,
                    opt => opt.MapFrom(src => string.IsNullOrEmpty(src.ClientBot.TeleChatId) ? false : true))
                .ForMember(dest => dest.WhatsAppIsActive,
                    opt => opt.MapFrom(src => string.IsNullOrEmpty(src.ClientBot.WhatsAppChatId) ? false : true))
                .ForMember(dest => dest.TeacherId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Group,
                    opt => opt.MapFrom(src => src.Group))
                .ForMember(dest => dest.IIN,
                    opt => opt.MapFrom(src => src.IIN));

            CreateMap<Student, StudentViewModel>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.ClientBot.User.Id))
                .ForMember(dest => dest.LastName,
                    opt => opt.MapFrom(src => src.ClientBot.User.LastName))
                .ForMember(dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.ClientBot.User.FirstName))
                .ForMember(dest => dest.MiddleName,
                    opt => opt.MapFrom(src => src.ClientBot.User.MiddleName))
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(src => src.ClientBot.User.Email))
                .ForMember(dest => dest.IsActive,
                    opt => opt.MapFrom(src => src.ClientBot.User.IsActive))
                .ForMember(dest => dest.VkIsActive,
                    opt => opt.MapFrom(src => string.IsNullOrEmpty(src.ClientBot.VkChatId) ? false : true))
                .ForMember(dest => dest.TeleIsActive,
                    opt => opt.MapFrom(src => string.IsNullOrEmpty(src.ClientBot.TeleChatId) ? false : true))
                .ForMember(dest => dest.WhatsAppIsActive,
                    opt => opt.MapFrom(src => string.IsNullOrEmpty(src.ClientBot.WhatsAppChatId) ? false : true))
                .ForMember(dest => dest.StudentId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TicketNumber,
                    opt => opt.MapFrom(src => src.TicketNumber))
                .ForMember(dest => dest.Group,
                    opt => opt.MapFrom(src => src.Group));

            CreateMap<AssignedTask, AssignedTaskViewModel>()
                .ForMember(dest => dest.TeacherFullName,
                opt => opt.MapFrom(src =>
                    (src.SetBy.ClientBot.User.LastName ?? "") +
                    (src.SetBy.ClientBot.User.FirstName ?? "") +
                    (src.SetBy.ClientBot.User.MiddleName ?? "")
                    ));
        }
    }
}