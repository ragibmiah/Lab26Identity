using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab26Coffee.Startup))]
namespace Lab26Coffee
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
