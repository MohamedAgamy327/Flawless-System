using API.DTO.Checking;
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
using API.DTO.Waiting;
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
            CreateMap<SupplyItemForEditDTO, SupplyItem>();
            CreateMap<SupplyForEditDTO, Supply>()
                     .ForMember(x => x.SupplyItems, opt => opt.Ignore());


            CreateMap<CheckingForAddDTO, Checking>()
                    .ForMember(x => x.CheckingItems, opt => opt.Ignore())
                    .ForMember(x => x.CheckingTests, opt => opt.Ignore())
                    .ForMember(x => x.CheckingMedicines, opt => opt.Ignore());
            CreateMap<CheckingItemForAddDTO, CheckingItem>();
            CreateMap<CheckingMedicineForAddDTO, CheckingMedicine>();
            CreateMap<CheckingTestForAddDTO, CheckingTest>();
            CreateMap<CheckingForEditDTO, Checking>()
                     .ForMember(x => x.CheckingItems, opt => opt.Ignore())
                     .ForMember(x => x.CheckingTests, opt => opt.Ignore())
                     .ForMember(x => x.CheckingMedicines, opt => opt.Ignore());
            CreateMap<CheckingItemForEditDTO, CheckingItem>();
            CreateMap<CheckingMedicineForEditDTO, CheckingMedicine>();
            CreateMap<CheckingTestForEditDTO, CheckingTest>();

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
                  .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.Item.Name));
            CreateMap<Spending, SpendingForGetDTO>()
                 /* .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User.Name))*/;
            CreateMap<Medicine, MedicineForGetDTO>()
               .ForMember(dest => dest.FrequencyName, opt => opt.MapFrom(src => src.Frequency.Name))
               .ForMember(dest => dest.MedicineTypeName, opt => opt.MapFrom(src => src.MedicineType.Name));
            CreateMap<Waiting, WaitingForGetDTO>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.Name))
                .ForMember(dest => dest.PatientTelephone, opt => opt.MapFrom(src => src.Patient.Telephone));


            CreateMap<Checking, CheckingForGetDTO>();
            CreateMap<CheckingItem, CheckingItemForGetDTO>()
                     .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.Item.Name));
            CreateMap<CheckingTest, CheckingTestForGetDTO>()
                     .ForMember(dest => dest.TestName, opt => opt.MapFrom(src => src.Test.Name));
            CreateMap<CheckingMedicine, CheckingMedicineForGetDTO>()
                    .ForMember(dest => dest.MedicineName, opt => opt.MapFrom(src => src.Medicine.Name))
                    .ForMember(dest => dest.MedicineTypeId, opt => opt.MapFrom(src => src.Medicine.MedicineTypeId))
                    .ForMember(dest => dest.MedicineTypeName, opt => opt.MapFrom(src => src.Medicine.MedicineType.Name))
                    .ForMember(dest => dest.FrequencyId, opt => opt.MapFrom(src => src.FrequencyId))
                    .ForMember(dest => dest.FrequencyName, opt => opt.MapFrom(src => src.Frequency.Name))
                    .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration));

        }
    }
}