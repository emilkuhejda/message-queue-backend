using System.Security.Claims;

namespace MessageQueue.Domain.Interfaces.Infrastructure
{
    public interface ICommand<in T, TResult>
    {
        Task<TResult> ExecuteAsync(T parameter, ClaimsPrincipal principal, CancellationToken cancellationToken);
    }

    public interface ICommand<in T>
    {
        Task ExecuteAsync(T parameter, ClaimsPrincipal principal, CancellationToken cancellationToken);
    }
}
