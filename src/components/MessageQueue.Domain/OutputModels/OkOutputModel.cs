using System.ComponentModel.DataAnnotations;

namespace MessageQueue.Domain.OutputModels
{
    public record OkOutputModel
    {
        public OkOutputModel()
            : this(DateTime.UtcNow)
        {
        }

        public OkOutputModel(DateTime dateTimeUtc)
        {
            DateTimeUtc = dateTimeUtc;
        }

        [Required]
        public DateTime DateTimeUtc { get; }
    }
}
