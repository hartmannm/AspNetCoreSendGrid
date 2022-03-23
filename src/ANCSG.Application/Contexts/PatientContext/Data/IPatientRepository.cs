using ANCSG.Application.Data;
using ANCSG.Domain.Contexts.PatientContext.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.PatientContext.Data
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<bool> ExistsByEmailAsync(string email);

        Task CreateAsync(Patient patient);

        Task<Patient> GetByIdAsync(Guid id);

        Task<IEnumerable<Patient>> GetAllAsync();
    }
}