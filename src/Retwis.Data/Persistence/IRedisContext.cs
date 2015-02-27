using StackExchange.Redis;

namespace Retwis.Data.Persistence
{
    public interface IRedisContext
    {
        void HelloWorld();
        IDatabase GetDatabase();
    }
}