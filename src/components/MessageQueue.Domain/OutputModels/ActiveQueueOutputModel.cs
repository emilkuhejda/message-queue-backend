namespace MessageQueue.Domain.OutputModels
{
    public record ActiveQueueOutputModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime DateCreatedUtc { get; set; }
    }
}
