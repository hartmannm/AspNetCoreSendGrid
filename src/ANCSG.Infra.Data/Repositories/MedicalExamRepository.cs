using ANCSG.Application.Contexts.MedicalExamContext.Data;
using ANCSG.Domain.Contexts.MedicalExamContext.Entities;
using ANCSG.Infra.Data.DataContext;
using System.Threading.Tasks;

namespace ANCSG.Infra.Data.Repositories
{
    public class MedicalExamRepository : Repository<MedicalExam>, IMedicalExamRepository
    {
        public MedicalExamRepository(SendGridContext context) : base(context)
        {
        }

        public async Task CreateAsync(MedicalExam medicalExam) => await context.MedicalExams.AddAsync(medicalExam);
    }
}
