using MessageQueue.Domain.Interfaces.Validation;

namespace MessageQueue.Domain.Models
{
    public class ActiveQueue : EntityBase, IValidatable
    {
        public string Name { get; set; } = string.Empty;

        public DateTime DateCreatedUtc { get; set; }

        public ICollection<Message>? Messages { get; set; }

        public ValidationResult Validate()
        {
            IList<ValidationError> errors = new List<ValidationError>();

            errors.ValidateGuid(Id, nameof(Id), nameof(ActiveQueue));
            errors.ValidateRequired(Name, nameof(Name), nameof(ActiveQueue));
            errors.ValidateDateTime(DateCreatedUtc, nameof(DateCreatedUtc), nameof(ActiveQueue));

            return new ValidationResult(errors);
        }
    }
}
