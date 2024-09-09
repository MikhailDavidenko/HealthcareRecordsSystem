using AutoMapper;
using HealthcareRecordsAPI.DTOs;

namespace HealthcareRecordsAPI.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Маппинг для PatientEditDto
            CreateMap<Patient, PatientEditDto>()
                .ReverseMap(); // Позволяет преобразовывать в обе стороны

            // Маппинг для PatientDisplayDto
            CreateMap<Patient, PatientDisplayDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.LastName} {src.FirstName} {src.MiddleName}"))
                .ForMember(dest => dest.SectionName, opt => opt.MapFrom(src => src.Section != null ? src.Section.Number : null));

            // Маппинг для DoctorEditDto
            CreateMap<Doctor, DoctorEditDto>()
                .ReverseMap(); // Позволяет преобразовывать в обе стороны

            // Маппинг для DoctorDisplayDto
            CreateMap<Doctor, DoctorDisplayDto>()
                .ForMember(dest => dest.CabinetName, opt => opt.MapFrom(src => src.Cabinet != null ? src.Cabinet.Number : null))
            .ForMember(dest => dest.SpecializationName, opt => opt.MapFrom(src => src.Specialization != null ? src.Specialization.Name : null))
            .ForMember(dest => dest.SectionName, opt => opt.MapFrom(src => src.Section != null ? src.Section.Number : null));

        }
    }
}
