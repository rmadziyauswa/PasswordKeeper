using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PasswordKeeper.Webapp.Startup))]
namespace PasswordKeeper.Webapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
