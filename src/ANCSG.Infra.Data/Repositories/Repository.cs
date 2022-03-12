using ANCSG.Application.Data;
using ANCSG.Domain.DomainEntities;
using ANCSG.Infra.Data.DataContext;
using System.Threading.Tasks;

namespace ANCSG.Infra.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : IAggregateRoot, new()
    {
        protected readonly SendGridContext context;

        public Repository(SendGridContext context)
        {
            this.context = context;
        }

        public async Task<bool> SaveChangesAsync() => await context.SaveChangesAsync() > 0;

        public void Dispose() => context?.Dispose();
    }
}
