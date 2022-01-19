using MessageQueue.Domain.Enums;
using MessageQueue.Domain.Interfaces.Validation;

namespace MessageQueue.Domain.Infrastructure
{
    public abstract record QueryResultBase
    {
        protected QueryResultBase(OperationResult result, OperationError? error, IEnumerable<ValidationError>? validationErrors)
        {
            Result = result;
            Error = error;
            ValidationErrors = validationErrors?.ToList() ?? new List<ValidationError>();
        }

        public bool IsSuccess => Result == OperationResult.Success;

        public OperationResult Result { get; }

        public OperationError? Error { get; }

        public IReadOnlyList<ValidationError> ValidationErrors { get; }
    }
}
