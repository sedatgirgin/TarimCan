using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TarimCan
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
           // BundleConfig.RegisterBundles(BundleTable.Bundles);
            System.Web.Helpers.AntiForgeryConfig.SuppressXFrameOptionsHeader = true;
        }

        //protected void Application_PreSendRequestHeaders()
        //{
        //    Response.Headers.Remove("X-Frame-Options");
        //    Response.AddHeader("X-Frame-Options", "AllowAll");

        //}
    }
}
