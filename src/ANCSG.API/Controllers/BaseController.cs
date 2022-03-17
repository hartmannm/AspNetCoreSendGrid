using ANCSG.Application.Notification;
using Microsoft.AspNetCore.Mvc;

namespace ANCSG.API.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly INotifier _notifier;

        public BaseController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected IActionResult DefaultResponse(IActionResult result)
        {
            if (_notifier.HasNotifications)
            {
                var notifications = _notifier.Notifications.Select(n => n.Message);

                return BadRequest(new { Notifications = notifications });
            }

            return result;
        }
    }
}
