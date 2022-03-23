using ANCSG.Application.Contexts.PatientContext.DTOs;
using ANCSG.Application.Contexts.PatientContext.UseCases;
using ANCSG.Domain.Contexts.PatientContext.Entities;
using ANCSG.Domain.DomainEntities.ValueObjects;
using AutoMapper;

namespace ANCSG.Application.Map.AutoMapper
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            PatientToPatientDTOMap();
            RegisterPatientRequestToPatientMap();
        }

        private void PatientToPatientDTOMap()
        {
            CreateMap<Patient, PatientDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name.FirstName} {src.Name.LastName}"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Address));
        }

        private void RegisterPatientRequestToPatientMap()
        {
            CreateMap<RegisterPatientRequest, Patient>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new Name(src.FirstName, src.LastName)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => new Email(src.Email)))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.MedicalExams, opt => opt.Ignore());
        }
    }
}
