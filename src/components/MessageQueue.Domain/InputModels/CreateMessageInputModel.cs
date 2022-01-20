using MessageQueue.Domain.Interfaces.Validation;

namespace MessageQueue.Domain.InputModels
{
    public class CreateMessageInputModel : IValidatable
    {
        public string Body { get; set; } = string.Empty;

        public DateTime DateCreatedUtc { get; set; }

        public DateTime DateExpiredInUtc { get; set; }

        public ValidationResult Validate()
        {
            IList<ValidationError> errors = new List<ValidationError>();

            errors.ValidateRequired(Body, nameof(Body), nameof(CreateMessageInputModel));
            errors.ValidateDateTime(DateCreatedUtc, nameof(DateCreatedUtc), nameof(CreateMessageInputModel));
            errors.ValidateDateTime(DateExpiredInUtc, nameof(DateExpiredInUtc), nameof(CreateMessageInputModel));

            return new ValidationResult(errors);
        }
    }
}
