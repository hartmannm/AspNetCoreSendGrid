using ANCSG.Application.Contexts.PatientContext.DTOs;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.PatientContext.UseCases
{
    public interface IRegisterPatientUseCase
    {
        Task<PatientDTO> Execute(RegisterPatientRequest request);
    }
}
