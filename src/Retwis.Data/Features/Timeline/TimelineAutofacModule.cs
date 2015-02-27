using Autofac;

namespace Retwis.Data.Features.Timeline
{
    public class TimelineAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LatestRegisteredUsersService>().As<ILatestRegisteredUsersService>();
            builder.RegisterType<LatestMessagesService>().As<ILatestMessagesService>();
        }
    }
}