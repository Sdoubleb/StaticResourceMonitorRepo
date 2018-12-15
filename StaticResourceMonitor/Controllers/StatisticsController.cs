using System.Collections.Generic;
using System.Web.Http;
using StaticResourceMonitor.Statistics;

namespace StaticResourceMonitor.Controllers
{
    public class StatisticsController : ApiController
    {
        private DownloadStatisticsCalculator _calculator;

        public StatisticsController(DownloadStatisticsCalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet, Route("api/statistics/users")]
        public IEnumerable<ResourceUserDownloadStatistics> GetUserDownloadStatistics()
        {
            return _calculator.GetUserDownloadStatistics();
        }

        [HttpGet, Route("api/statistics/count")]
        public IEnumerable<ResourceDownloadCountStatistics> GetDownloadCountStatistics()
        {
            return _calculator.GetDownloadCountStatistics();
        }
    }
}