using ANCSG.Application.Contexts.PatientContext.Data;
using ANCSG.Domain.Contexts.PatientContext.Entities;
using ANCSG.Infra.Data.DataContext;

namespace ANCSG.Infra.Data.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(SendGridContext context) : base(context)
        {
        }
    }
}
