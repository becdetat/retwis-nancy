using Nancy;
using Retwis.Data.Persistence;

namespace Retwis.Web.Features
{
    public class IndexModule : NancyModule
    {
        public IndexModule(IRedisContext context)
        {
            Get["/"] = parameters =>
            {
                return View["index"];
            };

            Get["/helloworld"] = o =>
            {
                context.HelloWorld();
                return HttpStatusCode.OK;
            };
        }
    }
}