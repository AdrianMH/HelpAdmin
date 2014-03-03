using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelpAdminWeb.Startup))]
namespace HelpAdminWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
