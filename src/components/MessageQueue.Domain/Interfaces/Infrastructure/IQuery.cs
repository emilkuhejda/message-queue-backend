using System.Security.Claims;

namespace MessageQueue.Domain.Interfaces.Infrastructure
{
    public interface IQuery<in TInput, TOutput>
    {
        Task<TOutput> ExecuteAsync(TInput parameter, ClaimsPrincipal principal, CancellationToken cancellationToken);
    }

    public interface IQuery<TOutput>
    {
        Task<TOutput> ExecuteAsync(ClaimsPrincipal principal, CancellationToken cancellationToken);
    }
}
