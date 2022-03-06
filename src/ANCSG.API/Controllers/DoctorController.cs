using ANCSG.Application.Contexts.DoctorContext.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ANCSG.API.Controllers
{
    [ApiController]
    [Route("api/doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly IRegisterDoctorUseCase _registerDoctorUseCase;
        private readonly IGetDoctorByIdUseCase _getDoctorByIdUseCase;
        private readonly IGetAllDoctorsUseCase _getAllDoctorsUseCase;

        public DoctorController(IRegisterDoctorUseCase registerDoctorUseCase, IGetDoctorByIdUseCase getDoctorByIdUseCase, IGetAllDoctorsUseCase getAllDoctorsUseCase)
        {
            _registerDoctorUseCase = registerDoctorUseCase;
            _getDoctorByIdUseCase = getDoctorByIdUseCase;
            _getAllDoctorsUseCase = getAllDoctorsUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterDoctor(RegisterDoctorRequest request)
        {
            var result = await _registerDoctorUseCase.Execute(request);

            return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            var result = await _getDoctorByIdUseCase.Execute(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _getAllDoctorsUseCase.Execute();

            return Ok(result);
        }
    }
}
