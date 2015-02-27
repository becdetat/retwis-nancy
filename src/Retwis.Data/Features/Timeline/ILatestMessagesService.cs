using System.Threading.Tasks;
using Retwis.Data.Domain.LatestMessageAggregate;

namespace Retwis.Data.Features.Timeline
{
    public interface ILatestMessagesService
    {
        Task<LatestMessage[]> GetLatestMessages();
    }
}