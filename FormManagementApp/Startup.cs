using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FormManagementApp.Startup))]
namespace FormManagementApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
