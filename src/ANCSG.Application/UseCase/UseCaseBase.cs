using ANCSG.Domain.Data;
using ANCSG.Domain.Notification;

namespace ANCSG.Application.UseCase
{
    public abstract class UseCaseBase
    {
        private readonly INotifier _notifier;

        private readonly IDataManager _dataManager;

        protected INotifier notifier => _notifier;

        protected IDataManager dataManager => _dataManager;

        public UseCaseBase(INotifier notifier, IDataManager dataManager)
        {
            _notifier = notifier;
            _dataManager = dataManager;
        }
    }
}
