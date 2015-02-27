using System.Linq;
using System.Threading.Tasks;
using Retwis.Data.Persistence;
using StackExchange.Redis;

namespace Retwis.Data.Features.Timeline
{
    class LatestRegisteredUsersService : ILatestRegisteredUsersService
    {
        private readonly IRedisContext _context;

        public LatestRegisteredUsersService(IRedisContext context)
        {
            _context = context;
        }

        public async Task<LatestRegisteredUser[]> GetLatestUsers()
        {
            var db = _context.GetDatabase();
            var users = await db.SortedSetRangeByRankAsync("users_by_time", stop: 9, order: Order.Descending);

            return users.Select(x => new LatestRegisteredUser(x)).ToArray();
        }
    }
}