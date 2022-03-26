using ANCSG.Application.Contexts.MedicalExamContext.DTOs;
using ANCSG.Domain.Contexts.MedicalExamContext.Entities;
using AutoMapper;

namespace ANCSG.Application.Map.AutoMapper
{
    public class MedicalExamProfile : Profile
    {
        public MedicalExamProfile()
        {
            MedicalExamToMedicalExamDTOMap();
        }

        private void MedicalExamToMedicalExamDTOMap()
        {
            CreateMap<MedicalExam, MedicalExamDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}
