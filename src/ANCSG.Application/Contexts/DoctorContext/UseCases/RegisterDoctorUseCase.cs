using ANCSG.Application.UseCase;
using ANCSG.Domain.Contexts.DoctorContext.Data;
using ANCSG.Domain.Notification;
using System;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.DoctorContext.UseCases
{
    public class RegisterDoctorUseCase : UseCaseBase, IRegisterDoctorUseCase
    {
        private readonly IDoctorRepository _doctorRepository;

        public RegisterDoctorUseCase(INotifier notifier, IDoctorRepository doctorRepository) : base(notifier)
        {
            this._doctorRepository = doctorRepository;
        }

        public async Task Execute(RegisterDoctorRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
