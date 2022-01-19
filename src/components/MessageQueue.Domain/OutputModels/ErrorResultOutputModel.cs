using MessageQueue.Domain.Interfaces.Validation;

namespace MessageQueue.Domain.OutputModels
{
    public record ErrorResultOutputModel
    {
        public OperationError? Error { get; init; }

        public IReadOnlyList<ValidationError>? ValidationErrors { get; init; }
    }
}
