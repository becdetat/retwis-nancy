using Autofac;

namespace Retwis.Data.Persistence
{
    public class PersistenceAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RedisContext>().As<IRedisContext>();
        }
    }
}