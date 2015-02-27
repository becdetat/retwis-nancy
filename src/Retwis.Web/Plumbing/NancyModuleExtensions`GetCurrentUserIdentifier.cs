using System;
using Nancy;
using Retwis.Data.Features.Authentication;

namespace Retwis.Web.Plumbing
{
    public static partial class NancyModuleExtensions
    {
        public static Guid GetCurrentUserIdentifier(this NancyModule module)
        {
            return ((RetwisUser) module.Context.CurrentUser).Identifier;
        }
    }
}