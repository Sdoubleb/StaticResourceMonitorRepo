namespace StaticResourceMonitor.Statistics
{
    public class ResourceDownloadCountStatistics
    {
        public ResourceDownloadCountStatistics(string resource)
            : this(resource, 0) { }

        public ResourceDownloadCountStatistics(string resource, int downloadCount)
        {
            Resource = resource;
            DownloadCount = downloadCount;
        }

        public string Resource { get; }

        public int DownloadCount { get; set; }
    }
}