using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Retwis.Data.Domain.LatestMessageAggregate
{
    public interface ILatestMessageRepository
    {
        Task<LatestMessage[]> GetMessagesFor(IDatabase database, long[] postIds);
    }

    public class LatestMessageRepository : ILatestMessageRepository
    {
        public async Task<LatestMessage[]> GetMessagesFor(IDatabase database, long[] postIds)
        {
            var messages = new List<LatestMessage>();
            foreach (var id in postIds)
            {
                var post = (await database.HashGetAllAsync("post:" + id)).ToDictionary();
                var userIdentifier = Guid.Parse(post["user_id"]);
                var username = await database.HashGetAsync("usernames", userIdentifier.ToString());
                messages.Add(new LatestMessage(
                    username,
                    new DateTime((long) post["time"]),
                    post["status"]));
            }
            return messages.ToArray();
        }
    }
}