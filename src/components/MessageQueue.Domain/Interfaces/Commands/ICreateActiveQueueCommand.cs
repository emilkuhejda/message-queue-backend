using MessageQueue.Domain.Infrastructure;
using MessageQueue.Domain.InputModels;
using MessageQueue.Domain.Interfaces.Infrastructure;
using MessageQueue.Domain.OutputModels;

namespace MessageQueue.Domain.Interfaces.Commands
{
    public interface ICreateActiveQueueCommand : ICommand<CreateActiveQueueInputModel, CommandResult<OkOutputModel>>
    {
    }
}
