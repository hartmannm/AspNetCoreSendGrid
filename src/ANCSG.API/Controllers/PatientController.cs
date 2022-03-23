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

        public PatientController(INotifier notifier,
                                IRegisterPatientUseCase registerPatientUseCase, 
                                IGetPatientByIdUseCase getPatientByIdUseCase) : base(notifier)
        {
            _registerPatientUseCase = registerPatientUseCase;
            _getPatientByIdUseCase = getPatientByIdUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPatient(RegisterPatientRequest request)
        {
            var opResult = await _registerPatientUseCase.Execute(request);
            var result = new ObjectResult(opResult) { StatusCode = StatusCodes.Status201Created };

            return DefaultResponse(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPatientById(Guid id)
        {
            var result = await _getPatientByIdUseCase.Execute(id);

            return result is null ? NoContent() : Ok(result);
        }
    }
}