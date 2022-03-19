using ANCSG.Application.Contexts.DoctorContext.Data;
using ANCSG.Application.Contexts.DoctorContext.DTOs;
using ANCSG.Application.Data;
using ANCSG.Application.Map;
using ANCSG.Application.MessageBus;
using ANCSG.Application.MessageBus.Constants;
using ANCSG.Application.Notification;
using ANCSG.Application.UseCase;
using ANCSG.Domain.Contexts.DoctorContext.Entities;
using ANCSG.Domain.Contexts.DoctorContext.Events;
using ANCSG.Domain.DomainEntities.Enums;
using ANCSG.Domain.Extensions;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.DoctorContext.UseCases
{
    public class RegisterDoctorUseCase : UseCaseBase, IRegisterDoctorUseCase
    {
        private readonly IMessageBus _messageBus;
        private readonly IDoctorRepository _doctorRepository;

        public RegisterDoctorUseCase(INotifier notifier, IDataManager dataManager, IMap map, IMessageBus messageBus) : base(notifier, dataManager, map)
        {
            _doctorRepository = dataManager.DoctorRepository;
            _messageBus = messageBus;
        }

        public async Task<DoctorDTO> Execute(RegisterDoctorRequest request)
        {
            if (!request.IsValid)
            {
                notifier.AddNotifications(request.Notifications);
                return null;
            }
            
            if (await Exists(request.Email, request.CRMUF, request.CRMNumber))
            {
                notifier.AddNotification("Doutor já cadastrado");
                return null;
            }

            var doctor = map.Map<Doctor>(request);

            await _doctorRepository.CreateAsync(doctor);
            await _doctorRepository.SaveChangesAsync();

            var @event = new DoctorRegisteredEvent(doctor.Name.FirstName, doctor.Name.LastName, doctor.Email.Address);
            _messageBus.Publish(Queues.USER_REGISTERED, @event, Exchanges.NOTIFICATION);

            return map.Map<DoctorDTO>(doctor);
        }

        private async Task<bool> Exists(string address, string crmUf, long crmNumber)
        {
            return await _doctorRepository.ExistsByEmailOrCRMAsync(address, crmUf.toEnum<UF>(), crmNumber);
        }
    }
}
