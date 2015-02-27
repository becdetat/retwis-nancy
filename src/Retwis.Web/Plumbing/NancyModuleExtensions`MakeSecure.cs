using Nancy;
using Nancy.Responses;

namespace Retwis.Web.Plumbing
{
    public static partial class NancyModuleExtensions
    {
        public static void MakeSecure(this NancyModule module)
        {
            module.Before.AddItemToEndOfPipeline(MakeSecure);
        }

        private static Response MakeSecure(NancyContext context)
        {
            if ((context.CurrentUser == null) || string.IsNullOrEmpty(context.CurrentUser.UserName))
            {
                return new RedirectResponse("/login")
                {
                    //StatusCode = HttpStatusCode.Unauthorized
                };
            }

            return null;
        }
    }
}