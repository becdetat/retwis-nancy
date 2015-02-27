using Autofac;

namespace Retwis.Data.Features.StatusUpdates
{
    public class StatusUpdatesAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StatusUpdater>().As<IStatusUpdater>();
        }
    }
}