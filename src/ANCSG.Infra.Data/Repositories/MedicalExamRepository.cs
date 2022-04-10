using ANCSG.Application.Contexts.MedicalExamContext.Data;
using ANCSG.Domain.Contexts.MedicalExamContext.Entities;
using ANCSG.Infra.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANCSG.Infra.Data.Repositories
{
    public class MedicalExamRepository : Repository<MedicalExam>, IMedicalExamRepository
    {
        public MedicalExamRepository(SendGridContext context) : base(context)
        {
        }

        public async Task CreateAsync(MedicalExam medicalExam) => await context.MedicalExams.AddAsync(medicalExam);

        public async Task<MedicalExam> GetByIdAsync(Guid id)
        {
            return await context.MedicalExams
                .Include(x => x.Doctor)
                .Include(x => x.Patient)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<MedicalExam>> GetAllAsync() => await context.MedicalExams.ToListAsync();

        public void Update(MedicalExam medicalExam)
        {
            context.MedicalExams.Update(medicalExam);
        }
    }
}
