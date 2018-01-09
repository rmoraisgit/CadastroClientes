using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RFL.CadastroClientes.UI.MVC.Startup))]
namespace RFL.CadastroClientes.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
