using System;
using System.Linq;
using System.Threading.Tasks;
using Retwis.Data.Domain.LatestMessageAggregate;
using Retwis.Data.Persistence;

namespace Retwis.Data.Features.Home
{
    public interface IHomeMessagesService
    {
        Task<LatestMessage[]> GetLatestMessagesAsync(Guid userIdentifier);
    }

    public class HomeMessagesService : IHomeMessagesService
    {
        private readonly IRedisContext _context;
        private readonly ILatestMessageRepository _latestMessageRepository;

        public HomeMessagesService(IRedisContext context,
            ILatestMessageRepository latestMessageRepository)
        {
            _context = context;
            _latestMessageRepository = latestMessageRepository;
        }

        public async Task<LatestMessage[]> GetLatestMessagesAsync(Guid userIdentifier)
        {
            var db = _context.GetDatabase();
            var postIds = await db.ListRangeAsync("posts:" + userIdentifier, 0, -1);
            var posts =
                await _latestMessageRepository.GetMessagesFor(db, postIds.Select(x => long.Parse(x)).ToArray());

            return posts.ToArray();
        }
    }
}