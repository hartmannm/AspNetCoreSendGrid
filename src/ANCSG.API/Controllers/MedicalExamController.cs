using ANCSG.Application.Contexts.MedicalExamContext.UseCases;
using ANCSG.Application.Notification;
using Microsoft.AspNetCore.Mvc;

namespace ANCSG.API.Controllers
{

    [Route("api/medical-exam")]
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

        [HttpPost]
        public async Task<IActionResult> ScheduleMedicalExam(ScheduleMedicalExamRequest request)
        {
            var opResult = await _scheduleMedicalExamUseCase.Execute(request);

            return DefaultResponse(Created(opResult));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getAllExamsUseCase.Execute();

            return DefaultResponse(Ok(result));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _getExamByIdUseCase.Execute(id);

            return result is null ? DefaultResponse(NoContent()) : DefaultResponse(Ok(result));
        }

        [HttpPost("{id:guid}/accomplish")]
        public async Task<IActionResult> Accomplish(Guid id)
        {
            await _accomplishExamUseCase.Execute(id);

            return DefaultResponse(Ok());
        }
    }
}