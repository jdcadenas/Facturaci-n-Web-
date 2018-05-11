using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaFacturacionWeb.Startup))]
namespace SistemaFacturacionWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
