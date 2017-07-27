using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhotographerPerformance
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "PerformancePhotographers",
                url: "Performance/Photographers",
                defaults: new { controller = "Performance", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PerformancePhotos",
                url: "Performance/Photos",
                defaults: new { controller = "Performance", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Performance", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}