using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PracticaAutenticacion.Startup))]
namespace PracticaAutenticacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
