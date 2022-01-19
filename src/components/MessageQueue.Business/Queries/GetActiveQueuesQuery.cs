using System.Security.Claims;
using AutoMapper;
using MessageQueue.Domain.Infrastructure;
using MessageQueue.Domain.Interfaces.Queries;
using MessageQueue.Domain.Interfaces.Repositories;
using MessageQueue.Domain.OutputModels;

namespace MessageQueue.Business.Queries
{
    public class GetActiveQueuesQuery : IGetActiveQueuesQuery
    {
        private readonly IActiveQueueRepository _activeQueueRepository;
        private readonly IMapper _mapper;

        public GetActiveQueuesQuery(
            IActiveQueueRepository activeQueueRepository,
            IMapper mapper)
        {
            _activeQueueRepository = activeQueueRepository;
            _mapper = mapper;
        }

        public async Task<QueryResult<ActiveQueueOutputModel[]>> ExecuteAsync(ClaimsPrincipal principal, CancellationToken cancellationToken)
        {
            var activeQueues = await _activeQueueRepository.GetAllAsync(cancellationToken);
            var outputModel = _mapper.Map<ActiveQueueOutputModel[]>(activeQueues);
            return new QueryResult<ActiveQueueOutputModel[]>(outputModel);
        }
    }
}
