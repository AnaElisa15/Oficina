using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OficinaMecanica.Startup))]
namespace OficinaMecanica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
