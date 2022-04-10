using ANCSG.Application.Contexts.PatientContext.UseCases;
using ANCSG.Application.Notification;
using Microsoft.AspNetCore.Mvc;

namespace ANCSG.API.Controllers
{

    [Route("api/patient")]
    public class PatientController : BaseController
    {
        private readonly IRegisterPatientUseCase _registerPatientUseCase;
        private readonly IGetPatientByIdUseCase _getPatientByIdUseCase;
        private readonly IGetAllPatientsUseCase _getAllPatientsUseCase;

        public PatientController(INotifier notifier,
                                IRegisterPatientUseCase registerPatientUseCase,
                                IGetPatientByIdUseCase getPatientByIdUseCase,
                                IGetAllPatientsUseCase getAllPatientsUseCase) : base(notifier)
        {
            _registerPatientUseCase = registerPatientUseCase;
            _getPatientByIdUseCase = getPatientByIdUseCase;
            _getAllPatientsUseCase = getAllPatientsUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPatient(RegisterPatientRequest request)
        {
            var opResult = await _registerPatientUseCase.Execute(request);

            return DefaultResponse(Created(opResult));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPatientById(Guid id)
        {
            var result = await _getPatientByIdUseCase.Execute(id);

            return result is null ? DefaultResponse(NoContent()) : DefaultResponse(Ok(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _getAllPatientsUseCase.Execute();

            return DefaultResponse(Ok(result));
        }
    }
}