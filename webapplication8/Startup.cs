using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webapplication8.Startup))]
namespace webapplication8
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
