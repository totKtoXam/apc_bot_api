using System;
using apc_bot_api.Models.Bots;
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
        }
    }
}