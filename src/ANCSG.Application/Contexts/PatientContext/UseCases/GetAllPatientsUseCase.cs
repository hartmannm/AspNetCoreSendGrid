using ANCSG.Application.Contexts.PatientContext.Data;
using ANCSG.Application.Contexts.PatientContext.DTOs;
using ANCSG.Application.Data;
using ANCSG.Application.Map;
using ANCSG.Application.Notification;
using ANCSG.Application.UseCase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.PatientContext.UseCases
{
    public class GetAllPatientsUseCase : UseCaseBase, IGetAllPatientsUseCase
    {
        private readonly IPatientRepository _patientRepository;

        public GetAllPatientsUseCase(INotifier notifier, IDataManager dataManager, IMap map) : base(notifier, dataManager, map)
        {
            _patientRepository = dataManager.PatientRepository;
        }

        public async Task<IEnumerable<PatientDTO>> Execute()
        {
            var patients = await _patientRepository.GetAllAsync();

            return map.Map<IEnumerable<PatientDTO>>(patients);
        }
    }
}
