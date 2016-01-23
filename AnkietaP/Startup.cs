using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnkietaP.Startup))]
namespace AnkietaP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
