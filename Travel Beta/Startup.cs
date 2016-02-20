using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Travel_Beta.Startup))]
namespace Travel_Beta
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
