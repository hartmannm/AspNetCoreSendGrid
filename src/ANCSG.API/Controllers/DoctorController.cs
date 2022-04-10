using ANCSG.API.Results;
using ANCSG.Application.Contexts.DoctorContext.DTOs;
using ANCSG.Application.Contexts.DoctorContext.UseCases;
using ANCSG.Application.Notification;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ANCSG.API.Controllers
{

    [Route("api/doctor")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
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

        /// <summary>
        /// Register a Doctor.
        /// </summary>
        /// <param name="request">Doctor's data</param>
        /// <returns>Registered Doctor's data</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /doctor
        ///     {
        ///         "firstName": "John",
        ///         "lastName: "Doe",
        ///         "email": "johndoe@example.com",
        ///         "crmUf": "rs"
        ///         "crmNumber": 123456
        ///     }
        ///     
        /// </remarks>
        /// <response code="201">Returns the newly created doctor's data</response>
        /// <response code="400">Returns a list of erros</response>
        [HttpPost]
        [ProducesResponseType(typeof(DoctorDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BadRequestDefaultResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterDoctor(RegisterDoctorRequest request)
        {
            var result = await _registerDoctorUseCase.Execute(request);

            return DefaultResponse(Created(result));
        }

        /// <summary>
        /// Search by a Doctor with the specified Id.
        /// </summary>
        /// <param name="id">Doctor's Id</param>
        /// <returns>Doctor's data</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /doctor/6522d02c-c12e-413e-ae3f-30dd549aacdd
        ///     
        /// </remarks>
        /// <response code="200">Returns the doctor's data</response>
        /// <response code="204">Data not found</response>
        /// <response code="400">Returns a list of erros</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(DoctorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BadRequestDefaultResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            var result = await _getDoctorByIdUseCase.Execute(id);

            return result is null ? DefaultResponse(NoContent()) : DefaultResponse(Ok(result));
        }

        /// <summary>
        /// Search for all doctor's data.
        /// </summary>
        /// <returns>Doctor's list</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /doctor
        ///     
        /// </remarks>
        /// <response code="200">Returns a list with all doctors data</response>
        /// <response code="400">Returns a list of erros</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DoctorDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestDefaultResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _getAllDoctorsUseCase.Execute();

            return DefaultResponse(Ok(result));
        }
    }
}