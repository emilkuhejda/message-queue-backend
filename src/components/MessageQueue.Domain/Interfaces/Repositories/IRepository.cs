using MessageQueue.Domain.Models;

namespace MessageQueue.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        Task AddAsync(T entity);

        T Update(T entity);

        void Remove(T entity);

        Task<T?> GetAsync(Guid entityId, CancellationToken cancellationToken);

        Task<T[]> GetAllAsync(CancellationToken cancellationToken);

        Task SaveAsync(CancellationToken cancellationToken);
    }
}
