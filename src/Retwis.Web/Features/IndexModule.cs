using Nancy;
using Nancy.Security;
using Retwis.Data.Persistence;
using Retwis.Web.Plumbing;

namespace Retwis.Web.Features
{
    public class IndexModule : NancyModule
    {
        public IndexModule(IRedisContext context)
        {
            this.RequiresAuthentication();


            Get["/helloworld"] = o =>
            {
                context.HelloWorld();
                return HttpStatusCode.OK;
            };
        }
    }
}