using ANCSG.Domain.Contexts.DoctorContext.Data;
using ANCSG.Domain.Contexts.DoctorContext.Entities;
using ANCSG.Infra.Data.DataContext;

namespace ANCSG.Infra.Data.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(SendGridContext context) : base(context)
        {
        }
    }
}
