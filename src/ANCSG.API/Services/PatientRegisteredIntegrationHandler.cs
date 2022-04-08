using ANCSG.Application.Contexts.PatientContext.Events;
using ANCSG.Application.EmailNotification;
using ANCSG.Application.MessageBus;
using ANCSG.Application.MessageBus.Constants;
using ANCSG.Application.MessageBus.Enums;
using ANCSG.Domain.Contexts.PatientContext.Events;
using ANCSG.Domain.Email;

namespace ANCSG.API.Services
{
    public class PatientRegisteredIntegrationHandler : BackgroundService, IPatientRegisteredIntegrationEvent
    {
        private readonly IMessageBus _messageBus;
        private readonly IEmailSender _emailSender;
        private readonly EmailConfiguration _emailConfiguration;

        public PatientRegisteredIntegrationHandler(IMessageBus messageBus, IEmailSender emailSender, EmailConfiguration emailConfiguration)
        {
            _messageBus = messageBus;
            _emailSender = emailSender;
            _emailConfiguration = emailConfiguration;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _messageBus.SubscribeAsync<PatientRegisteredEvent>(GetMessageBusConnectionConfig(), Execute);
            return Task.CompletedTask;
        }

        public async Task Execute(PatientRegisteredEvent @event)
        {
            var destin = new EmailAddress { Address = @event.Email, Name = $"{@event.FirstName} {@event.LastName}" };
            var templateData = new { FirstName = @event.FirstName, LastName = @event.LastName };
            var email = new Email(_emailConfiguration.From, _emailConfiguration.Templates.PatientRegistered, templateData);

            email.AddAddress(destin);
            await _emailSender.SendAsync(email);
        }

        private BusConnectionConfig GetMessageBusConnectionConfig()
        {
            var exchange = new BusExchangeConfigs(Exchanges.DOCTOR_PATIENT_REGISTER, EExchangeType.DIRECT, true);
            var queue = new BusQueueConfigs(Queues.PATIENT_REGISTERED);
            return new BusConnectionConfig(queue, exchange);
        }
    }
}
