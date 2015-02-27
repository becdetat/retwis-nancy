using Autofac;

namespace Retwis.Data.Features.Home
{
    public class HomeAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HomeMessagesService>().As<IHomeMessagesService>();
        }
    }
}