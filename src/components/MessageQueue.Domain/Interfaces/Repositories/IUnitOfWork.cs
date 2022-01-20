namespace MessageQueue.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}
