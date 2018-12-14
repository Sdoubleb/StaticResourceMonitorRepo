using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using StaticResourceMonitor.Helpers;
using StaticResourceMonitor.Models;
using StaticResourceMonitor.Users;

namespace StaticResourceMonitor.Controllers
{
    public class StaticResourceController : AsyncController
    {
        private readonly UserInfo _user;

        public StaticResourceController(UserInfo user)
        {
            _user = user;
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
                    using (HttpClient client = new HttpClient())
                    using (Stream stream = await client.GetStreamAsync(info.Reference))
                    {
                        var memoryStream = new MemoryStream(); // не нуждается в освобождении ресурсов
                        stream.CopyTo(memoryStream);
                        memoryStream.Position = 0;

                        var infoExtractor = new StaticResourceInfoExtractor(info);
                        string mimeType = infoExtractor.GetMimeType();
                        string fileName = infoExtractor.GetFileName();

                        return File(memoryStream, mimeType, fileName);
                    }
                }
                catch (HttpRequestException e)
                {
                    ModelState.AddModelError("", e.Message);
                    int responseCode;
                    Response.StatusCode = Utils.TryExtractResponseCode(e, out responseCode)
                        ? responseCode
                        : (int)HttpStatusCode.BadRequest;
                }
            }
            return View("Index");
        }
    }
}