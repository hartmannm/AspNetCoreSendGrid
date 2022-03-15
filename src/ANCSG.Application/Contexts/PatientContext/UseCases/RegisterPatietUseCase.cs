using ANCSG.Application.Data;
using ANCSG.Application.Map;
using ANCSG.Application.Notification;
using ANCSG.Application.UseCase;
using System;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.PatientContext.UseCases
{
    public class RegisterPatietUseCase : UseCaseBase, IRegisterPatietUseCase
    {
        public RegisterPatietUseCase(INotifier notifier, IDataManager dataManager, IMap map) : base(notifier, dataManager, map)
        {
        }

        public Task Execute(RegisterPatientRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
