using System;
using StackExchange.Redis;

namespace Retwis.Data.Persistence
{
    class RedisContext : IRedisContext, IDisposable
    {
        private ConnectionMultiplexer _redis = ConnectionMultiplexer.Connect("localhost");

        public void HelloWorld()
        {
            var db = _redis.GetDatabase();

            Console.WriteLine("storing");
            db.StringSet("mykey", "abcdefg");

            Console.WriteLine("reading");
            var value = db.StringGet("mykey");

            Console.WriteLine("Value: {0}", value);
        }

        public IDatabase GetDatabase()
        {
            return _redis.GetDatabase();
        }

        public void Dispose()
        {
            if (_redis != null)
            {
                _redis.Dispose();
                _redis = null;
            }
        }
    }
}