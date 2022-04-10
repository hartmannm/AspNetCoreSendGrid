using ANCSG.API.Results;
using ANCSG.Application.Contexts.PatientContext.DTOs;
using ANCSG.Application.Contexts.PatientContext.UseCases;
using ANCSG.Application.Notification;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ANCSG.API.Controllers
{

    [Route("api/patient")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
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

        /// <summary>
        /// Register a Patient.
        /// </summary>
        /// <param name="request">Patient's data</param>
        /// <returns>Registered Patient's data</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /patient
        ///     {
        ///         "firstName": "John",
        ///         "lastName: "Doe",
        ///         "email": "johndoe@example.com",
        ///         "birthDate": "1993-01-13T23:00:32.012Z"
        ///     }
        ///     
        /// </remarks>
        /// <response code="201">Returns the newly created datient's data</response>
        /// <response code="400">Returns a list of erros</response>
        [HttpPost]
        [ProducesResponseType(typeof(PatientDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BadRequestDefaultResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterPatient(RegisterPatientRequest request)
        {
            var opResult = await _registerPatientUseCase.Execute(request);

            return DefaultResponse(Created(opResult));
        }

        /// <summary>
        /// Search by a Patient with the specified Id.
        /// </summary>
        /// <param name="id">Patient's Id</param>
        /// <returns>Patient's data</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /patient/6522d02c-c12e-413e-ae3f-30dd549aacdd
        ///     
        /// </remarks>
        /// <response code="200">Returns the patient's data</response>
        /// <response code="204">Data not found</response>
        /// <response code="400">Returns a list of erros</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(PatientDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BadRequestDefaultResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPatientById(Guid id)
        {
            var result = await _getPatientByIdUseCase.Execute(id);

            return result is null ? DefaultResponse(NoContent()) : DefaultResponse(Ok(result));
        }

        /// <summary>
        /// Search for all patients data.
        /// </summary>
        /// <returns>Patient's list</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /patient
        ///     
        /// </remarks>
        /// <response code="200">Returns a list with all patients data</response>
        /// <response code="400">Returns a list of erros</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PatientDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestDefaultResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _getAllPatientsUseCase.Execute();

            return DefaultResponse(Ok(result));
        }
    }
}