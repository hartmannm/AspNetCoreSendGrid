using ANCSG.Application.Data;
using ANCSG.Application.Notification;
using ANCSG.Application.UseCase;
using System;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.PatientContext.UseCases
{
    public class RegisterPatietUseCase : UseCaseBase, IRegisterPatietUseCase
    {
        public RegisterPatietUseCase(INotifier notifier, IDataManager dataManager) : base(notifier, dataManager)
        {
        }

        public Task Execute(RegisterPatientRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
