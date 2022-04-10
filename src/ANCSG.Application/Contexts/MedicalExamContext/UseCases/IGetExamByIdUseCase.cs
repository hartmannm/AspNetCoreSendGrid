using ANCSG.Application.Contexts.MedicalExamContext.DTOs;
using System;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.MedicalExamContext.UseCases
{
    public interface IGetExamByIdUseCase
    {
        Task<MedicalExamDTO> Execute(Guid id);
    }
}
