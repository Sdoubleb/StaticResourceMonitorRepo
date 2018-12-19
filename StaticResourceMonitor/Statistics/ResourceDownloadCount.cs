namespace StaticResourceMonitor.Statistics
{
    /// <summary>
    /// Отражает количество загрузок ресурса уникальными пользователями.
    /// </summary>
    public class ResourceDownloadCount
    {
        public ResourceDownloadCount(string resource)
            : this(resource, 0) { }

        public ResourceDownloadCount(string resource, int downloadCount)
        {
            Resource = resource;
            DownloadCount = downloadCount;
        }
        
        public string Resource { get; }
        
        public int DownloadCount { get; set; }
    }
}