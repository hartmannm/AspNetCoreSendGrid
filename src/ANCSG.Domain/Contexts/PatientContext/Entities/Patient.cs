using ANCSG.Domain.Contexts.MedicalExamContext.Entities;
using ANCSG.Domain.DomainEntities;
using System;
using System.Collections.Generic;

namespace ANCSG.Domain.Contexts.PatientContext.Entities
{
    public class Patient : Person, IAggregateRoot
    {
        public DateTime BirthDate { get; private set; }

        public ICollection<MedicalExam> MedicalExams { get; private set; }

        public Patient()
        {
        }

        public Patient(string name, string email, string contact, DateTime birthDate) : base(name, email, contact)
        {
            BirthDate = birthDate;
            MedicalExams = new List<MedicalExam>();
        }
    }
}
