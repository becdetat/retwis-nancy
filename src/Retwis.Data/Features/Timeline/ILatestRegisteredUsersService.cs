using System.Threading.Tasks;

namespace Retwis.Data.Features.Timeline
{
    public interface ILatestRegisteredUsersService
    {
        Task<LatestRegisteredUser[]> GetLatestUsers();
    }
}