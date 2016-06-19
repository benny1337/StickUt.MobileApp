using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StickUt.Web.Startup))]
namespace StickUt.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
