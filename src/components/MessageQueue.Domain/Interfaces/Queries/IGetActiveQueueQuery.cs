using MessageQueue.Domain.Infrastructure;
using MessageQueue.Domain.Interfaces.Infrastructure;
using MessageQueue.Domain.Models;

namespace MessageQueue.Domain.Interfaces.Queries
{
    public interface IGetActiveQueueQuery : IQuery<Guid, QueryResult<ActiveQueue>>
    {
    }
}
