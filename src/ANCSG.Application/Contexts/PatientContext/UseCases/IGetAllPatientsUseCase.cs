using ANCSG.Application.Contexts.PatientContext.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.PatientContext.UseCases
{
    public interface IGetAllPatientsUseCase
    {
        Task<IEnumerable<PatientDTO>> Execute();
    }
}
