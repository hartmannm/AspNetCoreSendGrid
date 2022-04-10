using ANCSG.Application.Data;
using ANCSG.Domain.Contexts.MedicalExamContext.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.MedicalExamContext.Data
{
    public interface IMedicalExamRepository : IRepository<MedicalExam>
    {
        Task CreateAsync(MedicalExam medicalExam);

        Task<MedicalExam> GetByIdAsync(Guid id);

        Task<IEnumerable<MedicalExam>> GetAllAsync();

        void Update(MedicalExam medicalExam);
    }
}
