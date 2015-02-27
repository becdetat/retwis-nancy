using Nancy;
using Retwis.Data.Features.Timeline;

namespace Retwis.Web.Features.Timeline
{
    public class TimelineModule : NancyModule
    {
        public TimelineModule(
            ILatestRegisteredUsersService latestRegisteredUsersService,
            ILatestMessagesService latestMessagesService)
        {
            Get["/timeline", true] = async (o, context) => View["timeline/timeline", new
            {
                LatestRegisteredUsers = await latestRegisteredUsersService.GetLatestUsers(),
                LatestMessages = await latestMessagesService.GetLatestMessages(),
            }];
        }
    }
}