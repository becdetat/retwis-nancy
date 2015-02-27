using Autofac;
using Retwis.Data;

namespace Retwis.Web.Plumbing
{
    public static class IoC
    {
        public static IContainer LetThereBeIoC()
        {
            var builder = new ContainerBuilder();

            var assemblies = new[]
            {
                typeof (IoC).Assembly,
                typeof (DataAutofacModule).Assembly,
            };

            builder.RegisterAssemblyModules(assemblies);

            return builder.Build();
        }
    }
}