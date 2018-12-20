using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using StaticResourceMonitor.Downloads;
using StaticResourceMonitor.Helpers;
using StaticResourceMonitor.Models.StaticResource;
using StaticResourceMonitor.Resources;
using StaticResourceMonitor.Users;

namespace StaticResourceMonitor.Controllers
{
    public class StaticResourceController : AsyncController
    {
        private readonly UserInfo _user;
        private readonly IResourceStorage _resourceStorage;
        private readonly IDownloadStorage _downloadStorage;

        public StaticResourceController(UserInfo user,
            ResourceStorage resourceStorage, IDownloadStorage downloadStorage)
        {
            _user = user;
            _resourceStorage = resourceStorage;
            _downloadStorage = downloadStorage;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionName("Download")]
        public async Task<ActionResult> DownloadAsync(StaticResource resource)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MemoryStream stream = await GetStaticResourceStreamAsync(resource.Reference);                    
                    (string mimeType, string fileName) = ExtractStaticResourceInfo(resource);

                    RegisterDownload(resource.Reference);

                    return File(stream, mimeType, fileName);
                }
                catch (HttpRequestException e)
                {
                    ModelState.AddModelError("", e.Message);
                    Response.StatusCode = Utils.TryExtractResponseCode(e, out int responseCode)
                        ? responseCode
                        : (int)HttpStatusCode.BadRequest;
                }
            }
            return View("Index");
        }

        private async Task<MemoryStream> GetStaticResourceStreamAsync(string reference)
        {
            using (HttpClient client = new HttpClient())
            using (Stream stream = await client.GetStreamAsync(reference))
            {
                var memoryStream = new MemoryStream(); // не нуждается в освобождении ресурсов
                stream.CopyTo(memoryStream);
                memoryStream.Position = 0;
                return memoryStream;
            }
        }

        private (string mimeType, string fileName) ExtractStaticResourceInfo(StaticResource resource)
        {
            var infoExtractor = new StaticResourceInfoExtractor(resource);
            string mimeType = infoExtractor.GetMimeType();
            string fileName = infoExtractor.GetFileName();
            return (mimeType, fileName);
        }

        private void RegisterDownload(string reference)
        {
            ResourceInfo resource = _resourceStorage.GetOrAddResource(reference);
            var download = new DownloadInfo(resource, _user);
            _downloadStorage.RegisterDownload(download);
        }

        [HttpGet, ActionName("UserDownloadStatistics")]
        public ActionResult ShowUserDownloadStatistics()
        {
            return View();
        }

        [HttpGet, ActionName("DownloadCountStatistics")]
        public ActionResult ShowDownloadCountStatistics()
        {
            return View();
        }
    }
}