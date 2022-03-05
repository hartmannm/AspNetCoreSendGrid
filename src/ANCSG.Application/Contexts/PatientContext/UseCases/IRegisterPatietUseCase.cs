using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.PatientContext.UseCases
{
    public interface IRegisterPatietUseCase
    {
        Task Execute(RegisterPatientRequest request);
    }
}
