using System.Linq;
using System.Threading.Tasks;
using Retwis.Data.Domain.LatestMessageAggregate;
using Retwis.Data.Persistence;

namespace Retwis.Data.Features.Timeline
{
    public class LatestMessagesService : ILatestMessagesService
    {
        private readonly IRedisContext _context;
        private readonly ILatestMessageRepository _latestMessageRepository;

        public LatestMessagesService(IRedisContext context,
            ILatestMessageRepository latestMessageRepository)
        {
            _context = context;
            _latestMessageRepository = latestMessageRepository;
        }

        public async Task<LatestMessage[]> GetLatestMessages()
        {
            var db = _context.GetDatabase();
            var postIds = await db.ListRangeAsync("timeline", 0, -1);
            var posts =
                await _latestMessageRepository.GetMessagesFor(db, postIds.Select(x => long.Parse(x)).ToArray());

            return posts.ToArray();
        }
    }
}