using ANCSG.Domain.Contexts.DoctorContext.Entities;
using ANCSG.Domain.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANCSG.Domain.Contexts.DoctorContext.Data
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task CreateAsync(Doctor doctor);

        Task<Doctor> GetByIdAsync(Guid id);

        Task<IEnumerable<Doctor>> GetAllAsync();
    }
}
