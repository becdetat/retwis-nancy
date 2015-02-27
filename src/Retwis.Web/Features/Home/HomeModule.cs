using Nancy;
using Nancy.Security;
using Retwis.Data.Features.Home;
using Retwis.Web.Plumbing;

namespace Retwis.Web.Features.Home
{
    public class HomeModule : NancyModule
    {
        public HomeModule(IHomeMessagesService homeMessagesServices)
        {
            this.RequiresAuthentication();

            Get["/", true] = async (o, context) => View["index", new
            {
                LatestMessages = await homeMessagesServices.GetLatestMessagesAsync(this.GetCurrentUserIdentifier())
            }];
        }
    }
}