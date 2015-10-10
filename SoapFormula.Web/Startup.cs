using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SoapFormula.Web.Startup))]
namespace SoapFormula.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
