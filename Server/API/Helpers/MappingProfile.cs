using API.DTO.Items;
using API.DTO.Medicines;
using API.DTO.Patients;
using API.DTO.Spendings;
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
            CreateMap<MedicineForAddDTO, Medicine>();
            CreateMap<MedicineForEditDTO, Medicine>();
            CreateMap<ItemForAddDTO, Item>();
            CreateMap<ItemForEditDTO, Item>();
            CreateMap<PatientForAddDTO, Patient>();
            CreateMap<PatientForEditDTO, Patient>();
            CreateMap<SpendingForAddDTO, Spending>();
            CreateMap<SpendingForEditDTO, Spending>();

            // Entity to DTO

            CreateMap<User, UserForGetDTO>()
                   .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
            CreateMap<Medicine, MedicineForGetDTO>();
            CreateMap<Item, ItemForGetDTO>();
            CreateMap<Patient, PatientForGetDTO>()
                 .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()));
            CreateMap<Spending, SpendingForGetDTO>();
        }

    }
}