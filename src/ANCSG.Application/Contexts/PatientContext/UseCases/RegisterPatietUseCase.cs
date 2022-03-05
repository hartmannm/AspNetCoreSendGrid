using ANCSG.Application.UseCase;
using ANCSG.Domain.Contexts.PatientContext.Data;
using ANCSG.Domain.Notification;
using System;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.PatientContext.UseCases
{
    public class RegisterPatietUseCase : UseCaseBase, IRegisterPatietUseCase
    {
        private readonly IPatientRepository _patientRepository;

        public RegisterPatietUseCase(INotifier notifier, IPatientRepository patientRepository) : base(notifier)
        {
            _patientRepository = patientRepository;
        }

        public Task Execute(RegisterPatientRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
