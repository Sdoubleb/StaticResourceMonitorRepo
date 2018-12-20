using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using StaticResourceMonitor.Models.Statistics;
using StaticResourceMonitor.Statistics;

namespace StaticResourceMonitor.Controllers
{
    public class StatisticsController : ApiController
    {
        private IDownloadStatisticCalculator _calculator;

        public StatisticsController(IDownloadStatisticCalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet, Route("api/statistics/users")]
        public IEnumerable<ResourceUserDownloadData> GetUserDownloadStatistics()
        {
            return _calculator.GetUserDownloadStatistics().Select(s => new ResourceUserDownloadData
            {
                Resource = s.Resource.Reference,
                User = s.User.Id,
                LastDownloadDateTime = s.LastDownloadDateTime
            });
        }

        [HttpGet, Route("api/statistics/count")]
        public IEnumerable<ResourceDownloadCountData> GetDownloadCountStatistics()
        {
            return _calculator.GetDownloadCountStatistics().Select(s => new ResourceDownloadCountData
            {
                Resource = s.Resource.Reference,
                DownloadCount = s.DownloadCount
            });
        }
    }
}