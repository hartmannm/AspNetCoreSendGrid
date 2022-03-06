using ANCSG.Domain.Contexts.DoctorContext.Data;
using ANCSG.Domain.Contexts.DoctorContext.Entities;
using ANCSG.Infra.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANCSG.Infra.Data.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(SendGridContext context) : base(context)
        {
        }

        public async Task CreateAsync(Doctor doctor) => await context.AddAsync(doctor);

        public async Task<Doctor> GetByIdAsync(Guid id) => await context.Doctors.FindAsync(id);

        public async Task<IEnumerable<Doctor>> GetAllAsync() => await context.Doctors.ToListAsync();
    }
}
