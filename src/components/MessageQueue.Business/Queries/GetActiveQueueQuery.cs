using System.Security.Claims;
using MessageQueue.Domain.Infrastructure;
using MessageQueue.Domain.Interfaces.Queries;
using MessageQueue.Domain.Interfaces.Repositories;
using MessageQueue.Domain.Interfaces.Validation;
using MessageQueue.Domain.Models;

namespace MessageQueue.Business.Queries
{
    public class GetActiveQueueQuery : IGetActiveQueueQuery
    {
        private readonly IActiveQueueRepository _activeQueueRepository;

        public GetActiveQueueQuery(IActiveQueueRepository activeQueueRepository)
        {
            _activeQueueRepository = activeQueueRepository;
        }

        public async Task<QueryResult<ActiveQueue>> ExecuteAsync(Guid parameter, ClaimsPrincipal principal, CancellationToken cancellationToken)
        {
            var activeQueue = await _activeQueueRepository.GetAsync(parameter, cancellationToken);
            if (activeQueue == null)
            {
                return new QueryResult<ActiveQueue>(new OperationError(ValidationErrorCodes.NotFound));
            }

            return new QueryResult<ActiveQueue>(activeQueue);
        }
    }
}
