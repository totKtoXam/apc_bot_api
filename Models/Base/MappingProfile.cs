using System;
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
        }
    }
}