using MessageQueue.Domain.Infrastructure;
using MessageQueue.Domain.InputModels;
using MessageQueue.Domain.Interfaces.Infrastructure;

namespace MessageQueue.Domain.Interfaces.Commands
{
    public interface ICreateActiveQueueCommand : ICommand<CreateActiveQueueInputModel, CommandResult>
    {
    }
}
