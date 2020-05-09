using System;
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
                .ForMember(dest => dest.PrevStepId,
                    opt => opt.MapFrom(
                        src => src.PrevStep != null ? src.PrevStep.Id.ToString() : ""))
                .ForMember(dest => dest.PrevStepCode,
                    opt => opt.MapFrom(
                        src => src.PrevStep != null ? src.PrevStep.Code : ""))
                .ForMember(dest => dest.NextStepId,
                    opt => opt.MapFrom(
                        src => src.NextStep != null ? src.NextStep.Id.ToString() : ""))
                .ForMember(dest => dest.NextStepCode,
                    opt => opt.MapFrom(
                        src => src.NextStep != null ? src.NextStep.Code : ""));

            CreateMap<Step, StepViewModel>()
                .ForMember(dest => dest.StepId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.StepCode,
                    opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.StepName,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StepCondition,
                    opt => opt.MapFrom(src => src.Condition));

            CreateMap<ClientBot, ClientBotViewModel>();

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
        }
    }
}