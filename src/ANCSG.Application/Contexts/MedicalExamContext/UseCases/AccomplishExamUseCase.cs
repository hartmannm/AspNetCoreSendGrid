using ANCSG.Application.Contexts.MedicalExamContext.Data;
using ANCSG.Application.Data;
using ANCSG.Application.Map;
using ANCSG.Application.Notification;
using ANCSG.Application.UseCase;
using System;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.MedicalExamContext.UseCases
{
    public sealed class AccomplishExamUseCase : UseCaseBase, IAccomplishExamUseCase
    {
        private readonly IMedicalExamRepository _medicalExamRepository;

        public AccomplishExamUseCase(INotifier notifier, IDataManager dataManager, IMap map) : base(notifier, dataManager, map)
        {
            _medicalExamRepository = dataManager.MedicalExamRepository;
        }

        public async Task Execute(Guid id)
        {
            var exam = await _medicalExamRepository.GetByIdAsync(id);

            if (exam is null)
            {
                notifier.AddNotification("Exame informado não existe");
                return;
            }

            if (exam.IsAcomplished())
            {
                notifier.AddNotification("Exame já foi realizado");
                return;
            }

            exam.Accomplish();
            _medicalExamRepository.Update(exam);
            await _medicalExamRepository.SaveChangesAsync();
        }
    }
}
