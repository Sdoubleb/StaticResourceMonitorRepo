using System.Collections.Generic;

namespace StaticResourceMonitor.Downloads
{
    public interface IDownloadStorage
    {
        void RegisterDownload(DownloadInfo download);

        IEnumerable<DownloadInfo> GetAllDownloads();
    }
}
