using ANCSG.Domain.Contexts.DoctorContext.Entities;
using ANCSG.Domain.Contexts.MedicalExamContext.Enums;
using ANCSG.Domain.Contexts.PatientContext.Entities;
using ANCSG.Domain.DomainEntities;
using System;

namespace ANCSG.Domain.Contexts.MedicalExamContext.Entities
{
    public class MedicalExam : Entity, IAggregateRoot
    {
        public DateTime Date { get; private set; }

        public Guid DoctorId { get; private set; }

        public Guid PatientId { get; private set; }

        public Status Status { get; private set; }

        // EF Relations
        public Doctor Doctor { get; private set; }

        public Patient Patient { get; private set; }

        public MedicalExam()
        {
        }

        public MedicalExam(DateTime date, Doctor doctor, Patient patient) : base()
        {
            Date = date;
            DoctorId = Doctor.Id;
            Doctor = doctor;
            PatientId = patient.Id;
            Patient = patient;
            Status = Status.Scheduled;
        }
    }
}
