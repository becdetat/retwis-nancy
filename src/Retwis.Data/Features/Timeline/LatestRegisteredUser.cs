namespace Retwis.Data.Features.Timeline
{
    public class LatestRegisteredUser
    {
        public LatestRegisteredUser(string username)
        {
            Username = username;
        }

        public string Username { get; private set; }
    }
}