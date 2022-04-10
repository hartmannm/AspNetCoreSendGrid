using ANCSG.Application.Contexts.MedicalExamContext.Data;
using ANCSG.Application.Contexts.PatientContext.Events;
using ANCSG.Application.EmailNotification;
using ANCSG.Application.MessageBus;
using ANCSG.Application.MessageBus.Constants;
using ANCSG.Application.MessageBus.Enums;
using ANCSG.Domain.Contexts.MedicalExamContext.Events;
using ANCSG.Domain.Email;
using ANCSG.Domain.Extensions;

namespace ANCSG.API.Services
{
    public class PatientExamScheduledIntegrationHandler : BackgroundService, IPatientExamScheduledEvent
    {
        private readonly IMessageBus _messageBus;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IEmailSender _emailSender;
        private readonly EmailConfiguration _emailConfiguration;

        public PatientExamScheduledIntegrationHandler(IMessageBus messageBus,
                                                     IServiceScopeFactory serviceScopeFactory,
                                                     IEmailSender emailSender,
                                                     EmailConfiguration emailConfiguration)
        {
            _messageBus = messageBus;
            _serviceScopeFactory = serviceScopeFactory;
            _emailSender = emailSender;
            _emailConfiguration = emailConfiguration;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _messageBus.SubscribeAsync<ExamScheduledEvent>(GetMessageBusConnectionConfig(), Execute);
            return Task.CompletedTask;
        }

        public async Task Execute(ExamScheduledEvent @event)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var medicalExamRepository = scope.ServiceProvider.GetRequiredService<IMedicalExamRepository>();
                var exam = await medicalExamRepository.GetByIdAsync(@event.ExamId);

                var destin = new EmailAddress { Address = exam.Patient.Email.Address, Name = exam.Patient.Name.FullName() };
                var templateData = new
                {
                    DoctorName = exam.Doctor.Name.FullName(),
                    PatientName = exam.Patient.Name.FirstName,
                    Crm = exam.Doctor.CRM.Description(),
                    ExamDate = exam.Date.ToDateFormat(),
                    ExamHour = exam.Date.ToTimeFomat()
                };
                var email = new Email(_emailConfiguration.From, _emailConfiguration.Templates.PatientExamScheduled, templateData);

                email.AddAddress(destin);
                await _emailSender.SendAsync(email);
            }

        }

        private BusConnectionConfig GetMessageBusConnectionConfig()
        {
            var exchange = new BusExchangeConfigs(Exchanges.MEDICAL_EXAM_SCHEDULED, EExchangeType.FANOUT, true);
            var queue = new BusQueueConfigs(Queues.PATIENT_EXAM_SCHEDULED);
            return new BusConnectionConfig(queue, exchange, RoutingKeys.MEDICAL_EXAMS_SCHEDULED);
        }
    }
}
