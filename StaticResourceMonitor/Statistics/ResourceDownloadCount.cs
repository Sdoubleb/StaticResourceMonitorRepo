using StaticResourceMonitor.Resources;

namespace StaticResourceMonitor.Statistics
{
    /// <summary>
    /// Отражает количество загрузок ресурса уникальными пользователями.
    /// </summary>
    public class ResourceDownloadCount
    {
        public ResourceDownloadCount(ResourceInfo resource)
            : this(resource, 0) { }

        public ResourceDownloadCount(ResourceInfo resource, int downloadCount)
        {
            Resource = resource;
            DownloadCount = downloadCount;
        }
        
        public ResourceInfo Resource { get; }
        
        public int DownloadCount { get; set; }
    }
}