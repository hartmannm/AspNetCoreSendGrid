using ANCSG.Application.Contexts.DoctorContext.DTOs;
using ANCSG.Application.Contexts.DoctorContext.Factories;
using ANCSG.Application.Data;
using ANCSG.Application.Map;
using ANCSG.Application.MessageBus;
using ANCSG.Application.MessageBus.Constants;
using ANCSG.Application.Notification;
using ANCSG.Application.UseCase;
using ANCSG.Domain.Contexts.DoctorContext.Events;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.DoctorContext.UseCases
{
    public class RegisterDoctorUseCase : UseCaseBase, IRegisterDoctorUseCase
    {
        private readonly IMessageBus _messageBus;

        public RegisterDoctorUseCase(INotifier notifier, IDataManager dataManager, IMap map, IMessageBus messageBus) : base(notifier, dataManager, map)
        {
            _messageBus = messageBus;
        }

        public async Task<DoctorDTO> Execute(RegisterDoctorRequest request)
        {
            var doctor = DoctorFactory.Create(request);
            var repository = dataManager.DoctorRepository;

            await repository.CreateAsync(doctor);
            await repository.SaveChangesAsync();

            var @event = new DoctorRegisteredEvent(doctor.Name.FirstName, doctor.Name.LastName, doctor.Email.Address);
            _messageBus.Publish(Queues.USER_REGISTERED, @event, Exchanges.NOTIFICATION);

            return (DoctorDTO)doctor;
        }
    }
}
