using ANCSG.Application.Contexts.DoctorContext.Data;
using ANCSG.Application.Contexts.MedicalExamContext.Data;
using ANCSG.Application.Contexts.MedicalExamContext.DTOs;
using ANCSG.Application.Contexts.PatientContext.Data;
using ANCSG.Application.Data;
using ANCSG.Application.Map;
using ANCSG.Application.MessageBus;
using ANCSG.Application.MessageBus.Constants;
using ANCSG.Application.MessageBus.Enums;
using ANCSG.Application.Notification;
using ANCSG.Application.UseCase;
using ANCSG.Domain.Contexts.DoctorContext.Entities;
using ANCSG.Domain.Contexts.MedicalExamContext.Entities;
using ANCSG.Domain.Contexts.MedicalExamContext.Events;
using ANCSG.Domain.Contexts.PatientContext.Entities;
using System;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.MedicalExamContext.UseCases
{
    public class ScheduleMedicalExamUseCase : UseCaseBase, IScheduleMedicalExamUseCase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMedicalExamRepository _medicalExamRepository;
        private readonly IMessageBus _messageBus;

        public ScheduleMedicalExamUseCase(INotifier notifier, IDataManager dataManager, IMap map, IMessageBus messageBus) : base(notifier, dataManager, map)
        {
            _patientRepository = dataManager.PatientRepository;
            _doctorRepository = dataManager.DoctorRepository;
            _medicalExamRepository = dataManager.MedicalExamRepository;
            _messageBus = messageBus;
        }

        public async Task<MedicalExamDTO> Execute(ScheduleMedicalExamRequest request)
        {
            if (!request.IsValid)
            {
                notifier.AddNotifications(request.Notifications);
                return null;
            }

            var patient = await GetPatientAsync(request.PatientId);
            var doctor = await GetDoctorAsync(request.DoctorId);

            if (patient is null || doctor is null) return null;

            var medicalExam = new MedicalExam(request.DateScheduled, doctor, patient);

            await _medicalExamRepository.CreateAsync(medicalExam);
            await _medicalExamRepository.SaveChangesAsync();

            var @event = new ExamScheduledEvent(medicalExam.Id);

            _messageBus.Publish(GetMessageBusConnectionConfig(), @event);
            return map.Map<MedicalExamDTO>(medicalExam);
        }

        private async Task<Patient> GetPatientAsync(Guid patientId)
        {
            var patient = await _patientRepository.GetByIdAsync(patientId);

            if (patient is null)
                notifier.AddNotification("Paciente não encontrado");

            return patient;
        }

        private async Task<Doctor> GetDoctorAsync(Guid doctorId)
        {
            var doctor = await _doctorRepository.GetByIdAsync(doctorId);

            if (doctor is null)
                notifier.AddNotification("Médico não encontrado");

            return doctor;
        }

        private BusConnectionConfig GetMessageBusConnectionConfig()
        {
            var exchange = new BusExchangeConfigs(Exchanges.MEDICAL_EXAM_SCHEDULED, EExchangeType.FANOUT, true);
            return new BusConnectionConfig(exchange, RoutingKeys.MEDICAL_EXAMS_SCHEDULED);
        }
    }
}
