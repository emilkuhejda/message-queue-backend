using MessageQueue.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageQueue.DataAccess.EntitiesConfiguration
{
    internal class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Message");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.ActiveQueueId).IsRequired();
            builder.Property(x => x.Body).IsRequired();
            builder.Property(x => x.DateCreatedUtc).IsRequired();
            builder.Property(x => x.DateExpiredInUtc).IsRequired();
            builder.Property(x => x.DateProcessedUtc);
        }
    }
}
