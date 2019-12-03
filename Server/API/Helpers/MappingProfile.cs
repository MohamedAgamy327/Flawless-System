using API.DTO.Users;
using AutoMapper;
using Domain.Entities;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //  DTO to Entity

            CreateMap<UserForAddDTO, User>();
            CreateMap<UserForEditDTO, User>();

            // Entity to DTO

            CreateMap<User, UserForGetDTO>()
                   .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString())); ;
        }

    }
}