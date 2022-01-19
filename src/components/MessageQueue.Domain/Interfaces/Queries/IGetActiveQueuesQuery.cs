using MessageQueue.Domain.Infrastructure;
using MessageQueue.Domain.Interfaces.Infrastructure;
using MessageQueue.Domain.OutputModels;

namespace MessageQueue.Domain.Interfaces.Queries
{
    public interface IGetActiveQueuesQuery : IQuery<QueryResult<ActiveQueueOutputModel[]>>
    {
    }
}
