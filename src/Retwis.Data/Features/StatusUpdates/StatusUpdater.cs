using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retwis.Data.Persistence;
using StackExchange.Redis;

namespace Retwis.Data.Features.StatusUpdates
{
    public interface IStatusUpdater
    {
        Task UpdateStatusAsync(Guid userIdentifier, string status);
    }

    public class StatusUpdater : IStatusUpdater
    {
        private readonly IRedisContext _context;

        public StatusUpdater(IRedisContext context)
        {
            _context = context;
        }

        public async Task UpdateStatusAsync(Guid userIdentifier, string status)
        {
            var db = _context.GetDatabase();

            // persist the post
            var postId = db.StringIncrement("next_post_id");
            db.HashSet("post:" + postId, new[]
            {
                new HashEntry("user_id", userIdentifier.ToString()),
                new HashEntry("time", DateTime.Now.Ticks),
                new HashEntry("status", status), 
            });

            // push to follower's timelines
            var followers = await db.SortedSetRangeByScoreAsync("followers:" + userIdentifier);
            foreach (var follower in followers)
            {
                await db.ListLeftPushAsync("posts:" + follower, postId);
            }

            // push to my timeline
            await db.ListLeftPushAsync("posts:" + userIdentifier, postId);

            // push to the timeline and trim to last 1000
            await db.ListLeftPushAsync("timeline", postId);
            await db.ListTrimAsync("timeline", 0, 1000);
        }
    }
}
