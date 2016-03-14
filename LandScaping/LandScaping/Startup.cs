using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LandScaping.Startup))]
namespace LandScaping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
