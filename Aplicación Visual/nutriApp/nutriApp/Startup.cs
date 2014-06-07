using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(nutriApp.Startup))]
namespace nutriApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
