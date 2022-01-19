using MessageQueue.DataAccess.EntitiesConfiguration;
using MessageQueue.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MessageQueue.DataAccess
{
    public class DatabaseContext : DbContext
    {
        private readonly string _connectionString;

        public DatabaseContext(DbContextOptions options)
            : this(string.Empty, options)
        {
        }

        public DatabaseContext(string connectionString, DbContextOptions options)
            : base(options)
        {
            _connectionString = connectionString;
        }

        public DbSet<ActiveQueue>? ActiveQueues { get; set; }

        public DbSet<Message>? Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, providerOptions => providerOptions.CommandTimeout(300));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActiveQueueConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
        }
    }
}
