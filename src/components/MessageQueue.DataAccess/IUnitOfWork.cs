using Microsoft.EntityFrameworkCore.Storage;

namespace MessageQueue.DataAccess
{
    public interface IUnitOfWork
    {
        Task SaveAsync(CancellationToken cancellationToken = default);

        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
