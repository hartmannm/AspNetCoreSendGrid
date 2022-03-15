using ANCSG.Domain.Contexts.DoctorContext.ValueObjects;
using ANCSG.Domain.Contexts.MedicalExamContext.Entities;
using ANCSG.Domain.DomainEntities;
using ANCSG.Domain.DomainEntities.Enums;
using System.Collections.Generic;

namespace ANCSG.Domain.Contexts.DoctorContext.Entities
{
    public class Doctor : Person, IAggregateRoot
    {
        public CRMRegister CRM { get; private set; }

        public ICollection<MedicalExam> MedicalExams { get; private set; }

        public Doctor()
        {
        }

        public Doctor(string firstName, string lastName, string email, UF CRMUF, long CRMNumber)
            : base(firstName, lastName, email)
        {
            CRM = new CRMRegister(CRMUF, CRMNumber);
            MedicalExams = new List<MedicalExam>();
        }
    }
}
