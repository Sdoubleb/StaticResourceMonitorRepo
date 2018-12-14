using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        // GET api/statistics
        public IEnumerable<ResourceUserDownloadStatistics> Get()
        {
            return _calculator.GetUserDownloadStatistics();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}