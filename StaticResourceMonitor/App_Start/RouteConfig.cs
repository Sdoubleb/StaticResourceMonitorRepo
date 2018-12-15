using System.Web.Mvc;
using System.Web.Routing;

namespace StaticResourceMonitor
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "StaticResource",
                url: "{action}/{id}",
                defaults: new { controller = "StaticResource", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "StaticResource", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}