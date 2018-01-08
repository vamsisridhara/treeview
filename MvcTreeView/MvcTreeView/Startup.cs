using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcTreeView.Startup))]
namespace MvcTreeView
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
