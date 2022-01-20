using MessageQueue.Domain.Interfaces.Repositories;
using MessageQueue.Domain.Models;

namespace MessageQueue.DataAccess.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(DatabaseContext context)
            : base(context)
        {
        }
    }
}
