using ANCSG.Domain.DomainEntities;
using System;
using System.Threading.Tasks;

namespace ANCSG.Application.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        Task<bool> SaveChangesAsync();
    }
}
