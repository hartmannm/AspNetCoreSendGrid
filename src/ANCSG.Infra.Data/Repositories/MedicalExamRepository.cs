using ANCSG.Domain.Contexts.MedicalExamContext.Data;
using ANCSG.Domain.Contexts.MedicalExamContext.Entities;
using ANCSG.Infra.Data.DataContext;

namespace ANCSG.Infra.Data.Repositories
{
    public class MedicalExamRepository : Repository<MedicalExam>, IMedicalExamRepository
    {
        public MedicalExamRepository(SendGridContext context) : base(context)
        {
        }
    }
}
