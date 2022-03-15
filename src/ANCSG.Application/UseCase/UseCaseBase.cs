using ANCSG.Application.Data;
using ANCSG.Application.Map;
using ANCSG.Application.Notification;

namespace ANCSG.Application.UseCase
{
    public abstract class UseCaseBase
    {
        private readonly INotifier _notifier;
        private readonly IDataManager _dataManager;
        private readonly IMap _map;

        protected INotifier notifier => _notifier;

        protected IDataManager dataManager => _dataManager;

        public UseCaseBase(INotifier notifier, IDataManager dataManager, IMap map)
        {
            _notifier = notifier;
            _dataManager = dataManager;
            _map = map;
        }
    }
}
