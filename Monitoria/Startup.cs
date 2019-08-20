using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Monitoria.Startup))]
namespace Monitoria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
