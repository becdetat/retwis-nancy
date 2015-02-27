using System;

namespace Retwis.Data.Domain.LatestMessageAggregate
{
    public class LatestMessage
    {
        public LatestMessage(string username, DateTime time, string status)
        {
            Status = status;
            Time = time;
            Username = username;
        }

        public string Username { get; private set; }
        public DateTime Time { get; private set; }
        public string Status { get; private set; }
    }
}