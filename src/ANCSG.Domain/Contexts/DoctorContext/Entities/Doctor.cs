using ANCSG.Domain.Contexts.MedicalExamContext.Entities;
using ANCSG.Domain.DomainEntities;
using ANCSG.Domain.DomainEntities.Enums;
using System.Collections.Generic;

namespace ANCSG.Domain.Contexts.DoctorContext.Entities
{
    public class Doctor : Person, IAggregateRoot
    {
        public UF CRMUF { get; set; }

        public long CRMNumber { get; private set; }

        public ICollection<MedicalExam> MedicalExams { get; private set; }

        public Doctor()
        {
        }

        public Doctor(string name, string email, string contact, UF CRMUF, long CRMNumber) : base(name, email, contact)
        {
            this.CRMUF = CRMUF;
            this.CRMNumber = CRMNumber;
            MedicalExams = new List<MedicalExam>();
        }
    }
}
