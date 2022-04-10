using ANCSG.Application.Contexts.DoctorContext.UseCases;
using ANCSG.Application.Notification;
using Microsoft.AspNetCore.Mvc;

namespace ANCSG.API.Controllers
{

    [Route("api/doctor")]
    public class DoctorController : BaseController
    {
        private readonly IRegisterDoctorUseCase _registerDoctorUseCase;
        private readonly IGetDoctorByIdUseCase _getDoctorByIdUseCase;
        private readonly IGetAllDoctorsUseCase _getAllDoctorsUseCase;

        public DoctorController(INotifier notifier,
                                IRegisterDoctorUseCase registerDoctorUseCase,
                                IGetDoctorByIdUseCase getDoctorByIdUseCase,
                                IGetAllDoctorsUseCase getAllDoctorsUseCase) : base(notifier)
        {
            _registerDoctorUseCase = registerDoctorUseCase;
            _getDoctorByIdUseCase = getDoctorByIdUseCase;
            _getAllDoctorsUseCase = getAllDoctorsUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterDoctor(RegisterDoctorRequest request)
        {
            var opResult = await _registerDoctorUseCase.Execute(request);

            return DefaultResponse(Created(opResult));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            var result = await _getDoctorByIdUseCase.Execute(id);

            return result is null ? DefaultResponse(NoContent()) : DefaultResponse(Ok(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _getAllDoctorsUseCase.Execute();

            return DefaultResponse(Ok(result));
        }
    }
}