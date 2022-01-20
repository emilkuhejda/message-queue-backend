using System.Security.Claims;
using MessageQueue.Domain.Infrastructure;
using MessageQueue.Domain.Interfaces.Commands;
using MessageQueue.Domain.Interfaces.Repositories;
using MessageQueue.Domain.Models;
using MessageQueue.Domain.OutputModels;

namespace MessageQueue.Business.Commands
{
    public class CreateMessageCommand : ICreateMessageCommand
    {
        private readonly IMessageRepository _messageRepository;

        public CreateMessageCommand(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<CommandResult<OkOutputModel>> ExecuteAsync(Message parameter, ClaimsPrincipal principal, CancellationToken cancellationToken)
        {
            var inputValidationResult = parameter.Validate();
            if (!inputValidationResult.IsValid)
            {
                return new CommandResult<OkOutputModel>(inputValidationResult.Errors);
            }

            await _messageRepository.AddAsync(parameter);
            await _messageRepository.SaveAsync(cancellationToken);

            return new CommandResult<OkOutputModel>(new OkOutputModel());
        }
    }
}
