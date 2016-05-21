using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Alumni.Web.Startup))]
namespace Alumni.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
