using System;
using System.Threading.Tasks;

namespace Retwis.Data.Features.Authentication
{
    public interface IAuthenticationService
    {
        Task<RetwisUser> GetUserAsync(string username, string password);
        Task<RetwisUser> RegisterAsync(string username, string password);
        Task<RetwisUser> GetUserFromIdentifierAsync(Guid identifier);
    }
}