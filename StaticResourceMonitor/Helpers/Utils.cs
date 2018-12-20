using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;

namespace StaticResourceMonitor.Helpers
{
    public static class Utils
    {
        private const string RESPONSE_CODE_REG_EXPR_PATTERN = @"\d+";

        private static Regex ResponseCodeRegExpr = new Regex(RESPONSE_CODE_REG_EXPR_PATTERN,
            RegexOptions.Compiled | RegexOptions.Singleline);

        public static bool TryExtractResponseCode(HttpRequestException exception, out int responseCode)
        {
            Match match = ResponseCodeRegExpr.Match(exception.Message);
            responseCode = match.Success ? Int32.Parse(match.Value) : 0;
            return match.Success;
        }

        public static string DecodeUrl(string url)
        {
            return HttpUtility.UrlDecode(url).ToLowerInvariant();
        }
    }
}