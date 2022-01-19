namespace MessageQueue.Domain.Interfaces.Validation
{
    public record OperationError
    {
        public OperationError(string errorCode)
        {
            ErrorCode = errorCode;
        }

        public string ErrorCode { get; }
    }
}
