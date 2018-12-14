using System;
using StaticResourceMonitor.Users;

namespace StaticResourceMonitor.Statistics
{
    public class ResourceUserDownloadStatistics
    {
        public ResourceUserDownloadStatistics(string resource, UserInfo user)
            : this(resource, user, default(DateTime)) { }

        public ResourceUserDownloadStatistics(string resource, UserInfo user,
            DateTime lastDownloadDateTime)
        {
            Resource = resource;
            User = user;
            LastDownloadDateTime = lastDownloadDateTime;
        }

        public string Resource { get; }
        public UserInfo User { get; }

        public DateTime LastDownloadDateTime { get; set; }
    }
}