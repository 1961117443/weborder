using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebOrderUI.Startup))]
namespace WebOrderUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
