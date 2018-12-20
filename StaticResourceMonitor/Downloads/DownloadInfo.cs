using System;
using StaticResourceMonitor.Users;

namespace StaticResourceMonitor.Downloads
{
    public class DownloadInfo
    {
        public DownloadInfo(string reference, UserInfo user)
        {
            Reference = reference ?? throw new ArgumentNullException(paramName: nameof(reference));
            User = user ?? throw new ArgumentNullException(paramName: nameof(user));
        }

        public string Reference { get; }
        public UserInfo User { get; }

        public DateTime DateTime { get; } = DateTime.Now;
    }
}