using MessageQueue.Domain.Enums;
using MessageQueue.Domain.Interfaces.Validation;

namespace MessageQueue.Domain.Infrastructure
{
    public abstract record CommandResultBase
    {
        public bool IsSuccess => Result == OperationResult.Success;

        public OperationResult Result { get; protected init; }

        public OperationError? Error { get; protected init; }

        public IReadOnlyList<ValidationError> ValidationErrors { get; protected init; } = new List<ValidationError>();
    }
}
