using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SoapFormula.Web.App_Start;
using SoapFormula.Bootstrap;

namespace SoapFormula.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AutoMaperDtoConfig.RegisterDtoMapping();
            AutoMapperConfig.RegisterMapping();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
