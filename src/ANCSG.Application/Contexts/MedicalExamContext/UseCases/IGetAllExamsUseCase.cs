using ANCSG.Application.Contexts.MedicalExamContext.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.MedicalExamContext.UseCases
{
    public interface IGetAllExamsUseCase
    {
        Task<IEnumerable<MedicalExamDTO>> Execute();
    }
}
