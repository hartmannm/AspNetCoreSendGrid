using ANCSG.Application.Contexts.PatientContext.Data;
using ANCSG.Application.Contexts.PatientContext.DTOs;
using ANCSG.Application.Data;
using ANCSG.Application.Map;
using ANCSG.Application.Notification;
using ANCSG.Application.UseCase;
using ANCSG.Domain.Contexts.PatientContext.Entities;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.PatientContext.UseCases
{
    public class RegisterPatientUseCase : UseCaseBase, IRegisterPatientUseCase
    {
        private readonly IPatientRepository _patientRepository;

        public RegisterPatientUseCase(INotifier notifier, IDataManager dataManager, IMap map, IPatientRepository patientRepository) : base(notifier, dataManager, map)
        {
            _patientRepository = dataManager.PatientRepository;
        }

        public async Task<PatientDTO> Execute(RegisterPatientRequest request)
        {
            if (!request.IsValid)
            {
                notifier.AddNotifications(request.Notifications);
                return null;
            }

            if (await _patientRepository.ExistsByEmailAsync(request.Email))
            {
                notifier.AddNotification("Paciente já cadastrado");
                return null;
            }

            var patient = map.Map<Patient>(request);

            await _patientRepository.CreateAsync(patient);
            await _patientRepository.SaveChangesAsync();

            return map.Map<PatientDTO>(patient);
        }
    }
}
