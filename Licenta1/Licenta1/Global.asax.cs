using Licenta1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Licenta1
{
    public class MvcApplication : System.Web.HttpApplication
    {
       // private const string JobCashAction = "http://localhost:44303/Eveniments/SendEmail/2";
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Licenta1Context>());
        }

       /* protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Cache["jobkey"] == null)
            {
                HttpContext.Current.Cache.Add("jobkey",
                                "jobvalue", null,
                                DateTime.MaxValue,
                                TimeSpan.FromMinutes(1), // set the time interval  
                                CacheItemPriority.Default, JobCacheRemoved);
            }
        }
        private static void JobCacheRemoved(string key, object value, CacheItemRemovedReason reason)
        {
            var client = new WebClient();
            client.DownloadData(JobCashAction);
            ScheduleJob();
        }
        private static void ScheduleJob()
        {
            // ExecuteAnyMethod  
        }*/
    }
}
