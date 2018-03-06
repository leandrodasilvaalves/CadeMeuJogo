using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppCadeMeuJogo.Startup))]
namespace WebAppCadeMeuJogo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
