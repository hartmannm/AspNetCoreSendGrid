using ANCSG.Application.Contexts.PatientContext.Data;
using ANCSG.Application.Contexts.PatientContext.DTOs;
using ANCSG.Application.Data;
using ANCSG.Application.Map;
using ANCSG.Application.MessageBus;
using ANCSG.Application.MessageBus.Constants;
using ANCSG.Application.MessageBus.Enums;
using ANCSG.Application.Notification;
using ANCSG.Application.UseCase;
using ANCSG.Domain.Contexts.PatientContext.Entities;
using ANCSG.Domain.Contexts.PatientContext.Events;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.PatientContext.UseCases
{
    public class RegisterPatientUseCase : UseCaseBase, IRegisterPatientUseCase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMessageBus _messageBus;

        public RegisterPatientUseCase(INotifier notifier, IDataManager dataManager, IMap map, IMessageBus messageBus) : base(notifier, dataManager, map)
        {
            _patientRepository = dataManager.PatientRepository;
            _messageBus = messageBus;
        }

        public async Task<PatientDTO> Execute(RegisterPatientRequest request)
        {
            if (!request.IsValid)
            {
                notifier.AddNotifications(request.Notifications);
                return null;
            }

            if (await _patientRepository.ExistsByEmailAsync(request.Email))
            {
                notifier.AddNotification("Paciente já cadastrado");
                return null;
            }

            var patient = map.Map<Patient>(request);

            await _patientRepository.CreateAsync(patient);
            await _patientRepository.SaveChangesAsync();

            var @event = new PatientRegisteredEvent(patient.Name.FirstName, patient.Name.LastName, patient.Email.Address);

            _messageBus.Publish(GetMessageBusConnectionConfig(), @event);
            return map.Map<PatientDTO>(patient);
        }

        private BusConnectionConfig GetMessageBusConnectionConfig()
        {
            var exchange = new BusExchangeConfigs(Exchanges.DOCTOR_PATIENT_REGISTER, EExchangeType.DIRECT, true);
            var queue = new BusQueueConfigs(Queues.PATIENT_REGISTERED);
            return new BusConnectionConfig(queue, exchange);
        }
    }
}
