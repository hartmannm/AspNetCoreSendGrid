using System;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.MedicalExamContext.UseCases
{
    public interface IAccomplishExamUseCase
    {
        Task Execute(Guid id);
    }
}
