using Licenta1.App_Start.Authorization;
using System.Web;
using System.Web.Mvc;

namespace Licenta1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizationFilter());
        }
    }
}
