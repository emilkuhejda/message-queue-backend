namespace MessageQueue.Domain.Interfaces.Validation
{
    public static class ValidationErrorCodes
    {
        public static string NotFound => nameof(NotFound);

        public static string EmptyField => nameof(EmptyField);

        public static string InvalidId => nameof(InvalidId);

        public static string InvalidEmail => nameof(InvalidEmail);

        public static string InvalidDateTime => nameof(InvalidDateTime);

        public static string TextTooLong => nameof(TextTooLong);

        public static string ParameterIsNull => nameof(ParameterIsNull);

        public static string StartTimeGreaterOrEqualThanEndTime => nameof(StartTimeGreaterOrEqualThanEndTime);
    }
}
