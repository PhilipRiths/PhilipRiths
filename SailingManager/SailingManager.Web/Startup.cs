using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SailingManager.Web.Startup))]
namespace SailingManager.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
