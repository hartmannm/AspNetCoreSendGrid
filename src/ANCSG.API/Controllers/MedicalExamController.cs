using ANCSG.Application.Contexts.MedicalExamContext.UseCases;
using ANCSG.Application.Notification;
using Microsoft.AspNetCore.Mvc;

namespace ANCSG.API.Controllers
{

    [Route("api/medical-exam")]
    public class MedicalExamController : BaseController
    {
        private readonly IScheduleMedicalExamUseCase _scheduleMedicalExamUseCase;

        public MedicalExamController(INotifier notifier, IScheduleMedicalExamUseCase scheduleMedicalExamUseCase) : base(notifier)
        {
            _scheduleMedicalExamUseCase = scheduleMedicalExamUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> ScheduleMedicalExam(ScheduleMedicalExamRequest request)
        {
            var opResult = await _scheduleMedicalExamUseCase.Execute(request);

            return DefaultResponse(Created(opResult));
        }
    }
}