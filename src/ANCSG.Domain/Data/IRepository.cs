using ANCSG.Domain.DomainEntities;
using System;
using System.Threading.Tasks;

namespace ANCSG.Domain.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        Task<bool> SaveChangesAsync();
    }
}
