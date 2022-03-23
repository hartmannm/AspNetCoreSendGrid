using ANCSG.Application.Contexts.PatientContext.Data;
using ANCSG.Domain.Contexts.PatientContext.Entities;
using ANCSG.Infra.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANCSG.Infra.Data.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(SendGridContext context) : base(context)
        {
        }

        public async Task CreateAsync(Patient patient)
        {
            await context.Patients.AddAsync(patient);
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await context.Patients.AnyAsync(x => x.Email.Address.Equals(email));
        }

        public async Task<Patient> GetByIdAsync(Guid id)
        {
            return await context.Patients.FindAsync(id);
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await context.Patients.ToListAsync();
        }
    }
}
