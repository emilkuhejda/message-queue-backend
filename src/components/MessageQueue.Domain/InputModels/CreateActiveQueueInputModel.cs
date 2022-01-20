using MessageQueue.Domain.Interfaces.Validation;

namespace MessageQueue.Domain.InputModels
{
    public record CreateActiveQueueInputModel : IValidatable
    {
        public string Name { get; set; } = string.Empty;

        public ValidationResult Validate()
        {
            IList<ValidationError> errors = new List<ValidationError>();

            errors.ValidateRequired(Name, nameof(Name), nameof(CreateActiveQueueInputModel));

            return new ValidationResult(errors);
        }
    }
}
