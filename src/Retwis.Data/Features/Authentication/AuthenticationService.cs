using System;
using System.Linq;
using System.Threading.Tasks;
using Retwis.Data.Persistence;
using StackExchange.Redis;

namespace Retwis.Data.Features.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRedisContext _context;
        private readonly Random _random = new Random();

        public AuthenticationService(IRedisContext context)
        {
            _context = context;
        }

        public async Task<RetwisUser> GetUserAsync(string username, string password)
        {
            var db = _context.GetDatabase();

            var details = (await db.HashGetAllAsync(GetUserKey(username))).ToDictionary();

            if (!details.Any() || details["password"] != password)
            {
                return null;
            }
            return new RetwisUser(username, Guid.Parse(details["user_identifier"]));
        }

        public async Task<RetwisUser> RegisterAsync(string username, string password)
        {
            var db = _context.GetDatabase();

            if (db.HashGet("users_identifiers", username).HasValue)
            {
                throw new UsernameAlreadyInUseException();
            }

            var authSecret = GetNewAuthSecret();
            var userIdentifier = Guid.NewGuid();

            await db.HashSetAsync("usernames", userIdentifier.ToString(), username);
            await db.HashSetAsync("user_identifiers", username, userIdentifier.ToString());
            await db.HashSetAsync(GetUserKey(username), new[]
            {
                new HashEntry("username", username),
                new HashEntry("password", password),
                new HashEntry("user_identifier", userIdentifier.ToString()), 
                new HashEntry("auth", authSecret), 
            });
            await db.HashSetAsync("auths", authSecret, userIdentifier.ToString());
            
            await db.SortedSetAddAsync("users_by_time", username, DateTime.Now.Ticks);

            return new RetwisUser(username, userIdentifier);
        }

        public async Task<RetwisUser> GetUserFromIdentifierAsync(Guid identifier)
        {
            var db = _context.GetDatabase();

            var username = await db.HashGetAsync("usernames", identifier.ToString());

            if (username.IsNullOrEmpty)
            {
                return null;
            }

            return new RetwisUser(username, identifier);
        }

        static string GetUserKey(string username)
        {
            return string.Format("user:{0}", username);
        }

        byte[] GetNewAuthSecret()
        {
            var buffer = new byte[16];
            _random.NextBytes(buffer);
            return buffer;
        }
    }
}