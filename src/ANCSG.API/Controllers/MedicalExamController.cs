using ANCSG.API.Results;
using ANCSG.Application.Contexts.MedicalExamContext.DTOs;
using ANCSG.Application.Contexts.MedicalExamContext.UseCases;
using ANCSG.Application.Notification;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ANCSG.API.Controllers
{

    [Route("api/v{version:apiVersion}/medical-exam")]
    [ApiVersion("1.0")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class MedicalExamController : BaseController
    {
        private readonly IScheduleMedicalExamUseCase _scheduleMedicalExamUseCase;
        private readonly IGetExamByIdUseCase _getExamByIdUseCase;
        private readonly IGetAllExamsUseCase _getAllExamsUseCase;
        private readonly IAccomplishExamUseCase _accomplishExamUseCase;

        public MedicalExamController(INotifier notifier,
                                     IScheduleMedicalExamUseCase scheduleMedicalExamUseCase,
                                     IGetExamByIdUseCase getExamByIdUseCase,
                                     IGetAllExamsUseCase getAllExamsUseCase,
                                     IAccomplishExamUseCase accomplishExamUseCase) : base(notifier)
        {
            _scheduleMedicalExamUseCase = scheduleMedicalExamUseCase;
            _getExamByIdUseCase = getExamByIdUseCase;
            _getAllExamsUseCase = getAllExamsUseCase;
            _accomplishExamUseCase = accomplishExamUseCase;
        }

        /// <summary>
        /// Schedule a medical exam.
        /// </summary>
        /// <param name="request">Medical exam data</param>
        /// <returns>Scheduled medical exam data</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /medical-exam
        ///     {
        ///         "doctorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "patientId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "dateScheduled": "2022-04-10T09:00:00.000Z"
        ///     }
        ///     
        /// </remarks>
        /// <response code="201">Returns the newly scheduled medical exam data</response>
        /// <response code="400">Returns a list of erros</response>
        [HttpPost]
        [ProducesResponseType(typeof(MedicalExamDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BadRequestDefaultResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ScheduleMedicalExam([FromBody] ScheduleMedicalExamRequest request)
        {
            var opResult = await _scheduleMedicalExamUseCase.Execute(request);

            return DefaultResponse(Created(opResult));
        }

        /// <summary>
        /// Search for all medical exams data.
        /// </summary>
        /// <returns>Medical exam list</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /medical-exam
        ///     
        /// </remarks>
        /// <response code="200">Returns a list with all medical exams data</response>
        /// <response code="400">Returns a list of erros</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MedicalExamDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestDefaultResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getAllExamsUseCase.Execute();

            return DefaultResponse(Ok(result));
        }

        /// <summary>
        /// Search by a medical exam with the specified Id.
        /// </summary>
        /// <param name="id">Medical exam Id</param>
        /// <returns>Doctor's data</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /medical-exam/6522d02c-c12e-413e-ae3f-30dd549aacdd
        ///     
        /// </remarks>
        /// <response code="200">Returns the medical exam data</response>
        /// <response code="204">Data not found</response>
        /// <response code="400">Returns a list of erros</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(MedicalExamDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BadRequestDefaultResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _getExamByIdUseCase.Execute(id);

            return result is null ? DefaultResponse(NoContent()) : DefaultResponse(Ok(result));
        }

        /// <summary>
        /// Set a medical exam as accomplished.
        /// </summary>
        /// <param name="id">Medical exam Id</param>
        /// <returns>Sucess if operation goes right</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /medical-exam/6522d02c-c12e-413e-ae3f-30dd549aacdd/accomplish
        ///     
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Returns a list of erros</response>
        [HttpPost("{id:guid}/accomplish")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestDefaultResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Accomplish([FromRoute] Guid id)
        {
            await _accomplishExamUseCase.Execute(id);

            return DefaultResponse(Ok());
        }
    }
}