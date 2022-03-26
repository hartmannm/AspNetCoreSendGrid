using ANCSG.Application.Contexts.MedicalExamContext.DTOs;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.MedicalExamContext.UseCases
{
    public interface IScheduleMedicalExamUseCase
    {
        Task<MedicalExamDTO> Execute(ScheduleMedicalExamRequest request);
    }
}
