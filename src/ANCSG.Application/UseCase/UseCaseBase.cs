using ANCSG.Domain.Notification;

namespace ANCSG.Application.UseCase
{
    public abstract class UseCaseBase
    {
        private readonly INotifier _notifier;

        protected INotifier notifier => _notifier;

        public UseCaseBase(INotifier notifier)
        {
            _notifier = notifier;
        }
    }
}
