using Autofac;

namespace Retwis.Web.Plumbing
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        public Bootstrapper(ILifetimeScope scope)
            : base(scope)
        {
        }
    }
}