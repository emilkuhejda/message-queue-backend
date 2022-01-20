using MessageQueue.Domain.Infrastructure;
using MessageQueue.Domain.Interfaces.Infrastructure;
using MessageQueue.Domain.Models;
using MessageQueue.Domain.OutputModels;

namespace MessageQueue.Domain.Interfaces.Commands
{
    public interface ICreateMessageCommand : ICommand<Message, CommandResult<OkOutputModel>>
    {
    }
}
