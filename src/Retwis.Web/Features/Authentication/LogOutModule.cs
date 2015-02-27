using Nancy;
using Nancy.Authentication.Forms;

namespace Retwis.Web.Features.Authentication
{
    public class LogOutModule : NancyModule
    {
        public LogOutModule()
        {
            Get["/logout"] = _ => this.Logout("/");
        }
    }
}