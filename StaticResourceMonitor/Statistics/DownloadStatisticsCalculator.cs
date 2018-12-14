using System.Collections.Generic;
using System.Linq;
using StaticResourceMonitor.Downloads;

namespace StaticResourceMonitor.Statistics
{
    public partial class DownloadStatisticsCalculator
    {
        private readonly IEnumerable<DownloadInfo> _allDownloads;
        private readonly IEnumerable<ResourceUserDownloadStatistics> _userDownloadStatistics;
        private readonly IEnumerable<ResourceDownloadCountStatistics> _downloadCountStatistics;

        public DownloadStatisticsCalculator(DownloadStorage storage)
        {
            _allDownloads = storage.GetAllDownloads();
            _userDownloadStatistics = _allDownloads.GroupBy(d => d, new DownloadEqualityComparer())
                .Select(g => new ResourceUserDownloadStatistics(g.Key.Reference, g.Key.User)
                {
                    LastDownloadDateTime = g.Max(d => d.DateTime)
                });
            _downloadCountStatistics = _userDownloadStatistics.GroupBy(s => s.Resource)
                .Select(g => new ResourceDownloadCountStatistics(g.Key)
                {
                    DownloadCount = g.Count()
                });
        }

        public IEnumerable<ResourceUserDownloadStatistics> GetUserDownloadStatistics()
        {
            return _userDownloadStatistics.AsEnumerable();
        }

        public IEnumerable<ResourceDownloadCountStatistics> GetDownloadCountStatistics()
        {
            return _downloadCountStatistics.AsEnumerable();
        }
    }
}