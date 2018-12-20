using System;
using StaticResourceMonitor.Resources;
using StaticResourceMonitor.Users;

namespace StaticResourceMonitor.Downloads
{
    public class DownloadInfo
    {
        public DownloadInfo(ResourceInfo resource, UserInfo user)
        {
            Resource = resource ?? throw new ArgumentNullException(paramName: nameof(resource));
            User = user ?? throw new ArgumentNullException(paramName: nameof(user));
        }

        public ResourceInfo Resource { get; }
        public UserInfo User { get; }

        public DateTime DateTime { get; } = DateTime.Now;
    }
}