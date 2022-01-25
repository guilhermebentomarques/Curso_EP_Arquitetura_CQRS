using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Escola.UI.Cadastro.Startup))]
namespace Escola.UI.Cadastro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
