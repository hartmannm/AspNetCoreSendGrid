using ANCSG.Application.Contexts.DoctorContext.Events;
using ANCSG.Application.Contexts.MedicalExamContext.Data;
using ANCSG.Application.EmailNotification;
using ANCSG.Application.MessageBus;
using ANCSG.Application.MessageBus.Constants;
using ANCSG.Application.MessageBus.Enums;
using ANCSG.Domain.Contexts.MedicalExamContext.Events;
using ANCSG.Domain.Email;
using ANCSG.Domain.Extensions;

namespace ANCSG.API.Services
{
    public class DoctorExamScheduledIntegrationHandler : BackgroundService, IDoctorExamScheduledEvent
    {
        private readonly IMessageBus _messageBus;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IEmailSender _emailSender;
        private readonly EmailConfiguration _emailConfiguration;

        public DoctorExamScheduledIntegrationHandler(IMessageBus messageBus,
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

                var destin = new EmailAddress { Address = exam.Doctor.Email.Address, Name = exam.Doctor.Name.FullName() };
                var templateData = new
                {
                    DoctorName = exam.Doctor.Name.FirstName,
                    PatientName = exam.Patient.Name.FullName(),
                    BirthDate = exam.Patient.BirthDate.ToDateFormat(),
                    ExamDate = exam.Date.ToDateFormat(),
                    ExamHour = exam.Date.ToTimeFomat()
                };
                var email = new Email(_emailConfiguration.From, _emailConfiguration.Templates.DoctorExamScheduled, templateData);

                email.AddAddress(destin);
                await _emailSender.SendAsync(email);
            }
        }

        private BusConnectionConfig GetMessageBusConnectionConfig()
        {
            var exchange = new BusExchangeConfigs(Exchanges.MEDICAL_EXAM_SCHEDULED, EExchangeType.FANOUT, true);
            var queue = new BusQueueConfigs(Queues.DOCTOR_EXAM_SCHEDULED);
            return new BusConnectionConfig(queue, exchange, RoutingKeys.MEDICAL_EXAMS_SCHEDULED);
        }
    }
}
