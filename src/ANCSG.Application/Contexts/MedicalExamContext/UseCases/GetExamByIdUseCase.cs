using ANCSG.Application.Contexts.MedicalExamContext.Data;
using ANCSG.Application.Contexts.MedicalExamContext.DTOs;
using ANCSG.Application.Data;
using ANCSG.Application.Map;
using ANCSG.Application.Notification;
using ANCSG.Application.UseCase;
using System;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.MedicalExamContext.UseCases
{
    public sealed class GetExamByIdUseCase : UseCaseBase, IGetExamByIdUseCase
    {
        private readonly IMedicalExamRepository _medicalExamRepository;

        public GetExamByIdUseCase(INotifier notifier, IDataManager dataManager, IMap map) : base(notifier, dataManager, map)
        {
            _medicalExamRepository = dataManager.MedicalExamRepository;
        }

        public async Task<MedicalExamDTO> Execute(Guid id)
        {
            var medicalExam = await _medicalExamRepository.GetByIdAsync(id);

            return medicalExam is null ? null : map.Map<MedicalExamDTO>(medicalExam);
        }
    }
}
