using System;
using StaticResourceMonitor.Users;

namespace StaticResourceMonitor.Statistics
{
    /// <summary>
    /// Отражает информацию о последней загрузке ресурса определённым пользователем.
    /// </summary>
    public class ResourceUserDownload
    {
        public ResourceUserDownload(string resource, UserInfo user)
            : this(resource, user, default(DateTime)) { }

        public ResourceUserDownload(string resource, UserInfo user,
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