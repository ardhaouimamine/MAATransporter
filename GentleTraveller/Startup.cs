using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GentleTraveller.Startup))]
namespace GentleTraveller
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
