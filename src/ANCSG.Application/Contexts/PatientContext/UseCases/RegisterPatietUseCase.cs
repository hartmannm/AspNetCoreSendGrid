using ANCSG.Application.UseCase;
using ANCSG.Domain.Data;
using ANCSG.Domain.Notification;
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
