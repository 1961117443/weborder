using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcWebOrder.Startup))]
namespace MvcWebOrder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
