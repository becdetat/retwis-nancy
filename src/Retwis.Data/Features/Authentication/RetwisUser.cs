using System;
using System.Collections.Generic;
using Nancy.Security;

namespace Retwis.Data.Features.Authentication
{
    public class RetwisUser : IUserIdentity
    {
        public RetwisUser(
            string userName,
            Guid identifier)
        {
            UserName = userName;
            Claims = new string[0];
            Identifier = identifier;
        }

        public string UserName { get; private set; }
        public IEnumerable<string> Claims { get; private set; }
        public Guid Identifier { get; private set; }
    }
}