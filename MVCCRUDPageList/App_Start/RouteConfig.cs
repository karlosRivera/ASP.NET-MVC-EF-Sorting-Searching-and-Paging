using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCCRUDPageList
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}/{id}/{page}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional,
                    page = UrlParameter.Optional,
                }
            );

            //routes.MapRoute(
            //    name: null,
            //    url: "Customers/{page}/{SortColumn}",
            //    defaults: new
            //    {
            //        action = "Index",
            //        page = UrlParameter.Optional,
            //        SortColumn = UrlParameter.Optional
            //    }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
