using MessageQueue.Domain.Interfaces.Repositories;
using MessageQueue.Domain.Models;

namespace MessageQueue.DataAccess.Repositories
{
    public class ActiveQueueRepository : Repository<ActiveQueue>, IActiveQueueRepository
    {
        public ActiveQueueRepository(DatabaseContext context)
            : base(context)
        {
        }
    }
}
