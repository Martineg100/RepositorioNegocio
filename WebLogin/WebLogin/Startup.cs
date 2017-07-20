using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebLogin.Startup))]
namespace WebLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
