using ANCSG.Application.Data;
using ANCSG.Domain.Contexts.PatientContext.Entities;

namespace ANCSG.Application.Contexts.PatientContext.Data
{
    public interface IPatientRepository : IRepository<Patient>
    {
    }
}