using System;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;

namespace Retwis.Data.Features.Authentication
{
    public class UserMapper : IUserMapper
    {
        private readonly IAuthenticationService _authenticationService;

        public UserMapper(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            // This really should be async but nancy???
            return _authenticationService.GetUserFromIdentifierAsync(identifier).Result;
        }
    }
}