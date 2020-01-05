using API.DTO.Diagnosis;
using API.DTO.Frequency;
using API.DTO.Items;
using API.DTO.Medicines;
using API.DTO.MedicineType;
using API.DTO.Patients;
using API.DTO.Spendings;
using API.DTO.Supply;
using API.DTO.Test;
using API.DTO.User;
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
            
            CreateMap<DiagnosisForAddDTO, Diagnosis>();
            CreateMap<DiagnosisForEditDTO, Diagnosis>();
            
            CreateMap<MedicineTypeForAddDTO, MedicineType>();
            CreateMap<MedicineTypeForEditDTO, MedicineType>();

            CreateMap<SupplyItemForAddDTO, SupplyItem>();
            CreateMap<SupplyForAddDTO, Supply>()
                     .ForMember(x => x.SupplyItems, opt => opt.Ignore());

            // Entity to DTO

            CreateMap<Test, TestForGetDTO>();
            CreateMap<User, UserForGetDTO>();
            CreateMap<Item, ItemForGetDTO>();
            CreateMap<Supply, SupplyForGetDTO>();
            CreateMap<Patient, PatientForGetDTO>();
            CreateMap<Diagnosis, DiagnosisForGetDTO>();
            CreateMap<Frequency, FrequencyForGetDTO>();
            CreateMap<MedicineType, MedicineTypeForGetDTO>();
            CreateMap<SupplyItem, SupplyItemForGetDTO>()
                  .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item.Name));       
            CreateMap<Spending, SpendingForGetDTO>()
                  .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User.Name));
            CreateMap<Medicine, MedicineForGetDTO>()
               .ForMember(dest => dest.Frequency, opt => opt.MapFrom(src => src.Frequency.Name))
               .ForMember(dest => dest.MedicineType, opt => opt.MapFrom(src => src.MedicineType.Name));       
        }

    }
}