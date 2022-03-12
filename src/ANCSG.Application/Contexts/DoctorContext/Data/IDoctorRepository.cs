using ANCSG.Application.Data;
using ANCSG.Domain.Contexts.DoctorContext.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.DoctorContext.Data
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task CreateAsync(Doctor doctor);

        Task<Doctor> GetByIdAsync(Guid id);

        Task<IEnumerable<Doctor>> GetAllAsync();
    }
}
