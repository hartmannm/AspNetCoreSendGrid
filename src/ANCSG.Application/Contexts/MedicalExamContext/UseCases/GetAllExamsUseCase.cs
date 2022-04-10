using ANCSG.Application.Contexts.MedicalExamContext.Data;
using ANCSG.Application.Contexts.MedicalExamContext.DTOs;
using ANCSG.Application.Data;
using ANCSG.Application.Map;
using ANCSG.Application.Notification;
using ANCSG.Application.UseCase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.MedicalExamContext.UseCases
{
    public sealed class GetAllExamsUseCase : UseCaseBase, IGetAllExamsUseCase
    {
        private readonly IMedicalExamRepository _medicalExamRepository;

        public GetAllExamsUseCase(INotifier notifier, IDataManager dataManager, IMap map) : base(notifier, dataManager, map)
        {
            _medicalExamRepository = dataManager.MedicalExamRepository;
        }

        public async Task<IEnumerable<MedicalExamDTO>> Execute()
        {
            var exams = await _medicalExamRepository.GetAllAsync();

            return map.Map<IEnumerable<MedicalExamDTO>>(exams);
        }
    }
}
