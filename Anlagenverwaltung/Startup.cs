using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Anlagenverwaltung.Startup))]
namespace Anlagenverwaltung
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
