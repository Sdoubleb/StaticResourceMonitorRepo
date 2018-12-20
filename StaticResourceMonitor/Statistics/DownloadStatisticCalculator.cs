using System.Collections.Generic;
using System.Linq;
using StaticResourceMonitor.Downloads;

namespace StaticResourceMonitor.Statistics
{
    public partial class DownloadStatisticCalculator : IDownloadStatisticCalculator
    {
        private readonly IEnumerable<DownloadInfo> _allDownloads;
        private readonly IEnumerable<ResourceUserDownload> _userDownloadStatistics;
        private readonly IEnumerable<ResourceDownloadCount> _downloadCountStatistics;

        public DownloadStatisticCalculator(IDownloadStorage storage)
        {
            _allDownloads = storage.GetAllDownloads();
            _userDownloadStatistics = _allDownloads.GroupBy(d => d, new DownloadEqualityComparer())
                .Select(g => new ResourceUserDownload(g.Key.Reference, g.Key.User)
                {
                    LastDownloadDateTime = g.Max(d => d.DateTime)
                });
            _downloadCountStatistics = _userDownloadStatistics.GroupBy(s => s.Resource)
                .Select(g => new ResourceDownloadCount(g.Key)
                {
                    DownloadCount = g.Count()
                });
        }

        public IEnumerable<ResourceUserDownload> GetUserDownloadStatistics()
        {
            return _userDownloadStatistics.ToArray();
        }

        public IEnumerable<ResourceDownloadCount> GetDownloadCountStatistics()
        {
            return _downloadCountStatistics.ToArray();
        }
    }
}