using ANCSG.Application.Data;
using ANCSG.Application.Map;
using ANCSG.Application.Notification;

namespace ANCSG.Application.UseCase
{
    public abstract class UseCaseBase
    {
        protected readonly INotifier notifier;
        protected readonly IDataManager dataManager;
        protected readonly IMap map;

        public UseCaseBase(INotifier notifier, IDataManager dataManager, IMap map)
        {
            this.notifier = notifier;
            this.dataManager = dataManager;
            this.map = map;
        }
    }
}
