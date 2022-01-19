using MessageQueue.Domain.Interfaces.Validation;

namespace MessageQueue.Domain.Models
{
    public class Message : EntityBase, IValidatable
    {
        public Guid ActiveQueueId { get; set; } = Guid.Empty;

        public string Body { get; set; } = string.Empty;

        public DateTime DateCreatedUtc { get; set; }

        public DateTime DateExpiredInUtc { get; set; }

        public DateTime? DateProcessedUtc { get; set; }

        public ValidationResult Validate()
        {
            IList<ValidationError> errors = new List<ValidationError>();

            errors.ValidateGuid(Id, nameof(Id), nameof(Message));
            errors.ValidateDateTime(DateCreatedUtc, nameof(DateCreatedUtc), nameof(Message));

            return new ValidationResult(errors);
        }
    }
}
