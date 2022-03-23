using ANCSG.Application.Contexts.PatientContext.Data;
using ANCSG.Application.Contexts.PatientContext.DTOs;
using ANCSG.Application.Data;
using ANCSG.Application.Map;
using ANCSG.Application.Notification;
using ANCSG.Application.UseCase;
using System;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.PatientContext.UseCases
{
    public class GetPatientByIdUseCase : UseCaseBase, IGetPatientByIdUseCase
    {
        private readonly IPatientRepository _patientRepository;

        public GetPatientByIdUseCase(INotifier notifier, IDataManager dataManager, IMap map) : base(notifier, dataManager, map)
        {
            _patientRepository = dataManager.PatientRepository;
        }

        public async Task<PatientDTO> Execute(Guid id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);

            return patient is null ? null : map.Map<PatientDTO>(patient);
        }
    }
}
