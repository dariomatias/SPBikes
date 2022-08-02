using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalProgramacionWeb.Startup))]
namespace FinalProgramacionWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
