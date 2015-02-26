using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Retwis.Data.Persistence;
using StackExchange.Redis;

namespace Retwis.Data
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RedisContext>().As<IRedisContext>();
        }
    }
}
