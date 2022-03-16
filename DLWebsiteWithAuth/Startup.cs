using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DLWebsiteWithAuth.Startup))]
namespace DLWebsiteWithAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
