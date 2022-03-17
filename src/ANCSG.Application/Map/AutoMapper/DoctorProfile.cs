using ANCSG.Application.Contexts.DoctorContext.DTOs;
using ANCSG.Application.Contexts.DoctorContext.UseCases;
using ANCSG.Domain.Contexts.DoctorContext.Entities;
using ANCSG.Domain.Contexts.DoctorContext.ValueObjects;
using ANCSG.Domain.DomainEntities.Enums;
using ANCSG.Domain.DomainEntities.ValueObjects;
using ANCSG.Domain.Extensions;
using AutoMapper;
using System;

namespace ANCSG.Application.Map.AutoMapper
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            RegisterDoctorRequestToDoctorMap();
            DoctorToDoctorDTOMap();
        }

        private void RegisterDoctorRequestToDoctorMap()
        {
            CreateMap<RegisterDoctorRequest, Doctor>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new Name(src.FirstName, src.LastName)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => new Email(src.Email)))
                .ForMember(dest => dest.CRM, opt => opt.MapFrom(src => new CRMRegister(src.CRMUF.toEnum<UF>(), src.CRMNumber)))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.MedicalExams, opt => opt.Ignore());
        }

        private void DoctorToDoctorDTOMap()
        {
            CreateMap<Doctor, DoctorDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name.FirstName} {src.Name.LastName}"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Address))
                .ForMember(dest => dest.CRM, opt => opt.MapFrom(src => $"{src.CRM.Number}/{src.CRM.Uf}"));
        }
    }
}
