using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StaticResourceMonitor.Models.StaticResource
{
    static class StaticResourceConstants
    {
        private const string FILE_NAME_GROUP = "filename";

        // некоторые форматы изображений
        public static string[] GIF_EXTENSIONS = new string[] { @"gif" };
        public static string[] PNG_EXTENSIONS = new string[] { @"png" };
        public static string[] TIFF_EXTENSIONS = new string[] { @"tif", @"tiff" };
        public static string[] JPEG_EXTENSIONS = new string[] { @"jpg", @"jpeg", @"jpe", @"gfif" };

        private static string IMG_EXTENSIONS_REG_EXPR_PATTERN = String.Join("|",
            GIF_EXTENSIONS.Union(PNG_EXTENSIONS).Union(TIFF_EXTENSIONS).Union(JPEG_EXTENSIONS));
        
        private static string SIMPLE_URL_REG_EXPR_PATTERN = $@"^https?:\/\/([\w\.\-_]+)(\:\d+)?\/"
            + $@"(([\w\.\-_\/]+)\/)?"
            + $@"(?<{FILE_NAME_GROUP}>([\w\.\-_]+)\.(js|css|{IMG_EXTENSIONS_REG_EXPR_PATTERN}))";

        public static Regex SIMPLE_URL_REG_EXPR = new Regex(SIMPLE_URL_REG_EXPR_PATTERN,
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.CultureInvariant);

        public static bool IsMatch(string input)
        {
            return SIMPLE_URL_REG_EXPR.IsMatch(input);
        }

        public static bool IsMatch(string input, out string fileName)
        {
            Match match = SIMPLE_URL_REG_EXPR.Match(input);
            fileName = match.Success ? match.Groups[FILE_NAME_GROUP].Value : null;
            return match.Success;
        }
    }
}