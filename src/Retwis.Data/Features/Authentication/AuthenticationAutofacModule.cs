using Autofac;
using Nancy.Authentication.Forms;

namespace Retwis.Data.Features.Authentication
{
    public class AuthenticationAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserMapper>().As<IUserMapper>();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
        }
    }
}