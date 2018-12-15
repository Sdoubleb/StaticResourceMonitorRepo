using System;
using System.Linq;
using System.Net.Mime;

namespace StaticResourceMonitor.Models.StaticResource
{
    class StaticResourceInfoExtractor
    {
        private readonly StaticResourceInfo _info;
        private readonly string _fileName;

        public StaticResourceInfoExtractor(StaticResourceInfo info)
        {
            if (!StaticResourceConstants.IsMatch(info.Reference, out _fileName))
                throw new InvalidOperationException();

            _info = info;
        }

        public string GetMimeType()
        {
            const string pngMimeType = "image/png";

            if (ReferenceEndsWith(StaticResourceConstants.GIF_EXTENSIONS))
                return MediaTypeNames.Image.Gif;
            if (ReferenceEndsWith(StaticResourceConstants.TIFF_EXTENSIONS))
                return MediaTypeNames.Image.Tiff;
            if (ReferenceEndsWith(StaticResourceConstants.JPEG_EXTENSIONS))
                return MediaTypeNames.Image.Jpeg;
            if (ReferenceEndsWith(StaticResourceConstants.PNG_EXTENSIONS))
                return pngMimeType;

            return MediaTypeNames.Text.Plain;
        }

        private bool ReferenceEndsWith(string[] extensions)
        {
            return extensions.Any(e => ReferenceEndsWith(e));
        }

        private bool ReferenceEndsWith(string extension)
        {
            return _fileName.EndsWith(extension, StringComparison.InvariantCultureIgnoreCase);
        }

        public string GetFileName()
        {
            return _fileName;
        }
    }
}