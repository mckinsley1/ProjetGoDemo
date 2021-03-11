using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetGo.Startup))]
namespace ProjetGo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
