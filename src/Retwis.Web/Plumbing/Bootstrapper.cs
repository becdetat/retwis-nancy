using Autofac;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Bootstrapper;

namespace Retwis.Web.Plumbing
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        public Bootstrapper(ILifetimeScope scope)
            : base(scope)
        {
        }

        protected override void RequestStartup(ILifetimeScope container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);

            var config = new FormsAuthenticationConfiguration
            {
                RedirectUrl = "~/login",
                UserMapper = container.Resolve<IUserMapper>()
            };

            FormsAuthentication.Enable(pipelines, config);
        }

        protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
        {
        }
    }
}