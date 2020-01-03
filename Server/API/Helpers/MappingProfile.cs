using API.DTO.Frequency;
using API.DTO.Items;
using API.DTO.Medicines;
using API.DTO.MedicineType;
using API.DTO.Patients;
using API.DTO.Spendings;
using API.DTO.Test;
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
            CreateMap<ItemForAddDTO, Item>();
            CreateMap<ItemForEditDTO, Item>();
            CreateMap<TestForAddDTO, Test>();
            CreateMap<TestForEditDTO, Test>();
            CreateMap<PatientForAddDTO, Patient>();
            CreateMap<PatientForEditDTO, Patient>();
            CreateMap<MedicineForAddDTO, Medicine>();
            CreateMap<MedicineForEditDTO, Medicine>();
            CreateMap<SpendingForAddDTO, Spending>();
            CreateMap<SpendingForEditDTO, Spending>();
            CreateMap<FrequencyForAddDTO, Frequency>();
            CreateMap<FrequencyForEditDTO, Frequency>();
            CreateMap<MedicineTypeForAddDTO, MedicineType>();
            CreateMap<MedicineTypeForEditDTO, MedicineType>();

            // Entity to DTO
            CreateMap<Frequency, FrequencyForGetDTO>();
            CreateMap<Test, TestForGetDTO>();
            CreateMap<MedicineType, MedicineTypeForGetDTO>();
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