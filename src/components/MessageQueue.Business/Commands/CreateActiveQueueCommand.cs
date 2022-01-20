using System.Security.Claims;
using AutoMapper;
using MessageQueue.Domain.Infrastructure;
using MessageQueue.Domain.InputModels;
using MessageQueue.Domain.Interfaces.Commands;
using MessageQueue.Domain.Interfaces.Repositories;
using MessageQueue.Domain.Models;
using MessageQueue.Domain.OutputModels;
using Serilog;

namespace MessageQueue.Business.Commands
{
    public class CreateActiveQueueCommand : ICreateActiveQueueCommand
    {
        private readonly IActiveQueueRepository _activeQueueRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CreateActiveQueueCommand(
            IActiveQueueRepository activeQueueRepository,
            IMapper mapper,
            ILogger logger)
        {
            _activeQueueRepository = activeQueueRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CommandResult<OkOutputModel>> ExecuteAsync(CreateActiveQueueInputModel parameter, ClaimsPrincipal principal, CancellationToken cancellationToken)
        {
            var inputValidationResult = parameter.Validate();
            if (!inputValidationResult.IsValid)
            {
                return new CommandResult<OkOutputModel>(inputValidationResult.Errors);
            }

            var activeQueue = _mapper.Map<ActiveQueue>(parameter);
            await _activeQueueRepository.AddAsync(activeQueue);
            await _activeQueueRepository.SaveAsync(cancellationToken);

            _logger.Information($"New queue {activeQueue.Name} was created");

            return new CommandResult<OkOutputModel>(new OkOutputModel());
        }
    }
}
