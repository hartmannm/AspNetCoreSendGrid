using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.DoctorContext.UseCases
{
    public interface IRegisterDoctorUseCase
    {
        Task Execute(RegisterDoctorRequest request);
    }
}
