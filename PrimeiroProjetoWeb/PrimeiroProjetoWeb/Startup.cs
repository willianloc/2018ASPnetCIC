using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrimeiroProjetoWeb.Startup))]
namespace PrimeiroProjetoWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
