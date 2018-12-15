using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using StaticResourceMonitor.Downloads;
using StaticResourceMonitor.Helpers;
using StaticResourceMonitor.Models.StaticResource;
using StaticResourceMonitor.Users;

namespace StaticResourceMonitor.Controllers
{
    public class StaticResourceController : AsyncController
    {
        private readonly UserInfo _user;
        private readonly DownloadStorage _downloadStorage;

        public StaticResourceController(UserInfo user, DownloadStorage downloadStorage)
        {
            _user = user;
            _downloadStorage = downloadStorage;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionName("Download")]
        public async Task<ActionResult> DownloadAsync(StaticResourceInfo info)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MemoryStream stream = await GetStaticResourceStreamAsync(info.Reference);                    
                    (string mimeType, string fileName) = ExtractStaticResourceInfo(info);

                    RegisterDownload(info.Reference);

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

        private (string mimeType, string fileName) ExtractStaticResourceInfo(StaticResourceInfo info)
        {
            var infoExtractor = new StaticResourceInfoExtractor(info);
            string mimeType = infoExtractor.GetMimeType();
            string fileName = infoExtractor.GetFileName();
            return (mimeType, fileName);
        }

        private void RegisterDownload(string reference)
        {
            var download = new DownloadInfo(reference, _user);
            _downloadStorage.RegisterDownload(download);
        }
    }
}