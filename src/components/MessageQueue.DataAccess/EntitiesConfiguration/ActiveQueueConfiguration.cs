using MessageQueue.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageQueue.DataAccess.EntitiesConfiguration
{
    internal class ActiveQueueConfiguration : IEntityTypeConfiguration<ActiveQueue>
    {
        public void Configure(EntityTypeBuilder<ActiveQueue> builder)
        {
            builder.ToTable("ActiveQueue");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.DateCreatedUtc).IsRequired();
        }
    }
}
