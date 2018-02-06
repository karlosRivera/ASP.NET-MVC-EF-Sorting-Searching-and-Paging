﻿using System;
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

            //routes.MapRoute(
            //    name: null,
            //    url: "{controller}/{action}/{page}/{SortColumn}/{CurrentSort}",
            //    defaults: new
            //    {
            //        action = "Index",
            //        page = UrlParameter.Optional,
            //        SortColumn = UrlParameter.Optional,
            //        CurrentSort = UrlParameter.Optional
            //    }
            //);

            //routes.MapRoute(
            //    name: null,
            //    url: "{controller}/{action}/{page}/{id}",
            //    defaults: new
            //    {
            //        controller = "Home",
            //        action = "Index",
            //        id = UrlParameter.Optional,
            //        page = UrlParameter.Optional,
            //    }
            //);



            routes.MapRoute(
                name: "PageWithSort",
                url: "{controller}/{action}/{page}/{SortColumn}/{CurrentSort}",
                defaults: new { action = "Index", page = UrlParameter.Optional, SortColumn = UrlParameter.Optional, CurrentSort = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "PageWithId",
            //    url: "{controller}/{action}/{page}/{id}",
            //    defaults: new { controller = "Customers", action = "Edit", page = UrlParameter.Optional, id = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //name: "PageWithId",
            //url: "{controller}/{action}/{page}/{id}"
            //);

            //routes.MapRoute(
            //    name: "PageWithId",
            //    url: "Customers/Edit/{page}/{id}",
            //    defaults: new { controller = "Customers", action = "Edit" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
