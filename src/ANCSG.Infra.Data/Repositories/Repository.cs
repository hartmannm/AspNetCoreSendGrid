using ANCSG.Domain.Data;
using ANCSG.Domain.DomainEntities;
using ANCSG.Infra.Data.DataContext;
using System.Threading.Tasks;

namespace ANCSG.Infra.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : IAggregateRoot, new()
    {
        private readonly SendGridContext _context;

        protected SendGridContext context => _context;

        public Repository(SendGridContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;

        public void Dispose() => _context?.Dispose();
    }
}
