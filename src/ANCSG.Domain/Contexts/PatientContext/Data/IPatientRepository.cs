using ANCSG.Domain.Contexts.PatientContext.Entities;
using ANCSG.Domain.Data;

namespace ANCSG.Domain.Contexts.PatientContext.Data
{
    public interface IPatientRepository : IRepository<Patient>
    {
    }
}